using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfUI.ViewModels
{
    public class SeancesVM : BaseVM
    {



        public SeancesVM()
        {
            ShowDateTimeToday();
        }

        #region -- Обработка таймера - отображение времени
        private string _myDate;
        public string MyDate
        {
            get { return _myDate; }
            set { _myDate = value; OnProperty(); }
        }
        private void ShowDateTimeToday()
        {
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.IsEnabled = true;
            timer.Tick += (o, t) => { MyDate = $"{DateTime.Today,-20:d} {DateTime.Now:t}"; };
            timer.Start();
        }
        #endregion
    }
}
