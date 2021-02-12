namespace CoreLibrary.CharacterModels
{
    public abstract class Character
    {
        public virtual string Name { get; set; } = "";
        public virtual string Reading { get; set; } = "";
        public virtual VoiceActor? VoiceActor { get; set; }

        public abstract string ScriptToOutputText(string script);
    }
}
