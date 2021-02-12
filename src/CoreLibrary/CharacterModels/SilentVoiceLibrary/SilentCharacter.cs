using System;
using Newtonsoft.Json;

namespace CoreLibrary.CharacterModels.SilentVoiceLibrary
{
    public class SilentCharacter : Character
    {
        public SilentCharacter(string name, string reading)
        {
            Name = name;
            Reading = reading;
            VoiceActor = new SilentVoiceActor("", "Silent", "0.0");
        }

        [JsonConstructor]
        public SilentCharacter(string name, string reading, SilentVoiceActor voiceActor)
        {
            Name = name;
            Reading = reading;
            VoiceActor = voiceActor;
        }

        public override string ScriptToOutputText(string script)
        {
            throw new NotSupportedException();
        }
    }
}
