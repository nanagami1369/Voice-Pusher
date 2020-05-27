namespace CommonLibrary.Modules.StatusModule
{
    public class StatusLevel
    {
        public string Text { get; }
        public string ColorCode { get; }

        public string Show => "【" + Text + "】";

        public static StatusLevel Warning => new StatusLevel("警告", "#FF7F00");

        public static StatusLevel Error => new StatusLevel("エラー", "#FF003F");

        public static StatusLevel Log => new StatusLevel("情報", "#333333");

        public static StatusLevel Success => new StatusLevel("成功", "#008000");

        private StatusLevel(string text, string colorCode)
        {
            Text = text;
            ColorCode = colorCode;
        }
    }
}
