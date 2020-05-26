using CommonLibrary.Modules.CharacterLibraryModule;
using CommonLibrary.Modules.MenuModule;

namespace CoreUILibrary.Moc
{
    public class TestViewSelectable : ICharacterLibraryViewSelectable, IMenuViewSelectable
    {
        public ICharacter SetedCharacter { get; private set; }
        public string SelectView { get; private set; }

        public void ChangeContentView(string viewName)
        {
            SelectView = viewName;
        }

        public void SelectNotSelectCharacterView()
        {
            SelectView = "NotSelectCharacterView";
        }

        public void SelectCharacterEditorView(ICharacter character)
        {
            SetedCharacter = character;
            SelectView = "Character";
        }

        public void SelectVoiceEditorView(ICharacter character)
        {
            SetedCharacter = character;
            SelectView = "Voice";
        }
    }
}
