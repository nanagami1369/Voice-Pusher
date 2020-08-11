using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CommonUILibrary.Setting;

namespace CommonUILibrary.Models
{
    public interface ISettingEditorPresenter
    {
        bool IsEnabled { get; set; }
        List<Encoding> EncodeList { get; }

        string RenamedNameExample { get; }

        string InsertText { get; set; }
        bool InsertMacroSetFlag { get; set; }

        IEnumerable<ScriptOutPutMode> ScriptOutPutModeList { get; }

        Task SelectOutPutDirectoryPathAsync();
        void Naming();
        void AddNameScript(string script);
        Task LoadSettingAsync();
    }
}
