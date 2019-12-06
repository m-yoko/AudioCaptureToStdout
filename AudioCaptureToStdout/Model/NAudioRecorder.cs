using System;
using System.IO;
using NAudio.Wave;

namespace AudioCaptureToStdout.Model
{
    /// <summary>
    /// Utility class to intercept audio from an IWaveProvider and
    /// save it to disk
    /// </summary>
    public class NAudioRecorder : IDisposable, IRecording
    {
        private readonly IWaveIn _captureInstance = new WasapiLoopbackCapture();

        //private readonly Stream _stream = new FileStream(@"D:\test2.wav", FileMode.Create, FileAccess.Write, FileShare.Write);
        //private readonly MemoryStream _stream = new MemoryStream();
        private readonly MemoryStream _stream = new MemoryStream();

        private WaveFileWriter _writer;

        public NAudioRecorder()
        {
            _writer = new WaveFileWriter(_stream, _captureInstance.WaveFormat);
        }

        public void Dispose()
        {
            if (_writer != null)
            {
                _writer.Dispose();
                _writer = null;
                _captureInstance.Dispose();
                _stream.Dispose();
            }
        }

        public void RecordingStart(string outputPath)
        {
            // When the capturer receives audio, start writing the buffer into the mentioned file
            _captureInstance.DataAvailable += (s, a) =>
                {
                    // Write buffer into the file of the writer instance
                    _writer.Write(a.Buffer, 0, a.BytesRecorded);
                };

            //// When the Capturer Stops
            //_captureInstance.RecordingStopped += (s, a) =>
            //    {
            //        _writer.Dispose();
            //        _writer = null;
            //        _captureInstance.Dispose();
            //    };

            // Start audio recording !
            _captureInstance.StartRecording();
        }

        public void RecordingStop()
        {
            _captureInstance.StopRecording();
            using (var fs = new FileStream(@"D:\test.wav", FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                _writer.Flush();
                _stream.Position = 0;

                var aa = new MediaFoundationResampler(new WaveFileReader(_stream), new WaveFormat());
                WaveFileWriter.WriteWavFileToStream(fs, aa);
                fs.Flush();
            }

            Dispose();
        }
    }
}
