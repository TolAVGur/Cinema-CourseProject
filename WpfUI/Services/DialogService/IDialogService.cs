namespace WpfUI.Services.DialogService
{
    public interface IDialogService
    {
        string FilePath { get; set; }
        bool OpenFileDialog();
        bool SaveFileDialog();

        DialogResult MessageBoxYesNo(string msg, string caption = "");
        /// <summary>
        /// object _ ViewModel
        /// </summary>
        /// <param name="_"></param>

        void ShowCustomWindow(object _); // показ пользовательского окна
    }
}
