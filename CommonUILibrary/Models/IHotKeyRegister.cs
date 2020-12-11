using System.Text;
using System.Threading.Tasks;

namespace CommonUILibrary.Models
{
    public interface IHotKeyRegistry
    {
        HotKeySet Read(string path, Encoding encode);
        Task<HotKeySet> ReadAsync(string path, Encoding encode);
        Task WriterAsync(HotKeySet hotKeys, string path, Encoding encode);
    }
}
