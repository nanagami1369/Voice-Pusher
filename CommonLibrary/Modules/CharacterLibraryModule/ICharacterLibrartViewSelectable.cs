namespace CommonLibrary.Modules.CharacterLibraryModule
{
    public interface ICharacterLibraryViewSelectable
    {
        void SelectVoiceEditorView(Character character);
        void SelectNotSelectCharacterView();
        void SelectCharacterEditorView(Character character);
    }
}
