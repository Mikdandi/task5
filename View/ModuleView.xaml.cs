using System.Windows.Controls;


namespace task5.ViewModel
{
    /// <summary>
    /// Логика взаимодействия для ModuleView.xaml
    /// </summary>
    public partial class ModuleView : UserControl
    {
        internal ModuleView()
        {
            InitializeComponent();
            DataContext = new ModuleViewModel();
        }
    }
}
