using System;

namespace task5.Tools.Navigation
{
    internal enum ViewType
    {
        TaskManager,
        ThreadView
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
