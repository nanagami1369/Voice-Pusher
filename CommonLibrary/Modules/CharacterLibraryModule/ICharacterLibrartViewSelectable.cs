namespace CommonLibrary.Modules.CharacterLibraryModule
{
    public interface ICharacterLibrartViewSelectable
    {
        void SelectVoiceEditorView(ICharacter character);
        void SelectNotSelectCharacterView();
        void SelectCharacterEditorView(ICharacter character);
    }
}
