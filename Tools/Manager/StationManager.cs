using System;
using System.Windows;

namespace task5.Tools.Manager
{
    class StationManager
    {
        public static event Action StopThreads;

        internal static void CloseApp()
        {
           
            StopThreads?.Invoke();
            Environment.Exit(1);
        }
    }
}
