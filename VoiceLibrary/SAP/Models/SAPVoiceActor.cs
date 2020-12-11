using CommonLibrary.Modules.CharacterLibraryModule;

namespace SAP.Models
{
    public class SAPVoiceActor : VoiceActor
    {
        public string Language { get; set; }
        public SAPVoiceActor(string name, string language) : base(name, "SAP", 0)
        {
            Language = language;
        }

        public override string ToString() => $"{Name} ({Language})";
    }
}
