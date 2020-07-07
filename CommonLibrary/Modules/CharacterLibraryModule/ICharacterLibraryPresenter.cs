using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CommonLibrary.Modules.CharacterLibraryModule
{
    public interface ICharacterLibraryPresenter
    {
        bool IsEnabled { get; set; }

        string SearchWord { get; set; }

        ObservableCollection<Character> SelectedLibrary { get; set; }

        void SearchCharacter(string query);

        void ResetView();

        void OpenEditorView();

        Task LoadCharacterAsync();

        #region keyboardActions

        bool IsFocus { get; set; }
        int Index { get; set; }

        void UpCharacterLibrary();
        void DownCharacterLibrary();
        void ResetSelector();
        void SetFocus();

        #endregion
    }
}
