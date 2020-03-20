namespace CommonLibrary.Modules.SettingModule.Setting
{
    public class BooleanSetting : ISetting
    {
        public bool Value { get; private set; }

        public string GetSetting() => Value.ToString();

        public void SetSetting(string value) => Value = bool.Parse(value);
    }
}