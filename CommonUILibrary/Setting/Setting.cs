using System.Text;
using CommonLibrary.Modules.SettingModule;

namespace CommonUILibrary.Setting
{
    public class Setting : ISetting
    {
        public ICommonSetting Common { get; private set; }
        public IScriptSetting Script { get; private set; }

        public Setting()
        {
            Common = new CommonSetting
            {
                OutPutDirectoryPath = "",
                OutPutTextEncode = new UTF8Encoding(false),
                IsLogWrite = false,
                NameScript = "{Number}_{Name}_{Script}"
            };
            Script = new ScriptSetting {CsvEncode = new UTF8Encoding(false), OutputMode = ScriptOutPutMode.Remake,};
        }
    }
}
