using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.LogicalTree;

namespace Modalonia.Utilities
{
    internal class ApplicationHelpers
    {
        public static Window GetMainWindow()
        {
            return Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop ? desktop.MainWindow : null;
        }

        public static Panel GetMainPanel()
        {
            return (Panel) GetMainWindow().GetLogicalChildren().FirstOrDefault();
        }
    }
}
