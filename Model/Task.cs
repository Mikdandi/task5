using System;


namespace task5.Model
{
    internal class Task
    {
        #region fields


        private string _nameOfProcess;
        private double _id;
        private bool _activityOfProcess;
        private double _cpu;
        private double _ramPersent;
        private double _ram;
        private int _numberOfFlows;
        private string _userName;
        private string _path;
        private string _dateTime;




        #endregion

        #region properties
     
        public string NameOfProcess
        {
            get { return _nameOfProcess; }
            set
            {
                _nameOfProcess = value;
            }
        }

        public double ID
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        public bool ActivityOfProcess
        {
            get { return _activityOfProcess; }
            set
            {
                _activityOfProcess = value;
            }
        }

        public double CPU
        {
            get { return _cpu; }
            set
            {
                _cpu = value;
            }
        }
        public double RAMPersent
        {
            get { return _ramPersent; }
            set
            {
                _ramPersent = value;
            }
        }
        public double RAM
        {
            get { return _ram; }
            set
            {
                _ram = value;
            }
        }

        public int NumberOfFlows
        {
            get { return _numberOfFlows; }
            set
            {
                _numberOfFlows = value;
            }
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
            }
        }

        public string Path
        {
            get { return _path; }
            set
            {
                _path = value;
            }
        }

        public string Date
        {
            get { return _dateTime; }
            set
            {
                _dateTime = value;
            }
        }

        #endregion





        internal Task(string nameOfProcess, double id, bool activityOfProcess, double cpu, double ramPersent, double ram, int numberOfFlows, string userName, string path, string dateTime)
        {
            _nameOfProcess = nameOfProcess;
            _id = id;
            _activityOfProcess = activityOfProcess;
            _cpu = cpu;
            _ram = ram;
            _numberOfFlows = numberOfFlows;
            _userName = userName;
            _path = path;
            _dateTime = dateTime == default(DateTime).ToShortDateString() ? "-" : dateTime;
        }
       
    }
}
