using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace CoreLibrary.CharacterModels
{
    public class CharacterLibrary : BindableBase, ICharacterLibrary
    {
        private ObservableCollection<Character> _originalLibrary = new();

        public CharacterLibrary(
            CharacterRepository repository,
            IEnumerable<VoiceActor> voiceActors,
            IEnumerable<Character> characters)
        {
            Repository = repository;
            VoiceActors = voiceActors.ToArray();
            OriginalLibrary = new ObservableCollection<Character>(characters);
        }

        public CharacterRepository Repository { get; }
        public VoiceActor[] VoiceActors { get; }

        public ObservableCollection<Character> OriginalLibrary
        {
            get => _originalLibrary;
            set => SetProperty(ref _originalLibrary, value);
        }

        public void AddCharacter(Character character)
        {
            OriginalLibrary.Add(character);
        }

        public async Task ReadCharacterLibraryAsync()
        {
            var library = await Repository.ReadAsync();
            OriginalLibrary = new ObservableCollection<Character>(library);
        }

        public async Task WriterCharacterLibraryAsync()
        {
            await Repository.WriterAsync(OriginalLibrary.ToArray());
        }
    }
}
