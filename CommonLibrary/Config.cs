using System.Text;
using CommonLibrary.Modules.MenuModule;

namespace CommonLibrary
{
    public static class Config
    {
        public static string Title = "Voice-Pusher";
        public static readonly string CharacterFileName = "Character.json";
        public static readonly string SettingFileName = "Setting.json";
        public static readonly string HotKeyFileName = "keybindings.json";
        public static readonly string UsedLibraryPath = "License\\License.json";
        public static readonly Encoding ApplicationFileEncode = new UTF8Encoding(false);
        public static readonly string CounterFileName = "count.bin";

        public static readonly MenuItem[] MenuItem = new MenuItem[]
        {
                new MenuItem("ボイスエディタ","CharacterLibraryView", "VolumeUp"),
                new MenuItem("キャラクタエディタ","CharacterLibraryView", "AddressBook"),
                new MenuItem("台本エディタ",string.Empty, "FileAlt"),
                new MenuItem("設定","OtherMenuView", "Cog"),
                new MenuItem("キーボード設定","HotKeyEditorView","Keyboard")
        };
    }
}
