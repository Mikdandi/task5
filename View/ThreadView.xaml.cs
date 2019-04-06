
using System.Windows.Controls;
using task5.ViewModel;

namespace task5.View
{
    /// <summary>
    /// Логика взаимодействия для ThreadView.xaml
    /// </summary>
    public partial class ThreadView : UserControl
    {
        internal ThreadView(System.Diagnostics.Process process)
        {
            InitializeComponent();
            DataContext = new ThreadViewModel(process.Threads);
        }
    }
}
