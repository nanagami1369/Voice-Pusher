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

        public IMeunPresenter MeunManager { get; }
        public DelegateCommand ChangeViewCommand { get; }

        public MenuBarViewModel(IMeunPresenter meunManager, IApplicationCommands applicationCommands)
        {
            _applicationCommands = applicationCommands;
            MeunManager = meunManager;
            ChangeViewCommand = new DelegateCommand(MeunManager.ChangeView);
            TryChangeMenuCommand = new DelegateCommand<string?>(TryChageMenu);
            _applicationCommands.SelectMenuCommand.RegisterCommand(TryChangeMenuCommand);
        }

        #region keyboardActions
        public DelegateCommand<string?> TryChangeMenuCommand { get; }

        private void TryChageMenu(string? stringIndex)
        {
            if (int.TryParse(stringIndex, out var index))
            {
                //�L�[�{�[�h�V���[�g�J�b�g�Ŏg���p
                //�͈͊O�̒l�̓V���[�g�J�b�g�����݂��Ȃ������Ȃ̂Ō��ʂ͎擾���Ȃ�
                _ = MeunManager.TryChangeMenu(index);
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
