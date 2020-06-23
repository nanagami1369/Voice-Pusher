using System.Collections.Generic;

namespace CommonLibrary.Modules.CharacterLibraryModule
{
    public class VoiceActorCatalog : IVoiceActorCatalog
    {
        private readonly List<VoiceActor> _voiceActors;

        public void Register(List<VoiceActor> voiceActers)
        {
            _voiceActors.AddRange(voiceActers);
        }

        public List<VoiceActor> Read()
        {
            return _voiceActors;
        }


        public VoiceActorCatalog()
        {
            _voiceActors = new List<VoiceActor>();
        }
    }
}
