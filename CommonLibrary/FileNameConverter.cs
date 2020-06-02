using System;

namespace CommonLibrary.Modules
{
    public class FileNameConverter : IFileNameConverter
    {
        public string Naming(Voice voice, string nameScript, int count = 0)
        {
            if (nameScript == null) {
                nameScript = "";
            }
                var script = voice.ToLineScript();
            if (script.Length > 20)
            {
                script = script.Substring(0, 18) + "...";
            }

            return nameScript
                .Replace("{Number}", count.ToString())
                .Replace("{Name}", voice.Character.Name)
                .Replace("{Script}", script)
                .Replace("{VoiceActorName}", voice.Character.VoiceActor.Name)
                .Replace("{LibraryName}", voice.Character.VoiceActor.Office)
                .Replace("{LibraryVersion}", voice.Character.VoiceActor.Version.ToString())
                .Replace("{yyyy}", DateTime.Now.ToString("yyyy"))
                .Replace("{MM}", DateTime.Now.ToString("MM"))
                .Replace("{dd}", DateTime.Now.ToString("dd"))
                .Replace("{HH}", DateTime.Now.ToString("HH"))
                .Replace("{mm}", DateTime.Now.ToString("mm"))
                .Replace("{ss}", DateTime.Now.ToString("ss"));
        }
    }
}
