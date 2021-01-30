namespace CoreLibrary.StatusModels
{
    public class StatusLevel
    {
        private StatusLevel(string text, string colorCode)
        {
            Text = text;
            ColorCode = colorCode;
        }

        public string Text { get; }
        public string ColorCode { get; }

        public static StatusLevel Warning => new("警告", "#FF7F00");

        public static StatusLevel Error => new("エラー", "#FF003F");

        public static StatusLevel Log => new("情報", "#333333");

        public static StatusLevel Success => new("成功", "#008000");
    }
}
