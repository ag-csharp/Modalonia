using System.Threading.Tasks;
using Modalonia.Exceptions;
using Modalonia.Utilities;
using Modalonia.ViewModels;
using Modalonia.Views;

namespace Modalonia
{
    /// <summary>
    /// Modalonia centralized class.
    /// </summary>
    public static partial class Modal
    {
        private static readonly ModalView ModalView = new ModalView { DataContext = new ModalViewModel() };
        private static bool _open;

        /// <summary>
        /// Shows the modal to the main window with no buttons.
        /// </summary>
        /// <param name="title">Modal title.</param>
        /// <param name="content">Modal content.</param>
        /// <returns>Modal dialog result.</returns>
        /// <exception cref="ModaloniaException">
        /// Thrown when;
        /// - modal is already opens
        /// - unable to find parent grid
        /// </exception>
        public static async Task<ModalResult> Show(string title, object content)
        {
            return await Show(title, content, ModalButtons.None);
        }

        /// <summary>
        /// Shows the modal to the main window.
        /// </summary>
        /// <param name="title">Modal title.</param>
        /// <param name="content">Modal content.</param>
        /// <param name="buttons">Modal buttons to be shown.</param>
        /// <returns>Modal dialog result.</returns>
        /// <exception cref="ModaloniaException">
        /// Thrown when;
        /// - modal is already opens
        /// - unable to find parent grid
        /// </exception>
        public static async Task<ModalResult> Show(string title, object content, ModalButtons buttons)
        {
            if (_open) throw new ModaloniaException("Modal is already opens.");

            SetUpViewModel(title, content, buttons);
            await Show();

            return ((IModalViewModel) ModalView.DataContext).CurrentResult;
        }

        /// <summary>
        /// Close current open modal.
        /// </summary>
        public static void Close()
        {
            if (!_open) return;
            
            var panel = ApplicationHelpers.GetMainPanel();
            panel.Children.Remove(ModalView);

            _open = false;
        }
    }
}
