using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using task5.Tools;

namespace task5.ViewModel
{
    internal class ModuleViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ProcessModule> _modules;
      

        public ObservableCollection<ProcessModule> Modules
        {
            get => _modules;
            private set
            {
                _modules = value;
                OnPropertyChanged();
            }
        }


        internal ModuleViewModel()
        {
            Modules = new ObservableCollection<ProcessModule>();
        
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
