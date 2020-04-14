using CommonLibrary.Modules.CharacterLibraryModule;
using Prism.Commands;
using Prism.Mvvm;

namespace CoreUILibrary.ViewModels
{
	public class VoiceEditorCharacterLibraryViewModel : BindableBase
	{
		public ICharacterLibraryPresenter CharacterLibrary { get; }

		public DelegateCommand SelectCharacterCommand { get; }

		public DelegateCommand<string> SearchCharacterCommand { get; }

		#region keyboardActions

		public DelegateCommand UpCharacterLibraryCommand { get; }
		public DelegateCommand DownCharacterLibraryCommand { get; }
		public DelegateCommand ResetSelectorCommand { get; }
		public DelegateCommand SetFocusCommand { get; }

		#endregion

		public VoiceEditorCharacterLibraryViewModel(ICharacterLibraryPresenter characterLibrary)
		{
			CharacterLibrary = characterLibrary;
			SelectCharacterCommand = new DelegateCommand(CharacterLibrary.OpenVoiceEditorView);
			SearchCharacterCommand = new DelegateCommand<string>(CharacterLibrary.SearchCharacter);
			UpCharacterLibraryCommand = new DelegateCommand(CharacterLibrary.UpCharacterLibrary);
			DownCharacterLibraryCommand = new DelegateCommand(CharacterLibrary.DownCharacterLibrary);
			ResetSelectorCommand = new DelegateCommand(CharacterLibrary.ResetSelector);
			SetFocusCommand = new DelegateCommand(CharacterLibrary.SetFocus);
		}
	}
}
