using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Modalonia.Views
{
    internal class ModalView : UserControl
    {
        public ModalView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
