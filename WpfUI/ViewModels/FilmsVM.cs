using Autofac;
using Cinema.BLL.Infrastructure;
using Cinema.BLL.Models;
using Cinema.BLL.Services;
using System;
using System.Collections.ObjectModel;

namespace WpfUI.ViewModels
{
    public class FilmsVM : BaseViewModel
    {
        IGenericService<FilmDTO, int> serviceFilms;
        private ObservableCollection<FilmDTO> _films;
        public ObservableCollection<FilmDTO> Films
        {
            get { return _films; }
            set { _films = value; }
        }
        private IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<RegisterModule>();
            return builder.Build();
        }

        public FilmsVM()
        {
            IContainer container = BuildContainer();
            serviceFilms = container.Resolve<IGenericService<FilmDTO, int>>();
            Films = new ObservableCollection<FilmDTO>(serviceFilms.GetAll());
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
            timer.Tick += (o, t) => { MyDate = $"Сегодня: {DateTime.Today,-15:d} Время: {DateTime.Now:T}"; };
            timer.Start();
        }
        #endregion

    }
}
