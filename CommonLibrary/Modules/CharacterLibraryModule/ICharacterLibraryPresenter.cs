﻿using System.Collections.ObjectModel;

namespace CommonLibrary.Modules.CharacterLibraryModule
{
    public interface ICharacterLibraryPresenter
    {
        ObservableCollection<ICharacter> SelectedLibrary { get; set; }

        ICharacter SelectedCharacter { get; set; }

        void SearchCharacter(string query);

        void SelectCharacter();

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
