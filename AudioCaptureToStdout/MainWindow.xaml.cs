using System;
using System.Windows;
using AudioCaptureToStdout.Model;
using AudioCaptureToStdout.Other;
using AudioCaptureToStdout.ViewModel;
using Microsoft.Win32;
using NAudio.Wave;

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

        private void StartStopButtonClick(object sender, RoutedEventArgs e)
        {
            if (IsStartButtonClicked)
            {
                RecordingStart();
            }
            else
            {
                RecordingStop();
            }
        }

        private static IRecording recordingInstance;

        private void RecordingStart()
        {
            recordingInstance = Factory.CreateRecordingInstance(((MainWindowViewModel)DataContext).CaptureMode);

            recordingInstance.RecordingStart("");
            ((MainWindowViewModel)DataContext).StartStopButtonLabel = Constant.StopLabel;
        }

        private void RecordingStop()
        {
            recordingInstance.RecordingStop();
            ((MainWindowViewModel)DataContext).StartStopButtonLabel = Constant.StartLabel;
        }

        /// <summary>
        /// Current Start or Stop State;
        /// </summary>
        public bool IsStartButtonClicked => ((MainWindowViewModel)DataContext).IsStartStopButtonToggled;
    }
}
