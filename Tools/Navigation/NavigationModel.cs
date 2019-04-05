using System;

namespace task5.Tools.Navigation
{
    internal enum ViewType
    {
        TaskManager,
        //ThreadInfo,
       // Modules
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
