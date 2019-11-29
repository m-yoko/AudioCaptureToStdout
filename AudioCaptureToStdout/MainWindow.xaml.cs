using System.Diagnostics;
using System.Windows;

namespace AudioCaptureToStdout
{
    public enum RadioButtonMode
    {
        NAudio,
        AccordNet
    }

    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartStopButtonClick(object sender, RoutedEventArgs e)
        {
            foreach (System.Windows.Controls.RadioButton rButton in radioButtonStackPannel.Children)
            {
                Debug.WriteLine(rButton.ToString());
            }
        }
    }
}
