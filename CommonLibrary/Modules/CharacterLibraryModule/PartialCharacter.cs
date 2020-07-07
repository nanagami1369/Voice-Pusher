namespace CommonLibrary.Modules.CharacterLibraryModule
{
    public class PartialCharacter : Character
    {
        public PartialCharacter(string name, string reading)
        {
            Name = name;
            Reading = reading;
            VoiceActor = new PartialVoiceActor("", "Partial", 0);
        }
        public PartialCharacter(string name, string reading, PartialVoiceActor voiceActor)
        {
            Name = name;
            Reading = reading;
            VoiceActor = voiceActor;
        }

        //JsonConverter用
        public PartialCharacter()
        {
            Name = string.Empty;
            Reading = string.Empty;
            VoiceActor = new PartialVoiceActor("", "", 0.0f);
        }

        public override string ScriptToOutputText(string script)
        {
            throw new System.NotImplementedException();
        }
    }
}
