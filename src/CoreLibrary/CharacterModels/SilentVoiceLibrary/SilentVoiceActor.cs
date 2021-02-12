using Newtonsoft.Json;

namespace CoreLibrary.CharacterModels.SilentVoiceLibrary
{
    public record SilentVoiceActor : VoiceActor
    {
        [JsonConstructor]
        public SilentVoiceActor(string name, string office, string version)
            : base(name, office, version)
        {
        }

        public override string ToString()
        {
            return $"{Name}:{Office}:{Version}";
        }
    }
}
