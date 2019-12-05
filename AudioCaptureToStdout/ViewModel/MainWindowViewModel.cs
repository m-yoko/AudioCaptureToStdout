using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Data;

namespace AudioCaptureToStdout.ViewModel
{
    public enum RadioButtonMode
    {
        /// <summary>
        ///     The n audio.
        /// </summary>
        NAudio,

        /// <summary>
        ///     The accord net.
        /// </summary>
        AccordNet
    }

    [ValueConversion(typeof(Enum), typeof(bool))]
    public class RadioButtonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null) return false;

            return value.ToString() == parameter.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null) return Binding.DoNothing;

            if ((bool)value) return Enum.Parse(targetType, parameter.ToString());

            return Binding.DoNothing;
        }
    }

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private RadioButtonMode _captureMode = RadioButtonMode.NAudio;

        private string _outputPath = string.Empty;

        private string _startStopButtonLabel = "Start";

        private bool _isStartStopButtonToggled = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsStartStopButtonToggled
        {
            get => _isStartStopButtonToggled;
            set
            {
                if (value == _isStartStopButtonToggled)
                {
                    return;
                }

                _isStartStopButtonToggled = value;
                RaisePropertyChanged();
            }
        }

        public RadioButtonMode CaptureMode
        {
            get => _captureMode;
            set
            {
                if (value == _captureMode)
                {
                    return;
                }

                _captureMode = value;
                RaisePropertyChanged();
            }
        }

        public string OutputPath
        {
            get => _outputPath;
            set
            {
                if (value == _outputPath)
                {
                    return;
                }

                _outputPath = value;
                RaisePropertyChanged();
            }
        }

        public string StartStopButtonLabel
        {
            get => _startStopButtonLabel;
            set
            {
                if (value == _startStopButtonLabel)
                {
                    return;
                }

                _startStopButtonLabel = value;
                RaisePropertyChanged();
            }
        }

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}