using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CommonLibrary;
using CommonLibrary.Modules.CharacterLibraryModule;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Unity;

namespace CommonUILibrary.Models
{
    public class CharacterLibraryGateway : ICharacterLibraryGateway
    {
        private readonly IUnityContainer _unityContainer;

        private static readonly SemaphoreSlim SemaphoreSlim = new SemaphoreSlim(1, 1);

        private List<Character> DefaultCharacters { get; } = new List<Character>();

        public void SetDefaultCharacters(ICollection<Character> characters)
        {
            DefaultCharacters.AddRange(characters);
        }

        public async Task<ICollection<Character>> ReadAsync()
        {

            if (!File.Exists(Config.CharacterFileName))
            {
                //await WriteAsync(DefaultCharacters);
                return DefaultCharacters;
            }
            await SemaphoreSlim.WaitAsync();
            try
            {
                using var stream = new FileStream(Config.CharacterFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                using var reader = new StreamReader(stream, Config.ApplicationFileEncode);
                var jsonString = reader.ReadToEnd();
                var charactersObj = JsonConvert.DeserializeObject<ICollection<object>>(jsonString);
                return charactersObj.Select(obj => Converter(obj)).ToArray();
            }
            finally
            {
                SemaphoreSlim.Release();
            }

        }

        public async Task WriteAsync(ICollection<Character> characters)
        {
            var charactersString = JsonConvert.SerializeObject(characters, Formatting.Indented);
            await SemaphoreSlim.WaitAsync();
            try
            {
                await using var stream = new FileStream(Config.CharacterFileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
                await using var writer = new StreamWriter(stream, Config.ApplicationFileEncode);
                stream.SetLength(0);
                await writer.WriteAsync(charactersString);
            }
            finally
            {
                SemaphoreSlim.Release();
            }
        }

        private Character Converter(object obj)
        {
            var jObject = (JObject)obj;
            var officeName = (string)jObject["Office"];

            var converters = _unityContainer.ResolveAll<ITryJsonToCharacterConverter>();
            foreach (var converter in converters)
            {
                if (converter.TryConvert(officeName, obj.ToString(), out var character))
                {
                    return character;
                }
            }
            throw new NotSupportedException($"このキャラクターは読み込めません");
        }

        public CharacterLibraryGateway(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }
    }
}
