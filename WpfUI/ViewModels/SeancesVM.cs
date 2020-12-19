using Autofac;
using Cinema.BLL.Infrastructure;
using Cinema.BLL.Models;
using Cinema.BLL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfUI.ViewModels
{
    public class SeancesVM : BaseVM
    {
        IContainer container;
        IGenericService<FilmDTO, int> serviceFilm;
        IGenericService<SeanceDTO, int> serviceSeance;
        IGenericService<HallDTO, int> serviceHall;
        private IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<RegisterModule>();
            return builder.Build();
        }
        private ObservableCollection<FilmDTO> _films;
        public ObservableCollection<FilmDTO> Films
        {
            get { return _films; }
            set { _films = value; OnProperty(); }
        }

        private ObservableCollection<SeanceDTO> _seances;
        public ObservableCollection<SeanceDTO> Seances
        {
            get { return _seances; }
            set { _seances = value; OnProperty(); }
        }

        private ObservableCollection<HallDTO> _halls;
        public ObservableCollection<HallDTO> Halls
        {
            get { return _halls; }
            set { _halls = value; OnProperty(); }
        }


        public SeancesVM()
        {
            container = BuildContainer();
            serviceFilm = container.Resolve<IGenericService<FilmDTO, int>>();
            serviceSeance = container.Resolve<IGenericService<SeanceDTO, int>>();
            serviceHall = container.Resolve<IGenericService<HallDTO, int>>();
            //
            Films = new ObservableCollection<FilmDTO>(serviceFilm.GetAll());
            Seances = new ObservableCollection<SeanceDTO>(serviceSeance.GetAll());
            Halls = new ObservableCollection<HallDTO>(serviceHall.GetAll());
            SelectedHall = Halls.FirstOrDefault();
            //





            ShowDateTimeToday();
        }
        #region -selected Hall - выбранный Hall 
        private HallDTO _selectedHall;
        public HallDTO SelectedHall
        {
            get { return _selectedHall; }
            set
            {
                _selectedHall = value;
                //CheckDel = CheckDeleteFunc();
                OnProperty();
            }
        }
        #endregion

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
