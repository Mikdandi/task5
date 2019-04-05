using task5.Model;

namespace task5.Tools
{
    internal interface ITaskListOwner
    {
        Task Selected { get; set; }
    }
}
