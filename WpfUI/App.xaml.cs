using System.Windows;
using WpfUI.Services;
using WpfUI.Services.DialogService;
using WpfUI.ViewModels;
using WpfUI.Views;

namespace WpfUI
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public DisplayRegistry displayRegistry = new DisplayRegistry();
        MainVM mainViewModel;

        public App()
        {
            displayRegistry.RegisterWindowType<MainVM, MainWindow>();
            displayRegistry.RegisterWindowType<EmployesVM, EmployesWindow>();
            displayRegistry.RegisterWindowType<FilmsVM, FilmsWindow>();
            displayRegistry.RegisterWindowType<HallsVM, HallsWindow>();
            displayRegistry.RegisterWindowType<ReportVM, ReportWindow>();
            displayRegistry.RegisterWindowType<SeancesVM, SeancesWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var service = new DialogServiceWPF();
            mainViewModel = new MainVM(service);
            displayRegistry.ShowModalPresentation(mainViewModel);

            Shutdown();
        }
    }
}
