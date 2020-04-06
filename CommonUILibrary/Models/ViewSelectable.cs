using CommonLibrary;
using CommonLibrary.Modules.CharacterLibraryModule;
using Prism.Regions;
using System;

namespace CommonUILibrary.Models
{
    public class ViewSelectable : IViewSelectable
    {
        private readonly IRegionManager _regionManager;

        public void SelectVoiceEditorView(ICharacter character)
        {
            var parameters = new NavigationParameters { { "CurrentCharacter", character } };
            _regionManager.RequestNavigate("VoiceEditorRegion", character.VoiceActor.Office + "VoiceEditorView", parameters);
        }

        public void SelectCharacterEditorView(ICharacter character)
        {
            var parameters = new NavigationParameters { { "CurrentCharacter", character } };
            _regionManager.RequestNavigate("CharacterEditorRegion", character.VoiceActor.Office + "CharacterEditorView", parameters);
        }

        public ViewSelectable(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
    }
}
