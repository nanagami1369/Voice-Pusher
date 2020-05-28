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
    }
}
