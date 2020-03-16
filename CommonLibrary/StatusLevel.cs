using System.Drawing;

namespace CommonLibrary
{
    public class StatusLevel
    {
        public string Text { get; }
        public Color Color { get; }

        public string Show => "【" + Text + "】";

        public static StatusLevel Warning => new StatusLevel("警告", Color.Coral);

        public static StatusLevel Error => new StatusLevel("エラー", Color.Red);

        public static StatusLevel Log => new StatusLevel("情報", Color.Black);

        public static StatusLevel Success => new StatusLevel("成功", Color.DarkGreen);

        private StatusLevel(string text, Color color)
        {
            Text = text;
            Color = color;
        }
    }
}
