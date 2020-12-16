using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfUI.ViewModels
{
    public class BaseVM : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnProperty([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
