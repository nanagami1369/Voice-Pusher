using CommonLibrary.Modules.CharacterLibraryModule;

namespace CommonLibrary
{
    public interface IViewSelectable
    {
        void ChangeContentView(string viewName);
        void SelectVoiceEditorView(ICharacter character);
        void SelectCharacterEditorView(ICharacter character);
    }
}
