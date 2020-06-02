using System.IO;

namespace CommonLibrary
{
    public interface ISpeaker
    {
        void Play(Stream stream);
        void Play(byte[] voiceData);
        void Play(Voice voice);
    }
}
