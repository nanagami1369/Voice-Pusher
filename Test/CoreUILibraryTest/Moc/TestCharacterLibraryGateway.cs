using System.Collections.Generic;
using CommonLibrary.Modules.CharacterLibraryModule;

namespace CoreUILibrary.Moc
{
    public class TestCharacterLibraryGateway : ICharacterLibraryGateway
    {
        public ICollection<Character> TestLibrary { get; private set; }

        public void SetLibrary(ICollection<Character> library)
        {
            TestLibrary = library;
        }

        public ICollection<Character> Read()
        {
            return TestLibrary;
        }

        public void Write(Character character)
        {
            TestLibrary.Add(character);
        }
    }
}
