
using System.Windows.Controls;
using task5.Tools.Navigation;
using task5.ViewModel;

namespace task5.View
{
    /// <summary>
    /// Логика взаимодействия для ThreadView.xaml
    /// </summary>
    public partial class ThreadView : UserControl, INavigatable
    {
        internal ThreadView()
        {
            InitializeComponent();
            DataContext = new ThreadViewModel();
        }
    }
}
