namespace CommonLibrary.Modules.CharacterLibraryModule
{
    public abstract class Character
    {
        public string Name { get; set; }
        public string Reading { get; set; }
        public VoiceActor VoiceActor { get; set; }

        public abstract string ScriptToOutputText(string script);
    }
}
