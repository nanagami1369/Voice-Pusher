using CommonLibrary.Modules.MenuModule;

namespace CommonLibrary
{
    public static class Config
    {
        public static string Title = "Voice-Pusher";

        public static readonly MenuItem[] MenuItem;

        static Config()
        {
            MenuItem = new MenuItem[]
            {
                new MenuItem("ボイスエディタ","VoiceEditorCharacterLibraryView", "VolumeUp"),
                new MenuItem("キャラクタエディタ","CharacterEditorCharacterLibraryView", "AddressBook"),
                new MenuItem("台本エディタ",string.Empty, "FileAlt"),
                new MenuItem("設定",string.Empty, "Cog")
            };
        }
    }
}
