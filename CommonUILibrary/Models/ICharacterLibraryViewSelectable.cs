using CommonLibrary.Modules.CharacterLibraryModule;

namespace CommonUILibrary.Models
{
    public interface ICharacterLibraryViewSelectable
    {
        void SelectVoiceEditorView(Character character);
        void SelectNotSelectCharacterView();
        void SelectCharacterEditorView(Character character);
    }
}
