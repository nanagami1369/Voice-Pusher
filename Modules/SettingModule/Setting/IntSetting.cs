namespace SettingModule.Setting
{
    public class IntSetting : ISetting
    {
        public int Value { get; private set; }

        public string GetSetting() => Value.ToString();

        public void SetSetting(string value) => Value = int.Parse(value);
    }
}
