using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Linq;
using task5.Model;
using task5.Tools;
using  InsideTask = System.Threading.Tasks.Task;
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
        private InsideTask _insideTask;
        private CancellationToken _token;
        private CancellationTokenSource _tokenSource;

    
      
        private string _selectedSort;
    

        private bool _pressedSort;

        private Task _selected;
        private RelayCommand<object> _sortCommand;


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

        public bool PressedSort
        {
            get
            {
                return _pressedSort;
            }

            set
            {
                _pressedSort = value;
              //  GetSorted(tasks);
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

        public string SelectedSort
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
            _insideTask = InsideTask.Factory.StartNew(BackgroundTaskProcess, System.Threading.Tasks.TaskCreationOptions.LongRunning);
        }

        private async void BackgroundTaskProcess()
        {
            int i = 0;
            while (!_token.IsCancellationRequested)
            {
                if (_taskList == null)
                {
                   
                }
                await InsideTask.Run(() => LoadNewTasks());
                if (_token.IsCancellationRequested)
                    break;
                i++;
            }
        }

        private void LoadNewTasks()
        {
            Task selected = _selected;
            var tasks = TaskListLoader.GetCurrentTasksAndCheckForBreak(_token);
            if (_pressedSort)
            {
                tasks = GetSorted(tasks);
            }
            TaskList = new ObservableCollection<Task>(tasks);
            Selected = TaskList.ToList().FirstOrDefault(task => task.Equals(selected));
        }
        public RelayCommand<object> SortCommand
        {
            get
            {
                return _sortCommand ?? (_sortCommand = new RelayCommand<object>(
                           Sort));
            }
        }
        internal void StopBackgroundTask()
        {
            _tokenSource.Cancel();
            if (_insideTask == null)
            {
                return;
            }
            _insideTask.Wait(2000);
            _insideTask.Dispose();
            _insideTask = null;
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
            if (SelectedSort== "Sort by Name")
            {
                taskList.Sort((task, task1) => task.NameOfProcess.CompareTo(task1.NameOfProcess));
            }
            else if (SelectedSort == "Sort by ID")
            {
                taskList.Sort((task, task1) => task.ID.CompareTo(task1.ID));
            }
            else if (SelectedSort == "Sort by Activity")
            {
                taskList.Sort((task, task1) => task.ActivityOfProcess.CompareTo(task1.ActivityOfProcess));
            }
            else if (SelectedSort == "Sort by CPU ")
            {
                taskList.Sort((task, task1) => task.CPU.CompareTo(task1.CPU));
            }
            else if (SelectedSort == "Sort by RAM% ")
            {
                taskList.Sort((task, task1) => task.RAMPersent.CompareTo(task1.RAMPersent));
            }
            else if (SelectedSort == "Sort by RAM ")
            {
                taskList.Sort((task, task1) => task.RAM.CompareTo(task1.RAM));
            }

            else if (SelectedSort == "Sort by number of flows ")
            {
                taskList.Sort((task, task1) => task.NumberOfFlows.CompareTo(task1.NumberOfFlows));
            }
            else if (SelectedSort == "Sort by UserName ")
            {
                taskList.Sort((task, task1) => task.UserName.CompareTo(task1.UserName));
            }
            else if (SelectedSort == "Sort by date ")
            {
                taskList.Sort((task, task1) => task.Date.CompareTo(task1.Date));
            }
            else if (SelectedSort == "Sort by path ")
            {
                taskList.Sort((task, task1) => task.Path.CompareTo(task1.Date));
            }

            return taskList;
        }
      

    }
}
