namespace SettingModule.Setting
{
    public class StringSetting : ISetting
    {
        public string Value { get; private set; }

        public string GetSetting() => Value;

        public void SetSetting(string value) => Value = value;
    }
}
