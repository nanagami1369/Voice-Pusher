namespace CommonLibrary.Modules.CharacterLibraryModule
{
    public interface ICharacterLibraryViewSelectable
    {
        void SelectVoiceEditorView(ICharacter character);
        void SelectNotSelectCharacterView();
        void SelectCharacterEditorView(ICharacter character);
    }
}
