using System;
using CommonLibrary.Modules.CharacterLibraryModule;

namespace CommonLibrary.Modules
{
    public class FileNameConverter : IFileNameConverter
    {
        public string Naming(Character character, string script, string nameScript, int count = 0)
        {
            if (nameScript == null)
            {
                nameScript = "";
            }
            var lineScript = Voice.ToLineScript(script);
            if (lineScript.Length > 20)
            {
                lineScript = lineScript.Substring(0, 18) + "...";
            }

            return nameScript
                .Replace("{Number}", count.ToString())
                .Replace("{Name}", character.Name)
                .Replace("{Script}", lineScript)
                .Replace("{VoiceActorName}", character.VoiceActor.Name)
                .Replace("{LibraryName}", character.VoiceActor.Office)
                .Replace("{LibraryVersion}", character.VoiceActor.Version.ToString())
                .Replace("{yyyy}", DateTime.Now.ToString("yyyy"))
                .Replace("{MM}", DateTime.Now.ToString("MM"))
                .Replace("{dd}", DateTime.Now.ToString("dd"))
                .Replace("{HH}", DateTime.Now.ToString("HH"))
                .Replace("{mm}", DateTime.Now.ToString("mm"))
                .Replace("{ss}", DateTime.Now.ToString("ss"));
        }
    }
}
