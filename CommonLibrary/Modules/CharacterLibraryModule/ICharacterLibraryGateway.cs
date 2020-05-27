using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommonLibrary.Modules.CharacterLibraryModule
{
    public interface ICharacterLibraryGateway
    {
        ICollection<Character> Read();
        void Write(Character character);
    }
}
