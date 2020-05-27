using System.Collections.Generic;

namespace CommonLibrary.Modules.CharacterLibraryModule
{
    public interface ICharacterLibraryGateway
    {
        ICollection<ICharacter> Read();
        void Write(ICharacter character);
    }
}
