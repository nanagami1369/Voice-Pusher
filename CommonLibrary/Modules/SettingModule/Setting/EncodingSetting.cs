using System.Text;

namespace CommonLibrary.Modules.SettingModule.Setting
{
    public class EncodingSetting : ISetting
    {
        public Encoding Value { get; private set; }

        public string GetSetting() => Value.CodePage.ToString();

        public void SetSetting(string value)
        {
            var encode = Encoding.GetEncoding(int.Parse(value));
            if (encode.CodePage == Encoding.UTF8.CodePage)
            {
                Value = new UTF8Encoding(false);
            }

            Value = encode;
        }
    }
}
