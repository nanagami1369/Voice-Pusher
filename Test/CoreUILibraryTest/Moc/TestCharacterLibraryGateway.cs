using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLibrary.Modules.CharacterLibraryModule;

namespace CoreUILibrary.Moc
{
    public class TestCharacterLibraryGateway : ICharacterLibraryGateway
    {
        public List<Character> TestLibrary { get; private set; }

        public async Task<ICollection<Character>> ReadAsync()
        {
            return TestLibrary;
        }

        public async Task WriteAsync(ICollection<Character> characters)
        {
            TestLibrary.AddRange(characters);
        }

        public void SetDefaultCharacters(ICollection<Character> characters)
        {
            TestLibrary = characters.ToList();
        }
    }
}
