using System;
using System.Linq;
using CoreLibrary;
using CoreLibrary.CharacterModels.SilentVoiceLibrary;
using CoreLibrary.StatusModels;
using Prism.Commands;
using Prism.Mvvm;

namespace Voice_Pusher.ViewModels
{
    public class DebugViewModel : BindableBase
    {
        private string _message = "";

        private StatusLevel _selectedStatusLevel;

        public DebugViewModel(IDataContainer container)
        {
            _selectedStatusLevel = StatusLevels.First();
            Container = container;
            SendMessageCommand = new DelegateCommand(SendMessage);
            AddCharacterCommand = new DelegateCommand(AddCharacter);
        }

        public IDataContainer Container { get; }

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public DelegateCommand SendMessageCommand { get; }

        public StatusLevel SelectedStatusLevel
        {
            get => _selectedStatusLevel;
            set => SetProperty(ref _selectedStatusLevel, value);
        }

        public StatusLevel[] StatusLevels { get; } =
        {
            StatusLevel.Success, StatusLevel.Log, StatusLevel.Warning, StatusLevel.Error
        };

        public DelegateCommand AddCharacterCommand { get; }

        private void SendMessage()
        {
            Container.CurrentStatus
                = new Status(SelectedStatusLevel, Message);
        }

        private void AddCharacter()
        {
            var rand = new Random(DateTime.Now.Millisecond);
            var character = new SilentCharacter(
                rand.Next(1000).ToString(),
                rand.Next(1000).ToString(),
                new SilentVoiceActor("Silent1", "Silent", "0.0"));
            Container.CharacterLibrary?.AddCharacter(character);
        }
    }
}
