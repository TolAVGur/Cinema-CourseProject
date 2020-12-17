using Autofac;
using Cinema.BLL.Infrastructure;
using Cinema.BLL.Models;
using Cinema.BLL.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WpfUI.Infrastructure;
//using WpfUI.Services.DialogService;

namespace WpfUI.ViewModels
{
    public class FilmsVM : BaseVM
    {
        IContainer container;
        IGenericService<FilmDTO, int> serviceFilm;
        IGenericService<SeanceDTO, int> serviceSeance;
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
            set { _seances= value; OnProperty(); }
        }

        #region -selected Film - carrent Film - выбранный Film 
        private FilmDTO _selectedFilm;
        public FilmDTO SelectedFilm
        {
            get { return _selectedFilm; }
            set { _selectedFilm = value;
                CheckDel = CheckDeleteFunc();
                OnProperty(); }
        }
        #endregion

        #region -- Команда - Создать фильм
        public RelayCommand CreateFilm { get; set; }
        private void CreateFilmDTO(object obj)
        {
            SelectedFilm = new FilmDTO { NameFilm = "Введите название фильма...", Description = "введите описание...", Duration = 0 };
            serviceFilm.Update(SelectedFilm);
            Films = new ObservableCollection<FilmDTO>(serviceFilm.GetAll());
            //Films.Add(SelectedFilm);
            SelectedFilm = Films.LastOrDefault();
        }

        #endregion
        #region -- Команда - Удалить фильм

                #region >> проверка на использование id фильма в сеансах
        public bool _checkDel;
        public bool CheckDel
        {
            get => _checkDel;
            set { _checkDel = value; OnProperty(); }
        }

        private bool CheckDeleteFunc()
        {
            int id = SelectedFilm.FilmId;
            int index = Seances.ToList().FindIndex(s => s.FilmId == id);
            return index == -1 ? true : false;
        }
        #endregion
        public RelayCommand DeleteFilm { get; set; }
       

        private void DeleteFilmDTO(object obj)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Удалить?", "Подтвердите удаление!", System.Windows.MessageBoxButton.YesNo);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                serviceFilm.Delete(SelectedFilm.FilmId);
                Films = new ObservableCollection<FilmDTO>(serviceFilm.GetAll());
                SelectedFilm = Films.FirstOrDefault();
            }
        }

        #endregion
        #region -- Команда Сохранить фильм
            public RelayCommand UpdateFilm { get; set; }
        private void UpdateFilmDTO(object obj)
        {
            serviceFilm.Update(SelectedFilm);
            SelectedFilm = Films.FirstOrDefault();
        }
        #endregion

        #region -- Конструктор
        public FilmsVM()
        {
            container = BuildContainer();
            serviceFilm = container.Resolve<IGenericService<FilmDTO, int>>();
            serviceSeance = container.Resolve<IGenericService<SeanceDTO, int>>();
            //
            Films = new ObservableCollection<FilmDTO>(serviceFilm.GetAll());
            Seances = new ObservableCollection<SeanceDTO>(serviceSeance.GetAll());
            SelectedFilm = Films.FirstOrDefault();
            //
            CreateFilm = new RelayCommand(CreateFilmDTO);
            DeleteFilm = new RelayCommand(DeleteFilmDTO);
            UpdateFilm = new RelayCommand(UpdateFilmDTO);
            //
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
