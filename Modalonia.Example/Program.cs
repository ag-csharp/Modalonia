using Avalonia;
using Avalonia.Logging.Serilog;

namespace Modalonia.Example
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }

        public static AppBuilder BuildAvaloniaApp()
        {
            return AppBuilder.Configure<App>().UsePlatformDetect().LogToDebug();
        }
    }
}
