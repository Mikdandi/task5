using System.Windows.Controls;
using task5.Tools.Navigation;
using task5.ViewModel;

namespace task5.ViewModel
{
    /// <summary>
    /// Логика взаимодействия для ModuleView.xaml
    /// </summary>
    public partial class ModuleView : UserControl
    {
        internal ModuleView(System.Diagnostics.Process process)
        {
            InitializeComponent();
            DataContext = new ModuleViewModel(process.Modules);
        }
    }
}
