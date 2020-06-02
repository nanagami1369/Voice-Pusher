using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public interface IRecorder
    {
        Task RecordingAsync(Voice voice, string nameScript, string baseDirectoryPath, Encoding encode);
    }
}
