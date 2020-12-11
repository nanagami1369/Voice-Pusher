using System.Text.RegularExpressions;
using CommonLibrary.Modules.CharacterLibraryModule;

namespace SAP.Models
{
    public class SAPCharacter : Character
    {
        public SAPCharacter(string name, string reading, SAPVoiceActor voiceActor)
        {
            Name = name;
            Reading = reading;
            VoiceActor = voiceActor;
        }

        //JsonConverter用
        public SAPCharacter()
        {
            Name = string.Empty;
            Reading = string.Empty;
            VoiceActor = new SAPVoiceActor("", "");
        }

        public override string ScriptToOutputText(string script)
            => Regex.Replace(script, "<.+?>", string.Empty);
    }
}
