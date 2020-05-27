using System.Collections.ObjectModel;

namespace CommonLibrary.Modules.CharacterLibraryModule
{
    public interface ICharacterLibraryPresenter
    {
        string SearchWord { get; set; }

        ObservableCollection<Character> SelectedLibrary { get; set; }

        void SearchCharacter(string query);

        void ResetView();

        void OpenEditorView();



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
