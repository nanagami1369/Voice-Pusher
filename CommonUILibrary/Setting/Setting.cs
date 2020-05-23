using System.Text;
using CommonLibrary.Modules.SettingModule;

namespace CommonUILibrary.Setting
{
    public class Setting : ISetting
    {
        public ICommonSetting Common { get; private set; }
        public IScriptSetting Script { get; private set; }

        public ISetting Copy()
        {
            return new Setting
            {
                Common = new CommonSetting
                {
                    OutPutDirectoryPath = this.Common.OutPutDirectoryPath,
                    OutPutTextEncode = this.Common.OutPutTextEncode,
                    NameScript = this.Common.NameScript,
                    IsLogWrite = this.Common.IsLogWrite
                },
                Script = new ScriptSetting {CsvEncode = this.Script.CsvEncode, OutputMode = this.Script.OutputMode}
            };
        }

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
