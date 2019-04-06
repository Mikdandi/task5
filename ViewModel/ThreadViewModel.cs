using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using task5.Tools;


namespace task5.ViewModel
{
    internal class ThreadViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ProcessThread> _threads;



        public ObservableCollection<ProcessThread> Threads
        {
            get => _threads;
            private set
            {
                _threads = value;
                OnPropertyChanged();
            }
        }

        internal ThreadViewModel()
        {
            Threads = new ObservableCollection<ProcessThread>();

        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
