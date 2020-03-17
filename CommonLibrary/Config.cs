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
                new MenuItem("ボイスエディタ", "VolumeUp"),
                new MenuItem("キャラクタエディタ", "AddressBookOutline"),
                new MenuItem("台本エディタ", "FileTextOutline"),
                new MenuItem("設定", "Cog")
            };
        }
    }
}
