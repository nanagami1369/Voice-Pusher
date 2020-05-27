namespace CommonLibrary.Modules.CharacterLibraryModule
{
    public class PartialCharacter : Character
    {
        public PartialCharacter(string name, string reading)
        {
            Name = name;
            Reading = reading;
            VoiceActor = new VoiceActor("", "Partial", 0);
        }
        public PartialCharacter(string name, string reading, VoiceActor voiceActor)
        {
            Name = name;
            Reading = reading;
            VoiceActor = voiceActor;
        }
    }
}
