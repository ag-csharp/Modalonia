using System.Windows.Input;
using Modalonia.Commands;

namespace Modalonia.ViewModels
{
    internal class ModalViewModel : ViewModelBase, IModalViewModel
    {
        private object _modalContent;
        private string _modalTitle;
        private ModalButtons _buttons;
        private bool _hasButtons;
        private bool _withYesButton;
        private bool _withNoButton;
        private bool _withOkButton;
        private bool _withCancelButton;

        public ModalViewModel()
        {
            CloseCommand = new RelayCommand(() => CloseAndSetResult(ModalResult.None));
            YesCommand = new RelayCommand(() => CloseAndSetResult(ModalResult.Yes));
            NoCommand = new RelayCommand(() => CloseAndSetResult(ModalResult.No));
            OkCommand = new RelayCommand(() => CloseAndSetResult(ModalResult.Ok));
            CancelCommand = new RelayCommand(() => CloseAndSetResult(ModalResult.Cancel));
        }

        public ModalResult CurrentResult { get; private set; }

        public object ModalContent
        {
            get => _modalContent;
            set => SetProperty(ref _modalContent, value);
        }

        public string ModalTitle
        {
            get => _modalTitle;
            set => SetProperty(ref _modalTitle, value);
        }

        public ModalButtons Buttons
        {
            get => _buttons;
            set
            {
                SetProperty(ref _buttons, value);
                SetButtonsVisibility(value);
            }
        }

        public bool HasButtons
        {
            get => _hasButtons;
            private set => SetProperty(ref _hasButtons, value);
        }

        public bool WithYesButton
        {
            get => _withYesButton;
            private set => SetProperty(ref _withYesButton, value);
        }

        public bool WithNoButton
        {
            get => _withNoButton;
            private set => SetProperty(ref _withNoButton, value);
        }

        public bool WithOkButton
        {
            get => _withOkButton;
            private set => SetProperty(ref _withOkButton, value);
        }

        public bool WithCancelButton
        {
            get => _withCancelButton;
            private set => SetProperty(ref _withCancelButton, value);
        }

        public ICommand CloseCommand { get; }

        public ICommand YesCommand { get; }

        public ICommand NoCommand { get; }

        public ICommand OkCommand { get; }

        public ICommand CancelCommand { get; }

        private void CloseAndSetResult(ModalResult result)
        {
            CurrentResult = result;
            Modal.Close();
        }

        private void SetButtonsVisibility(ModalButtons value)
        {
            HasButtons = value != ModalButtons.None;
            WithYesButton = WithNoButton = value == ModalButtons.YesNo;
            WithOkButton = value == ModalButtons.Ok || value == ModalButtons.OkCancel;
            WithCancelButton = value == ModalButtons.OkCancel;
        }
    }
}
