using System.Windows;
using WpfUI.Services;
using WpfUI.Services.DialogService;
using WpfUI.ViewModels;

namespace WpfUI
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public DisplayRegistry displayRegistry = new DisplayRegistry();
        MainViewModel mainViewModel;

        public App()
        {
            displayRegistry.RegisterWindowType<MainViewModel, MainWindow>();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var service = new DialogServiceWPF();
            mainViewModel = new MainViewModel(service);
            displayRegistry.ShowModalPresentation(mainViewModel);

            Shutdown();
        }
    }
}
