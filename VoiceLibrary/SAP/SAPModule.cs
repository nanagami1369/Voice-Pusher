using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommonLibrary.Modules.CharacterLibraryModule;
using Prism.Ioc;
using Prism.Modularity;
using SAP.Models;
using Windows.Media.SpeechSynthesis;

namespace SAP
{
    public class SAPModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var gateWay = containerProvider.Resolve<ICharacterLibraryGateway>();
            gateWay.SetDefaultCharacters(
                new Collection<Character>() { new SAPCharacter("Haruka", "はるか", new SAPVoiceActor("Microsoft Haruka", "ja-JP")) });
            var catalog = containerProvider.Resolve<IVoiceActorCatalog>();
            catalog.Register(VoiceActorCatalog);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ITryJsonToCharacterConverter, SAPTryJsonToCharacterConverter>(nameof(SAPTryJsonToCharacterConverter));
        }

        public static List<VoiceActor> VoiceActorCatalog => SpeechSynthesizer
        .AllVoices
        .Where(voice => string.Compare(voice.Language, "ja-JP") == 0)
        .Select(voice => new SAPVoiceActor(voice.DisplayName, voice.Language))
        .Select(actor => (VoiceActor)actor)
        .ToList();
    }
}
