using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommonLibrary.Modules.SettingModule;
using Newtonsoft.Json;

namespace CommonUILibrary.Models
{
    public class SettingRegistry : ISettingRegistry
    {
        private static readonly SemaphoreSlim SemaphoreSlim = new SemaphoreSlim(1, 1);

        public ISetting Read(string path, Encoding encode)
        {
            //ファイルが存在しない時は、初期値で起動。
            if (!File.Exists(path))
            {
                return new Setting.Setting();
            }

            using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            using var reader = new StreamReader(stream, encode);
            var jsonString = reader.ReadToEnd();
            var setting = JsonConvert.DeserializeObject<Setting.Setting>(jsonString);
            return setting;
        }

        public async Task<ISetting> ReadAsync(string path, Encoding encode)
        {
            //ファイルが存在しない時は、初期値で起動。
            if (!File.Exists(path))
            {
                return new Setting.Setting();
            }

            await SemaphoreSlim.WaitAsync();
            try
            {
                await using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                using var reader = new StreamReader(stream, encode);
                var jsonString = await reader.ReadToEndAsync();
                var setting = JsonConvert.DeserializeObject<Setting.Setting>(jsonString);
                return setting;
            }
            finally
            {
                SemaphoreSlim.Release();
            }
        }

        public async Task WriterAsync(ISetting setting, string path, Encoding encode)
        {
            var jsonString = JsonConvert.SerializeObject(setting, Formatting.Indented);
            await SemaphoreSlim.WaitAsync();
            try
            {
                await using var stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
                await using var writer = new StreamWriter(stream, encode);
                stream.SetLength(0);
                await writer.WriteAsync(jsonString);
            }
            finally
            {
                SemaphoreSlim.Release();
            }
        }
    }
}
