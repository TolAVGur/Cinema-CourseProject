using Autofac;
using Cinema.BLL.Models;
using Cinema.BLL.Infrastructure;
using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Linq;
using Cinema.BLL.Services;
using System.Windows;
using System.Collections.ObjectModel;

namespace WpfUI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        IGenericService<SeanceDTO,int> serviceSeance;
        private ObservableCollection<SeanceDTO> _seances;

        #region -- Обработка таймера на гл.окне
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
            timer.Tick += (o, t) => { MyDate = $"Сегодня: {DateTime.Today,-40:d} Время: {DateTime.Now:T}"; };
            timer.Start();
        }
        #endregion

        public MainViewModel()
        {
            IContainer container = BuildContainer();
            serviceSeance = container.Resolve<IGenericService<SeanceDTO, int>>();
            Seances = new ObservableCollection<SeanceDTO>(serviceSeance.GetAll().Where(s => s.StartTime >= DateTime.Today));
            ShowDateTimeToday();
        }

        public ObservableCollection<SeanceDTO> Seances
        {
            get { return _seances; }
            set { _seances = value; }
        }
        //

        private IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<RegisterModule>();
            return builder.Build();
        }

        
    }
}
