using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Threading;
using Modalonia.Exceptions;
using Modalonia.Utilities;
using Modalonia.ViewModels;

namespace Modalonia
{
    public static partial class Modal
    {
        private static void SetUpViewModel(string title, object content, ModalButtons buttons)
        {
            var vm = (IModalViewModel)ModalView.DataContext;
            vm.ModalTitle = title;
            vm.ModalContent = content;
            vm.Buttons = buttons;
        }

        private static async Task Show()
        {
            await Dispatcher.UIThread.InvokeAsync(async () =>
            {
                var panel = ApplicationHelpers.GetMainPanel();

                if (!(panel is Grid))
                {
                    throw new ModaloniaException("First control on the main window should be grid.");
                }

                panel.Children.Add(ModalView);
                _open = true;

                // this will make UI responsive
                while (panel.Children.Contains(ModalView)) await Task.Delay(100);
            });
        }
    }
}
