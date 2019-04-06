using TaskListView = task5.View.TaskListView;
using ThreadListView = task5.View.ThreadView;

using System;

namespace task5.Tools.Navigation
{
    internal class InitializationNavigationModel : BaseNavigationModel
    {
        public InitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner)
        { }

        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.TaskManager:
                    ViewsDictionary.Add(viewType, new TaskListView());
                    break;
                case ViewType.ThreadView:
                    ViewsDictionary.Add(viewType, new ThreadListView());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}
