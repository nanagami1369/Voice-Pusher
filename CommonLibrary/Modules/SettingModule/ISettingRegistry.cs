using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Modules.SettingModule
{
    public interface ISettingRegistry
    {
        ISetting Read(string path, Encoding encode);
        Task<ISetting> ReadAsync(string path, Encoding encode);
        Task WriterAsync(ISetting setting, string path, Encoding encode);
    }
}
