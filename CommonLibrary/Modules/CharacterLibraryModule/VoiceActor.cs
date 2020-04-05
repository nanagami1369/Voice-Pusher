using System;

namespace CommonLibrary.Modules.CharacterLibraryModule
{
    public class VoiceActor : IEquatable<VoiceActor>
    {
        public string Name { get; set; }
        public string Office { get; set; }
        public float Version { get; set; }
        public string DisplayName => $"{Name}:{Office}:{Version}";

        public bool Equals(VoiceActor actor)
        {
            return (Name == actor?.Name &&
                    Office == actor?.Office &&
                    Version == actor?.Version);
        }

        public VoiceActor(string name, string office, float version)
        {
            Name = name;
            Office = office;
            Version = version;
        }

    }
}
