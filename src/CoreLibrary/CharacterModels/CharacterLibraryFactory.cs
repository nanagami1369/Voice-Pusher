using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CoreLibrary.CharacterModels
{
    public class CharacterLibraryFactory
    {
        private readonly CharacterRepository CharacterRepository = new(Config.CharactersFileName);
        private readonly List<Character> DefaultCharacters = new();
        private readonly List<string> LibraryNames = new();
        private readonly List<VoiceActor> VoiceActors = new();

        public void RegisterVoiceLibrary<CharacterType>(
            string name,
            IEnumerable<VoiceActor> voiceActors,
            IEnumerable<Character> defaultCharacters) where CharacterType : Character
        {
            LibraryNames.Add(name);
            VoiceActors.AddRange(voiceActors);
            DefaultCharacters.AddRange(defaultCharacters);
            CharacterRepository.RegisterCharacterJsonConverter<CharacterType>(name);
        }

        public async Task<CharacterLibrary> CreateLibraryAsync()
        {
            var repository = new CharacterRepository(Config.CharactersFileName);
            if (!File.Exists(repository.FullPath))
            {
                return new CharacterLibrary(repository, VoiceActors, DefaultCharacters);
            }

            var readedCharacters = await repository.ReadAsync();
            return new CharacterLibrary(repository, VoiceActors, readedCharacters!);
        }
    }
}
