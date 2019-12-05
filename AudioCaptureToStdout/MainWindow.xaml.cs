using System.Windows;
using AudioCaptureToStdout.ViewModel;
using Microsoft.Win32;

namespace AudioCaptureToStdout
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void StateModeChange()
        {
            var txt = string.Empty;
            if (((MainWindowViewModel)DataContext).IsStartStopButtonToggled)
            {
                txt = "Stop";
            }
            else
            {
                txt = "Start";
            }
            ((MainWindowViewModel)DataContext).StartStopButtonLabel = txt;
        }

        private void StartStopButtonClick(object sender, RoutedEventArgs e)
        {
            StateModeChange();
        }

        private void SaveAsButtonClick(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "All files|*.*";
            dialog.FilterIndex = 1;
            dialog.Title = "Save as";
            var result = dialog.ShowDialog();
            if (result == true)
            {
                ((MainWindowViewModel)DataContext).OutputPath = dialog.FileName;
            }
        }
    }
}
