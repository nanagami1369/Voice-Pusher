namespace CommonLibrary.Modules.CharacterLibraryModule
{
    public interface ICharacter
    {
        string Name { get; set; }
        string Reading { get; set; }
        VoiceActor VoiceActor { get; set; }
    }
}
