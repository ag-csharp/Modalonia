namespace Modalonia.ViewModels
{
    internal interface IModalViewModel
    {
        ModalResult CurrentResult { get; }

        object ModalContent { get; set; }

        string ModalTitle { get; set; }

        ModalButtons Buttons { get; set; }
    }
}
