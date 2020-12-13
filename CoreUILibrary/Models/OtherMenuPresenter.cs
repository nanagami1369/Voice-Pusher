using CommonUILibrary.Models;

namespace CoreUILibrary.Models
{
    public class OtherMenuPresenter : IOtherMenuPresenter
    {
        private IOtherMenuViewSelectable _viewSelectable;
        public void SelectAboutView() => _viewSelectable.SelectAboutView();

        public void SelectKeyboardShortcutView() => _viewSelectable.SelectKeyboardShortcutView();

        public void SelectSettingEditorView() => _viewSelectable.SelectSettingEditorView();

        public void SelectUsedLibraryView() => _viewSelectable.SelectUsedLibraryView();

        public void ResetView() => SelectSettingEditorView();

        public OtherMenuPresenter(IOtherMenuViewSelectable viewSelectable)
        {
            _viewSelectable = viewSelectable;

        }
    }
}
