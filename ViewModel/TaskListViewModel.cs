using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Linq;
using task5.Model;
using task5.Tools;
using BackgroundTask = System.Threading.Tasks.Task;
using task5.Tools.Manager;
using task5.Tools.Loader;
using System.Threading;
using System.Windows;
using task5.Tools.Navigation;

namespace task5.ViewModel
{
    internal class TaskListViewModel : BaseViewModel, ITaskListOwner
    {
        #region fields

        private ObservableCollection<Task> _taskList;
        private BackgroundTask _backgroundTask;
        private CancellationToken _token;
        private CancellationTokenSource _tokenSource;

    
        private bool _nameSort;
        private int _selectedSort;
        private bool _idSort;
        private bool _activeSort;
        private bool _cpuSort;
        private bool _ramPercentSort;
        private bool _ramVolumeSort;
        private bool _threadsNumSort;
        private bool _taskSort;
        private bool _startDateSort;

        private bool _pressedSort;

        private Task _selected;



        #endregion

        #region properties

        public ObservableCollection<Task> TaskList
        {
            get
            {
                return _taskList;
            }
            set
            {
                _taskList = value;
                
                OnPropertyChanged();
            }
        }

    

        public bool NameSort
        {
            get
            {
                return _nameSort;
            }

            set
            {
                _nameSort = value;
                OnPropertyChanged();
            }
        }

        public int SelectedSort
        {
            get
            {
                return _selectedSort;
            }

            set
            {
                _selectedSort = value;
              //  GetSorted(tasks);
                OnPropertyChanged();
            }
        }

        public bool IdSort
        {
            get
            {
                return _idSort;
            }

            set
            {
                _idSort = value;
                OnPropertyChanged();
            }
        }

        public bool ActiveSort
        {
            get
            {
                return _activeSort;
            }

            set
            {
                _activeSort = value;
                OnPropertyChanged();
            }
        }

        public bool CpuSort
        {
            get
            {
                return _cpuSort;
            }

            set
            {
                _cpuSort = value;
                OnPropertyChanged();
            }
        }

        public bool RamPercentSort
        {
            get
            {
                return _ramPercentSort;
            }

            set
            {
                _ramPercentSort = value;
                OnPropertyChanged();
            }
        }

        public bool RamVolumeSort
        {
            get
            {
                return _ramVolumeSort;
            }

            set
            {
                _ramVolumeSort = value;
                OnPropertyChanged();
            }
        }

        public bool ThreadsNumSort
        {
            get
            {
                return _threadsNumSort;
            }

            set
            {
                _threadsNumSort = value;
                OnPropertyChanged();
            }
        }

        public bool UserSort
        {
            get
            {
                return _taskSort;
            }

            set
            {
                _taskSort = value;
                OnPropertyChanged();
            }
        }

        public bool StartDateSort
        {
            get
            {
                return _startDateSort;
            }

            set
            {
                _startDateSort = value;
                OnPropertyChanged();
            }
        }

        public Task Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                _selected = value;
                OnPropertyChanged();
            }
        }
        public bool PressedSort
        {
            get
            {
                return _pressedSort;
            }

            set
            {
                _pressedSort = value;
                OnPropertyChanged();
            }
        }
     

        #endregion


        internal TaskListViewModel()
        {
            _tokenSource = new CancellationTokenSource();
            _token = _tokenSource.Token;
            StartBarckgroundTask();
            StationManager.StopThreads += StopBackgroundTask;
            TaskListManager.Initialize(this);
        }

        private void StartBarckgroundTask()
        {
            _backgroundTask = BackgroundTask.Factory.StartNew(BackgroundTaskProcess, System.Threading.Tasks.TaskCreationOptions.LongRunning);
        }

        private async void BackgroundTaskProcess()
        {
            int i = 0;
            while (!_token.IsCancellationRequested)
            {
                if (_taskList == null)
                {
                   
                }
                await BackgroundTask.Run(() => LoadNewTasks());
                if (_token.IsCancellationRequested)
                    break;
                i++;
            }
        }

        private void LoadNewTasks()
        {
            Task selected = _selected;
            var tasks = TaskListLoader.GetCurrentTasksAndCheckForBreak(_token);
            if (_pressedSort) tasks = GetSorted(tasks);
            TaskList = new ObservableCollection<Task>(tasks);
            Selected = TaskList.ToList().FirstOrDefault(task => task.Equals(selected));
        }

        internal void StopBackgroundTask()
        {
            _tokenSource.Cancel();
            if (_backgroundTask == null)
            {
                return;
            }
            _backgroundTask.Wait(2000);
            _backgroundTask.Dispose();
            _backgroundTask = null;
        }
    
        private void Sort(object obj)
        {
            _pressedSort = true;
            var tasks = _taskList.ToList();
            TaskList = new ObservableCollection<Task>(GetSorted(tasks));
        }

        private List<Task> GetSorted(List<Task> taskList)
        {

            MessageBox.Show("ura");
            if (SelectedSort==1)
            {
                taskList.Sort((task, task1) => task.NameOfProcess.CompareTo(task1.NameOfProcess));
            }
            else if (SelectedSort == 2)
            {
                taskList.Sort((task, task1) => task.ID.CompareTo(task1.ID));
            }
            else if (SelectedSort == 3)
            {
                taskList.Sort((task, task1) => task.ActivityOfProcess.CompareTo(task1.ActivityOfProcess));
            }
            else if (SelectedSort == 4)
            {
                taskList.Sort((task, task1) => task.CPU.CompareTo(task1.CPU));
            }
            else if (SelectedSort == 5)
            {
                taskList.Sort((task, task1) => task.RAM.CompareTo(task1.RAM));
            }

            else if (SelectedSort == 6)
            {
                taskList.Sort((task, task1) => task.NumberOfFlows.CompareTo(task1.NumberOfFlows));
            }
            else if (SelectedSort == 7)
            {
                taskList.Sort((task, task1) => task.UserName.CompareTo(task1.UserName));
            }
            else if (SelectedSort == 8)
            {
                taskList.Sort((task, task1) => task.Date.CompareTo(task1.Date));
            }

            return taskList;
        }
      

    }
}
