using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace App1.Models
{
    public class TodoModel
    {
        private List<string> TasksList = new List<string>();

        public ReadOnlyCollection<string> GetAll()
        {
            return TasksList.AsReadOnly();
        }

        public void Add(string task)
        {
            TasksList.Add(task);
        }

        public void Delete(string task)
        {
            int index = TasksList.FindIndex((string value) => { return value == task; });
            TasksList.RemoveAt(index);
        }

        public void Clear()
        {
            TasksList.Clear();
        }
    }
}
