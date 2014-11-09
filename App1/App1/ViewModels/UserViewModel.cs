using System;
using System.Collections.Generic;
using System.Text;
using Xamarin;
using Xamarin.Forms;
using System.ComponentModel;

namespace App1.ViewModels
{
    class UserViewModel : INotifyPropertyChanged // System.ComponentModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _firstName = string.Empty;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
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
