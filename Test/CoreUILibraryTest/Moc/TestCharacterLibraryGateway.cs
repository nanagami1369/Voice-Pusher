using System.Collections.Generic;
using CommonLibrary.Modules.CharacterLibraryModule;

namespace CoreUILibrary.Moc
{
    public class TestCharacterLibraryGateway : ICharacterLibraryGateway
    {
        public ICollection<ICharacter> TestLibrary { get; private set; }

        public void SetLibrary(ICollection<ICharacter> library)
        {
            TestLibrary = library;
        }

        public ICollection<ICharacter> Read()
        {
            return TestLibrary;
        }

        public void Write(ICharacter character)
        {
            TestLibrary.Add(character);
        }
    }
}
