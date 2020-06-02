using System.IO;
using System.Media;
using CommonLibrary;

namespace CommonUILibrary.Models
{
    public class Speaker : ISpeaker
    {
        public void Play(Stream stream)
        {
            using var sp = new SoundPlayer(stream);
            sp.Play();
        }

        public void Play(byte[] voiceData)
        {
            using var ms = new MemoryStream(voiceData);
            Play(ms);
        }

        public void Play(Voice voice)
        {
            Play(voice.VoiceData);
        }
    }
}
