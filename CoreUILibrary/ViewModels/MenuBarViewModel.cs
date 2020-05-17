using System;
using System.Windows.Controls;
using CommonLibrary;
using CommonLibrary.Modules.MenuModule;
using CommonUILibrary.Commands;
using CoreUILibrary.Models;
using Prism;
using Prism.Commands;
using Prism.Mvvm;

namespace CoreUILibrary.ViewModels
{
    public class MenuBarViewModel : BindableBase, IActiveAware
    {
        private readonly IApplicationCommands _applicationCommands;

        public IMenuPresenter MenuManager { get; }
        public DelegateCommand ChangeViewCommand { get; }

        public MenuBarViewModel(IMenuPresenter menuManager, IApplicationCommands applicationCommands)
        {
            _applicationCommands = applicationCommands;
            MenuManager = menuManager;
            ChangeViewCommand = new DelegateCommand(MenuManager.ChangeView);
            TryChangeMenuCommand = new DelegateCommand<string?>(TryChageMenu);
            _applicationCommands.SelectMenuCommand.RegisterCommand(TryChangeMenuCommand);
        }

        #region keyboardActions
        public DelegateCommand<string?> TryChangeMenuCommand { get; }

        private void TryChageMenu(string? stringIndex)
        {
            if (int.TryParse(stringIndex, out var index))
            {
                //キーボードショートカットで使う用
                //範囲外の値はショートカットが存在しないだけなので結果は取得しない
                _ = MenuManager.TryChangeMenu(index);
            }
        }
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
            TryChangeMenuCommand.IsActive = IsActive;

            IsActiveChanged?.Invoke(this, new EventArgs());
        }
        public event EventHandler IsActiveChanged;

        #endregion
    }
}
