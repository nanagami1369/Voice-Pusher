using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommonLibrary.Modules.CharacterLibraryModule
{
    public interface ICharacterLibraryGateway
    {
        void SetDefaultCharacters(ICollection<Character> characters);

        Task<ICollection<Character>> ReadAsync();
        Task WriteAsync(ICollection<Character> characters);
    }
}
