using System.Windows.Controls;
using task5.Tools.Navigation;
using task5.ViewModel;

namespace task5.View
{

    public partial class TaskListView : UserControl, INavigatable
    {
        public TaskListView()
        {
            InitializeComponent();
            DataContext = new TaskListViewModel();
        }

  
    }
}
