using System;
using System.Windows;

namespace task5.Tools.Manager
{
    class StationManager
    {
        public static event Action StopThreads;

        internal static void CloseApp()
        {
            MessageBox.Show("ShutDown");
            StopThreads?.Invoke();
            Environment.Exit(1);
        }
    }
}
