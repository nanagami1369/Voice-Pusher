using CommonLibrary.Modules.CharacterLibraryModule;

namespace CommonLibrary
{
    public interface IViewSelectable
    {
        void SelectVoiceEditorView(ICharacter character);
        void SelectCharacterEditorView(ICharacter character);
    }
}
