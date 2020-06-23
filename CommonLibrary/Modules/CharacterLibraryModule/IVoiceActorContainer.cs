using System.Collections.Generic;

namespace CommonLibrary.Modules.CharacterLibraryModule
{
    public interface IVoiceActorCatalog
    {
        void Register(List<VoiceActor> voiceActers);

        List<VoiceActor> Read();
    }
}
