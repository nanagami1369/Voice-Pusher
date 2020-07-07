using CommonLibrary.Modules.CharacterLibraryModule;
using Newtonsoft.Json;

namespace CommonUILibrary.Models
{
    public class PartialTryJsonToCharacter : ITryJsonToCharacterConverter
    {

        public bool TryConvert(string officeName, string json, out Character character)
        {
            if (!(officeName == "Partial"))
            {
                character = null;
                return false;
            }
            character = JsonConvert.DeserializeObject<PartialCharacter>(json);
            return true;
        }

    }
}
