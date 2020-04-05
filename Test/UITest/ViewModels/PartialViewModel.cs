using CommonLibrary.Modules.CharacterLibraryModule;
using Prism.Mvvm;
using Prism.Regions;

namespace UITest.ViewModels
{
    public class PartialViewModel : BindableBase, INavigationAware
    {
        private PartialCharacter _selectedCharacter;
        public PartialCharacter SelectedCharacter
        {
            get => _selectedCharacter;
            set => SetProperty(ref _selectedCharacter, value);
        }

        public PartialViewModel()
        {

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return navigationContext.Parameters["CurrentCharacter"] is PartialCharacter;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            SelectedCharacter = null;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {

            if (navigationContext.Parameters["CurrentCharacter"] is PartialCharacter character)
            {
                SelectedCharacter = character;
                RaisePropertyChanged(nameof(SelectedCharacter));
            }
        }
    }
}
