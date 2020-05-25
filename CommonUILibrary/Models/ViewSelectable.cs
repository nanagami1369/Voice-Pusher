using CommonLibrary;
using CommonLibrary.Modules.CharacterLibraryModule;
using Prism.Regions;

namespace CommonUILibrary.Models
{
    public class ViewSelectable : IViewSelectable
    {
        private readonly IRegionManager _regionManager;

        public void SelectVoiceEditorView(ICharacter character)
        {
            var parameters = new NavigationParameters { { "CurrentCharacter", character } };
            _regionManager.RequestNavigate("EditorRegion", character.VoiceActor.Office + "VoiceEditorView", parameters);
        }

        public void SelectNotSelectCharacterView()
        {
            _regionManager.RequestNavigate("EditorRegion", "NotSelectCharacterView");
        }

        public void SelectCharacterEditorView(ICharacter character)
        {
            var parameters = new NavigationParameters { { "CurrentCharacter", character } };
            _regionManager.RequestNavigate("EditorRegion", character.VoiceActor.Office + "CharacterEditorView", parameters);
        }

        public void ChangeContentView(string viewName)
        {
            _regionManager.RequestNavigate("ContentRegion", viewName);
        }

        public ViewSelectable(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
    }
}
