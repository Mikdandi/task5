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
        internal static List<Task> GetCurrentTasksAndCheckForBreak(CancellationToken cancellationToken)
        {
            List<Task> res = new List<Task>();
            return GetCurrentTasks(Process.GetProcesses(), cancellationToken);
        }

        private static List<Task> GetCurrentTasks(Process[] processes, CancellationToken cancellationToken)
        {
            List<Task> res = new List<Task>();
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

        private static Task GetTask(Process process)
        {
            double cpuMeasure = TryToGetCpuMeasure(process);
            double ramMb = TryToGetRamMeasure(process);
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
            Task task = new Task(process.ProcessName, process.Id, process.Responding, cpuMeasure,ramMb/(8*1024), ramMb, process.Threads.Count, processOwner,path, startDateTime.ToShortDateString());
         
         
            return task;

        }
     
        private static double TryToGetCpuMeasure(Process process)
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

        private static double TryToGetRamMeasure(Process process)
        {
            PerformanceCounter counter = null;
            double res = 0;
            try
            {
                counter = new PerformanceCounter("Process", "Working Set", process.ProcessName, true);
                res = counter.NextValue();
            }
            catch (Exception)
            {
                Console.WriteLine();
            }

            if (counter != null)
            {
                counter.Dispose();
            }
            return res;
        }

        private static string TryToGetProcessOwner(Process process)
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

        private static DateTime TryToGetDateTime(Process process)
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
            return Process.GetProcessById(processId);
        }
    }
}
