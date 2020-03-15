using System;
using System.Text;
using SettingModule.Setting;

namespace SettingModule
{
    public class CommonSettings
    {
        public StringSetting SaveDirectoryPath { get; } = new StringSetting();
        public EncodingSetting OutPutTextEncode { get; } = new EncodingSetting();
        public BooleanSetting IsLogWrite { get; } = new BooleanSetting();
        public StringSetting NameScript { get; } = new StringSetting();
        public EncodingSetting CsvEncode { get; } = new EncodingSetting();
        public BooleanSetting IsOverwrite { get; } = new BooleanSetting();

        public static CommonSettings CreateDefaultSetting()
        {
            var defaultSetting = new CommonSettings();

            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            var ShiftJisEncoding = Encoding.GetEncoding("Shift_JIS").CodePage.ToString();

            defaultSetting.SaveDirectoryPath.SetSetting(desktopPath);
            defaultSetting.OutPutTextEncode.SetSetting(Encoding.UTF8.CodePage.ToString());
            defaultSetting.IsLogWrite.SetSetting(bool.TrueString);
            defaultSetting.NameScript.SetSetting("{Number}_{Name}_{Script}");
            defaultSetting.CsvEncode.SetSetting(ShiftJisEncoding);
            defaultSetting.IsOverwrite.SetSetting(bool.FalseString);
            return defaultSetting;
        }
    }
}
