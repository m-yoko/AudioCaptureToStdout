namespace AudioCaptureToStdout.Model
{
    internal interface IRecording
    {
        void RecordingStart(string outputPath);

        void RecordingStop();
    }
}
