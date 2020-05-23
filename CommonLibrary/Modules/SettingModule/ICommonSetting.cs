using System.Text;

namespace CommonLibrary.Modules.SettingModule
{
    public interface ICommonSetting
    {
        string OutPutDirectoryPath { get; set; }
        Encoding OutPutTextEncode { get; set; }
        bool IsLogWrite { get; set; }
        string NameScript { get; set; }

    }
}
