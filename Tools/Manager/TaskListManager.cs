using task5.Model;

namespace task5.Tools.Manager
{
    class TaskListManager
    {
        private static ITaskListOwner _taskListOwner;

        internal static void Initialize(ITaskListOwner owner)
        {
            _taskListOwner = owner;
        }

        internal static Task GetSelected()
        {
            return _taskListOwner.Selected;
        }
    }
}
