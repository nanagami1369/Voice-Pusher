using CommonLibrary;
using CommonUILibrary.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace CoreUILibrary.ViewModels
{
    public class OtherMenuViewModel : BindableBase
    {
        public IOtherMenuPresenter OtherMenu { get; }
        public string Title => Config.Title;

        public DelegateCommand SelectAboutViewCommand { get; }

        public DelegateCommand SelectKeyboardShortcutViewCommand { get; }

        public DelegateCommand SelectSettingEditorViewCommand { get; }

        public DelegateCommand SelectUsedLibraryViewCommand { get; }

        public DelegateCommand ResetViewCommand { get; }

        public OtherMenuViewModel(IOtherMenuPresenter otherMenu)
        {
            OtherMenu = otherMenu;
            SelectAboutViewCommand = new DelegateCommand(OtherMenu.SelectAboutView);
            SelectKeyboardShortcutViewCommand = new DelegateCommand(OtherMenu.SelectKeyboardShortcutView);
            SelectSettingEditorViewCommand = new DelegateCommand(OtherMenu.SelectSettingEditorView);
            SelectUsedLibraryViewCommand = new DelegateCommand(OtherMenu.SelectUsedLibraryView);
            ResetViewCommand = new DelegateCommand(OtherMenu.ResetView);
        }
    }
}
