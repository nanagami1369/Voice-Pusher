using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CommonUILibrary.Models
{
    public class HotKeyRegistry : IHotKeyRegistry
    {
        private static readonly SemaphoreSlim SemaphoreSlim = new SemaphoreSlim(1, 1);

        public HotKeySet Read(string path, Encoding encode)
        {
            //ファイルが存在しない時は、初期値で起動。
            if (!File.Exists(path))
            {
                return new HotKeySet();
            }
            using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            using var reader = new StreamReader(stream, encode);
            var jsonString = reader.ReadToEnd();
            var hotKeys = JsonConvert.DeserializeObject<HotKeySet>(jsonString, new HotKeyConverter());
            return hotKeys;
        }

        public async Task<HotKeySet> ReadAsync(string path, Encoding encode)
        {
            //ファイルが存在しない時は、初期値で起動。
            if (!File.Exists(path))
            {
                return new HotKeySet();
            }

            await SemaphoreSlim.WaitAsync();
            try
            {
                await using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                using var reader = new StreamReader(stream, encode);
                var jsonString = await reader.ReadToEndAsync();
                var hotKeys = JsonConvert.DeserializeObject<HotKeySet>(jsonString, new HotKeyConverter());
                return hotKeys;
            }
            finally
            {
                SemaphoreSlim.Release();
            }
        }

        public async Task WriterAsync(HotKeySet hotKeys, string path, Encoding encode)
        {
            var jsonString = JsonConvert.SerializeObject(hotKeys, Formatting.Indented);
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
