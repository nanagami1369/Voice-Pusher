using CommonLibrary.Modules.CharacterLibraryModule;

namespace CommonLibrary
{
    public class Voice
    {
        public string Script { get; } = string.Empty;
        public byte[] VoiceData { get; }
        public Character Character { get; }

        public static Voice Create(Character character, string script, byte[] voiceData)
        {
            return new Voice(character, script, voiceData);
        }

        protected Voice(Character character, string script, byte[] voiceData)
        {
            Character = character;
            Script = script;
            VoiceData = voiceData;
        }
    }
}
