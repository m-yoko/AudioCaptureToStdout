using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioCaptureToStdout.ViewModel;

namespace AudioCaptureToStdout.Model
{
    internal static class Factory
    {
        public static IRecording CreateRecordingInstance(RadioButtonMode radioButtonMode)
        {
            IRecording recording = null;
            switch (radioButtonMode)
            {
                case RadioButtonMode.NAudio:
                    recording = new NAudioRecorder();
                    break;

                case RadioButtonMode.AccordNet:
                    break;

                default:
                    break;
            }

            return recording;
        }
    }
}
