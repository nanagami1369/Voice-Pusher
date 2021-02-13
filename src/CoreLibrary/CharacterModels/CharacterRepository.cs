using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLibrary.CharacterModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CoreLibrary
{
    public class CharacterRepository : FileRepository<Character[]>
    {
        private readonly List<ICharacterJsonConverter> Converters = new();

        public CharacterRepository(string fileName) : base(fileName)
        {
            ObjectArrayRepository = new JsonRepository<object[]>(fileName);
            CharacterArrayRepository = new JsonRepository<Character[]>(fileName);
        }

        private FileRepository<object[]> ObjectArrayRepository { get; }

        private FileRepository<Character[]> CharacterArrayRepository { get; }

        public override async Task<Character[]> ReadAsync()
        {
            var characterObjects = await ObjectArrayRepository.ReadAsync();
            if (characterObjects is not null)
            {
                return characterObjects.Select(Converter).Where(x => x is not null).ToArray()!;
            }

            return Array.Empty<Character>();
        }

        public void RegisterCharacterJsonConverter<CharacterType>(string libraryName) where CharacterType : Character
        {
            Converters.Add(new CharacterJsonConverter<CharacterType>(libraryName));
        }

        private Character? Converter(object obj)
        {
            var jObject = (JObject)obj;
            var officeName = (string?)jObject[nameof(Character.VoiceActor)]?[nameof(VoiceActor.Office)];
            if (string.IsNullOrEmpty(officeName))
            {
                return null;
            }

            foreach (var converter in Converters)
            {
                if (converter.TryConvert(officeName, obj?.ToString() ?? "", out var character))
                {
                    return character;
                }
            }

            throw new NotSupportedException("このキャラクターは読み込めません");
        }

        public override async Task WriterAsync(Character[] saveObject)
        {
            await CharacterArrayRepository.WriterAsync(saveObject);
        }

        #region CharacterJsonConverter

        private interface ICharacterJsonConverter
        {
            bool TryConvert(string officeName, string json, out Character? character);
        }

        private class CharacterJsonConverter<T> : ICharacterJsonConverter where T : Character
        {
            public CharacterJsonConverter(string libraryName)
            {
                LibraryName = libraryName;
            }

            private string LibraryName { get; }

            public bool TryConvert(string officeName, string json, out Character? character)
            {
                if (!(officeName == LibraryName))
                {
                    character = null;
                    return false;
                }

                character = JsonConvert.DeserializeObject<T>(json);
                return true;
            }
        }

        #endregion
    }
}
