using System;

namespace CommonLibrary.Modules.CharacterLibraryModule
{
    public abstract class VoiceActor : IEquatable<VoiceActor>
    {
        public string Name { get; set; }
        public string Office { get; set; }
        public float Version { get; set; }

        // ディスプレイの表示をカスタマイズする
        public abstract override string ToString();

        protected VoiceActor(string name, string office, float version)
        {
            Name = name;
            Office = office;
            Version = version;
        }

        public bool Equals(VoiceActor actor)
        {
            return (Name == actor?.Name &&
                    Office == actor?.Office &&
                    Version == actor?.Version);
        }

    }
}
