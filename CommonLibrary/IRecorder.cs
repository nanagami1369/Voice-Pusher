using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public interface IRecorder
    {
        Task RecordingAsync(Voice voice, string baseFileName, string baseDirectoryPath, Encoding encode);
    }
}
