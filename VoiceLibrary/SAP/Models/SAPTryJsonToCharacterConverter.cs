using CommonLibrary.Modules.CharacterLibraryModule;
using Newtonsoft.Json;

namespace SAP.Models
{
    public class SAPTryJsonToCharacterConverter : ITryJsonToCharacterConverter
    {
        public bool TryConvert(string officeName, string json, out Character character)
        {
            if (!(officeName == "SAP"))
            {
                character = null;
                return false;
            }
            character = JsonConvert.DeserializeObject<SAPCharacter>(json);
            return true;
        }
    }
}
