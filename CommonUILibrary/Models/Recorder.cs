using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommonLibrary;

namespace CommonUILibrary.Models
{
    public class Recorder : IRecorder
    {
        private static readonly SemaphoreSlim SemaphoreSlim = new SemaphoreSlim(1, 1);

        public async Task RecordingAsync(Voice voice, string baseFileName, string baseDirectoryPath, Encoding encode)
        {
            await SemaphoreSlim.WaitAsync();
            try
            {
                await WriterScriptTextFile(voice, baseFileName, baseDirectoryPath, encode);
                await WriterSpeakWaveFile(voice, baseFileName, baseDirectoryPath);
            }
            finally
            {
                SemaphoreSlim.Release();
            }
        }

        private async Task WriterScriptTextFile(
            Voice voice, string baseFileName, string baseDirectoryPath, Encoding encode)
        {
            var fileName = baseFileName + ".txt";
            var fullName = Path.Combine(baseDirectoryPath, fileName);
            await using var stream = new FileStream(fullName, FileMode.OpenOrCreate, FileAccess.Write);
            await using var writer = new StreamWriter(stream, encode);
            await writer.WriteAsync(voice.Script);
        }

        private async Task WriterSpeakWaveFile(
            Voice voice, string baseFileName, string baseDirectoryPath)
        {
            var fileName = baseFileName + ".wav";
            var fullName = Path.Combine(baseDirectoryPath, fileName);
            await using var stream = new FileStream(fullName, FileMode.OpenOrCreate, FileAccess.Write);
            var voiceData = voice.VoiceData;
            await stream.WriteAsync(voiceData, 0, voiceData.Length);
        }
    }
}
