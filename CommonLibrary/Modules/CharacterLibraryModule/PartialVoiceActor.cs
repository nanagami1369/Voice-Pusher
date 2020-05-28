using System;

namespace CommonLibrary.Modules.CharacterLibraryModule
{
    public class PartialVoiceActor : VoiceActor
    {

        public PartialVoiceActor(string name, string office, float version)
            : base(name, office, version) { }

        public override string ToString() => $"{Name}:{Office}:{Version}";

    }
}
