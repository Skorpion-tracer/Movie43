using System;
using System.ComponentModel;

namespace Movie43.Helper.Converters.ServiceEnum
{
    public class ValueDescription : INotifyPropertyChanged
    {
        public Enum Value { get; set; }
        public string Description { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
