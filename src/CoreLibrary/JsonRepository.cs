using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CoreLibrary
{
    public class JsonRepository<T> : FileRepository<T>, IRepository<T>
    {
        private static readonly SemaphoreSlim _semaphoreSlim = new(1, 1);


        public JsonRepository(string fileName) : base(fileName) { }

        public override async Task<T> ReadAsync()
        {
            if (!File.Exists(FullPath))
            {
                throw new FileNotFoundException("ファイルが見つかりませんでした", FileName);
            }

            await _semaphoreSlim.WaitAsync();
            try
            {
                await using var stream = new FileStream(FullPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                using var reader = new StreamReader(stream, Encode);
                var jsonString = await reader.ReadToEndAsync();
                var item = JsonConvert.DeserializeObject<T>(jsonString);
                return item;
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        public override async Task WriterAsync(T saveObject)
        {
            await _semaphoreSlim.WaitAsync();
            try
            {
                var jsonString = JsonConvert.SerializeObject(saveObject, Formatting.Indented);
                await using var stream = new FileStream(FullPath, FileMode.Create, FileAccess.Write, FileShare.Read);
                await using var writer = new StreamWriter(stream, Encode);
                stream.SetLength(0);
                await writer.WriteAsync(jsonString);
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }
    }
}
