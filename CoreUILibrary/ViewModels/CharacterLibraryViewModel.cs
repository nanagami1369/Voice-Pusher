﻿using System;
using CommonLibrary.Modules.CharacterLibraryModule;
using CommonUILibrary.Commands;
using Prism;
using Prism.Commands;
using Prism.Mvvm;

namespace CoreUILibrary.ViewModels
{
    public class CharacterEditorCharacterLibraryViewModel : BindableBase, IActiveAware
    {
        private readonly IApplicationCommands _applicationCommands;

        public ICharacterLibraryPresenter CharacterLibrary { get; }

        public DelegateCommand SelectCharacterCommand { get; }

        public DelegateCommand<string> SearchCharacterCommand { get; }

        #region keyboardActions

        public DelegateCommand UpCharacterLibraryCommand { get; }
        public DelegateCommand DownCharacterLibraryCommand { get; }
        public DelegateCommand ResetSelectorCommand { get; }
        public DelegateCommand SetFocusCommand { get; }

        #endregion

        #region Active

        bool _isActive;
        public bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                OnIsActiveChanged();
            }
        }
        private void OnIsActiveChanged()
        {
            SetFocusCommand.IsActive = IsActive;

            IsActiveChanged?.Invoke(this, new EventArgs());
        }
        public event EventHandler IsActiveChanged;

        #endregion

        public CharacterEditorCharacterLibraryViewModel(
            ICharacterLibraryPresenter characterLibrary,
            IApplicationCommands applicationCommands)
        {
            _applicationCommands = applicationCommands;
            CharacterLibrary = characterLibrary;
            SelectCharacterCommand = new DelegateCommand(CharacterLibrary.OpenCharacterEditorView);
            SearchCharacterCommand = new DelegateCommand<string>(CharacterLibrary.SearchCharacter);
            UpCharacterLibraryCommand = new DelegateCommand(CharacterLibrary.UpCharacterLibrary);
            DownCharacterLibraryCommand = new DelegateCommand(CharacterLibrary.DownCharacterLibrary);
            ResetSelectorCommand = new DelegateCommand(CharacterLibrary.ResetSelector);
            SetFocusCommand = new DelegateCommand(CharacterLibrary.SetFocus);
            _applicationCommands.SetFocusCommand.RegisterCommand(SetFocusCommand);
        }
    }
}
