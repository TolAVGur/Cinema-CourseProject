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
        IContainer container;
        IGenericService<FilmDTO, int> service;
        
        
        private ObservableCollection<FilmDTO> _films;
        public ObservableCollection<FilmDTO> Films
        {
            get { return _films; }
            set { _films = value; OnProperty(); }
        }

        #region -selected Film - carrent Film - выбранный Film 
        private FilmDTO _selectedFilm;
        public FilmDTO SelectedFilm
        {
            get { return _selectedFilm; }
            set { _selectedFilm = value; OnProperty(); }
        }
        #endregion

        #region -- Команда - Создать фильм

        public RelayCommand CreateFilm { get; set; }
        private void CreateFilmDTO(object obj)
        {
            SelectedFilm = new FilmDTO { NameFilm = "Введите название фильма...", Description = "введите описание...", Duration = 0 };
            service.Add(SelectedFilm);
            Films = new ObservableCollection<FilmDTO>(service.GetAll());
            SelectedFilm = Films.LastOrDefault();
        }

        #endregion
        #region -- Команда - Удалить фильм

        public RelayCommand DeleteFilm { get; set; }
        private void DeleteFilmDTO(object obj)
        {
            // Добавить проверку не используется ли айдишник в будущих сеансах,
            // Если да = ? да : нет
            service.Delete(SelectedFilm.FilmId);
            Films = new ObservableCollection<FilmDTO>(service.GetAll());
            SelectedFilm = Films.FirstOrDefault();
        }

        #endregion
        private IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<RegisterModule>();
            return builder.Build();
        }

        #region -- Конструктор
        public FilmsVM()
        {
            container = BuildContainer();
            service = container.Resolve<IGenericService<FilmDTO, int>>();

            Films = new ObservableCollection<FilmDTO>(service.GetAll());
            SelectedFilm = Films.FirstOrDefault();
            CreateFilm = new RelayCommand(CreateFilmDTO);
            DeleteFilm = new RelayCommand(DeleteFilmDTO);




            ShowDateTimeToday();
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
