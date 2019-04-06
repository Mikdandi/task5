using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;

using System.Dynamic;
using System.Threading;
using task5.Model;
using DateTime = System.DateTime;

namespace task5.Tools.Loader
{
    internal static class TaskListLoader
    {
        internal static List<Model.Task> GetCurrentTasksAndCheckForBreak(CancellationToken cancellationToken)
        {
            List<Model.Task> res = new List<Model.Task>();
            return GetCurrentTasks(System.Diagnostics.Process.GetProcesses(), cancellationToken);
        }

        private static List<Model.Task> GetCurrentTasks(System.Diagnostics.Process[] processes, CancellationToken cancellationToken)
        {
            List<Model.Task> res = new List<Model.Task>();
            for (int i = 0; i < processes.Length; i++)
            {
                res.Add(GetTask(processes[i]));
                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }
            }
            return res;
        }

        private static Task GetTask(System.Diagnostics.Process process)
        {
            double cpuMeasure = TryToGetCpuMeasure(process);
      
            double ramMb = process.PagedMemorySize64;
            double ramPercentage = ramMb / (8 * 1024);
            string processOwner = TryToGetProcessOwner(process);
            string path="Path";
            DateTime startDateTime = TryToGetDateTime(process);
            ManagementObjectCollection processList = new ManagementObjectSearcher("Select * From Win32_Process").Get();
            foreach (ManagementObject obj in processList)
            {
                if (obj["ExecutablePath"] != null && process.Id==int.Parse(obj["ProcessId"].ToString()))
                {
                    try { path = obj["ExecutablePath"].ToString(); }
                    catch
                    {

                    }

                }
            }
            Model.Task task = new Model.Task(process.ProcessName, process.Id, process.Responding, cpuMeasure, ramPercentage, ramMb, process.Threads.Count, processOwner, path, startDateTime.ToShortDateString());
         
         
            return task;

        }
     
        private static double TryToGetCpuMeasure(System.Diagnostics.Process process)
        {
            PerformanceCounter counter = null;
            double res = 0;
            try
            {
                counter = new PerformanceCounter("Process", "% Processor Time", process.ProcessName, true);
                res = counter.NextValue();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            if (counter != null)
            {
                counter.Dispose();
            }
            return res;
        }


      

        private static string TryToGetProcessOwner(System.Diagnostics.Process process)
        {
            try
            {
                return process.MachineName;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return " - ";
        }

        private static DateTime TryToGetDateTime(System.Diagnostics.Process process)
        {
            try
            {
                return process.StartTime;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return default(DateTime);
        }

        internal static Process GetProcessById(int processId)
        {
            return System.Diagnostics.Process.GetProcessById(processId);
        }
    }
}
