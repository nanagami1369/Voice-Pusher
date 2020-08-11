using CommonLibrary;
using CommonUILibrary.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace CoreUILibrary.ViewModels
{
    public class SettingEditorViewModel : BindableBase
    {
        public string Title => Config.Title;

        public ISettingEditorPresenter SettingEditor { get; }

        public DelegateCommand LoadSettingCommand { get; }

        public DelegateCommand SelectOutPutDirectoryPathCommand { get; }

        public DelegateCommand NamingCommand { get; }

        public DelegateCommand<string> AddNameScriptCommand { get; }

        public SettingEditorViewModel(ISettingEditorPresenter settingEditor)
        {
            SettingEditor = settingEditor;
            LoadSettingCommand = new DelegateCommand(
                async () => { await SettingEditor.LoadSettingAsync(); }
            );
            SelectOutPutDirectoryPathCommand = new DelegateCommand(
                async () => { await SettingEditor.SelectOutPutDirectoryPathAsync(); }
            );
            NamingCommand = new DelegateCommand(SettingEditor.Naming);
            AddNameScriptCommand = new DelegateCommand<string>(SettingEditor.AddNameScript);
        }
    }
}
