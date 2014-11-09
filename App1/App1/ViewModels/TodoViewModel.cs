using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using App1.Models;
using System.Collections.ObjectModel;

namespace App1.ViewModels
{
    class TodoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private TodoModel Model = new TodoModel();

        public ReadOnlyCollection<string> Tasks
        {
            get { return Model.GetAll(); }
            private set { }
        }

        private string _newTaskDraft = string.Empty;
        public string NewTaskDraft
        {
            get { return _newTaskDraft; }
            set
            {
                if (_newTaskDraft != value)
                {
                    _newTaskDraft = value;
                    OnPropertyChanged("NewTaskDraft");
                }
            }
        }

        public void AddTask()
        {
            if (!string.IsNullOrEmpty(NewTaskDraft))
            {
                Model.Add(NewTaskDraft);
                OnPropertyChanged("Tasks");

                NewTaskDraft = string.Empty;
            }
        }

        public void ClearAllTasks()
        {
            Model.Clear();
            OnPropertyChanged("Tasks");
        }

        public void DeleteTask(string task)
        {
            Model.Delete(task);
            OnPropertyChanged("Tasks");
        }

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
