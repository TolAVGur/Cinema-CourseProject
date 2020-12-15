using Autofac;
using Cinema.BLL.Infrastructure;
using Cinema.BLL.Models;
using Cinema.BLL.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using WpfUI.Infrastructure;

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

        #region -selected Film - carrent Film - выбранный Film 
        private FilmDTO _selectedFilm;
        public FilmDTO SelectedFilm
        {
            get { return _selectedFilm; }
            set { _selectedFilm = value; OnProperty(); }
        }
        #endregion

        //#region --Создать фильм

        //public RelayCommand CreateFilm { get; set; }
        //private void CreateFilmDTO(object obj)
        //{
        //    SelectedFilm = new FilmDTO { NameFilm = "Input Name new Film..." };
        //    Films.Add(SelectedFilm);

        //    Films.LastOrDefault();
        //}

        //#endregion

        private IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<RegisterModule>();
            return builder.Build();
        }

        #region -- Конструктор
        public FilmsVM()
        {
            IContainer container = BuildContainer();
            serviceFilms = container.Resolve<IGenericService<FilmDTO, int>>();
            Films = new ObservableCollection<FilmDTO>(serviceFilms.GetAll());
            SelectedFilm = Films.FirstOrDefault();
            ShowDateTimeToday();
            //CreateFilm = new RelayCommand(CreateFilmDTO);
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
            timer.Tick += (o, t) => { MyDate = $"Сегодня: {DateTime.Today,-15:d} Время: {DateTime.Now:T}"; };
            timer.Start();
        }
        #endregion

    }
}
