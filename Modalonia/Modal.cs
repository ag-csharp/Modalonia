using System.Threading.Tasks;
using Avalonia.Threading;
using Modalonia.ViewModels;
using Modalonia.Views;

namespace Modalonia
{
    /// <summary>
    /// Modalonia centralized class.
    /// </summary>
    public static class Modal
    {
        private static readonly ModalView ModalView = new ModalView { DataContext = new ModalViewModel() };
        private static bool _open;

        /// <summary>
        /// Shows the modal to the main window with no buttons.
        /// </summary>
        /// <param name="title">Modal title.</param>
        /// <param name="content">Modal content.</param>
        /// <returns>Modal dialog result.</returns>
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
        public static async Task<ModalResult> Show(string title, object content, ModalButtons buttons)
        {
            await WaitForClose();

            _open = true;
            SetUpViewModel(title, content, buttons);

            await Dispatcher.UIThread.InvokeAsync(async () =>
            {
                ModalAttacher.Attach(ModalView);
                await WaitForClose();
            });

            return ((IModalViewModel) ModalView.DataContext).CurrentResult;
        }

        /// <summary>
        /// Closes current open modal.
        /// </summary>
        public static void Close()
        {
            if (!_open) return;

            Dispatcher.UIThread.Post(() => ModalAttacher.Detach(ModalView));
            _open = false;
        }

        private static void SetUpViewModel(string title, object content, ModalButtons buttons)
        {
            var vm = (IModalViewModel) ModalView.DataContext;
            vm.ModalTitle = title;
            vm.ModalContent = content;
            vm.Buttons = buttons;
        }

        private static async Task WaitForClose()
        {
            while (_open) await Task.Delay(100);
        }
    }
}
