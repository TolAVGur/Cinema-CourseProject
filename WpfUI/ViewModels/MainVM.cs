using Autofac;
using Cinema.BLL.Models;
using Cinema.BLL.Infrastructure;
using System;
//using System.ComponentModel;
using System.Linq;
using Cinema.BLL.Services;
using System.Collections.ObjectModel;
using WpfUI.Services.DialogService;
using WpfUI.Infrastructure;

namespace WpfUI.ViewModels
{
    public class MainVM : BaseVM
    {
        readonly IDialogService dialogService;
        IContainer container;
        //IGenericService<FilmDTO, int> serviceFilm;
        IGenericService<SeanceDTO,int> serviceSeance;
        private ObservableCollection<SeanceDTO> _seances;
        public ObservableCollection<SeanceDTO> Seances
        {
            get { return _seances; }
            set { _seances = value; }
        }
        //private ObservableCollection<FilmDTO> _films;
        //public ObservableCollection<FilmDTO> Films
        //{
        //    get { return _films; }
        //    set { _films = value; OnProperty(); }
        //}



        private IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<RegisterModule>();
            return builder.Build();
        }

        #region -- Конструктор
        public MainVM(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            //
            container = BuildContainer();
            serviceSeance = container.Resolve<IGenericService<SeanceDTO, int>>();
            //serviceFilm = container.Resolve<IGenericService<FilmDTO, int>>();
            Seances = new ObservableCollection<SeanceDTO>(serviceSeance.GetAll().Where(s => s.StartTime >= DateTime.Today));
            //Films = new ObservableCollection<FilmDTO>(serviceFilm.GetAll());

            //
            ShowDateTimeToday();
        }
        #endregion

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
            timer.Tick += (o, t) => { MyDate = $" {DateTime.Today,-20:d} {DateTime.Now:t}"; };
            timer.Start();
        }
        #endregion

        #region -- Команда открытия FilmsWindow

        RelayCommand _openFilmsWindow;

        public RelayCommand OpenFilmsWindow
        {
            get
            {
                if (_openFilmsWindow == null)
                {
                    _openFilmsWindow = new RelayCommand(w =>
                    {
                        FilmsVM filmsVM = new FilmsVM();
                        dialogService.ShowCustomWindow(filmsVM);
                    }, w => true);
                }
                return _openFilmsWindow;
            }
        }
        #endregion

        #region -- Команда открытия EmployesWindow

        RelayCommand _openEmployesWindow;

        public RelayCommand OpenEmployesWindow
        {
            get
            {
                if (_openEmployesWindow == null)
                {
                    _openEmployesWindow = new RelayCommand(w =>
                    {
                        EmployesVM employesVM = new EmployesVM();
                        dialogService.ShowCustomWindow(employesVM);
                    }, w => true);
                }
                return _openEmployesWindow;
            }
        }
        #endregion

        #region -- Команда открытия HallsWindow

        RelayCommand _openHallsWindow;

        public RelayCommand OpenHallsWindow
        {
            get
            {
                if (_openHallsWindow == null)
                {
                    _openHallsWindow = new RelayCommand(w =>
                    {
                        HallsVM hallsVM = new HallsVM();
                        dialogService.ShowCustomWindow(hallsVM);
                    }, w => true);
                }
                return _openHallsWindow;
            }
        }
        #endregion

        #region -- Команда открытия ReportWindow

        RelayCommand _openReportWindow;

        public RelayCommand OpenReportWindow
        {
            get
            {
                if (_openReportWindow == null)
                {
                    _openReportWindow = new RelayCommand(w =>
                    {
                        ReportVM vM = new ReportVM();
                        dialogService.ShowCustomWindow(vM);
                    }, w => true);
                }
                return _openReportWindow;
            }
        }
        #endregion

        #region -- Команда открытия SeancesWindow

        RelayCommand _openSeancesWindow;

        public RelayCommand OpenSeancesWindow
        {
            get
            {
                if (_openSeancesWindow == null)
                {
                    _openSeancesWindow = new RelayCommand(w =>
                    {
                        SeancesVM vM = new SeancesVM();
                        dialogService.ShowCustomWindow(vM);
                    }, w => true);
                }
                return _openSeancesWindow;
            }
        }
        #endregion


    }
}
