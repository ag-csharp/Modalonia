using System.Linq;
using Avalonia.Controls;
using Avalonia.LogicalTree;
using Modalonia.Views;

namespace Modalonia
{
    internal static class ModalAttacher
    {
        private static bool _reserved;
        private static Grid _grid;

        public static void Attach(ModalView modalView)
        {
            var window = ApplicationHelpers.GetMainWindow();
            var firstChild = ApplicationHelpers.GetMainWindow().GetLogicalChildren().FirstOrDefault();

            if (firstChild is Grid grid)
            {
                _reserved = false;
                grid.Children.Add(modalView);

                return;
            }

            if (_grid == null) _grid = new Grid();

            window.Content = null;

            _reserved = true;
            _grid.Children.Add((IControl) firstChild);
            _grid.Children.Add(modalView);

            window.Content = _grid;
        }

        public static void Detach(ModalView view)
        {
            var window = ApplicationHelpers.GetMainWindow();
            var grid = (Grid) ApplicationHelpers.GetMainWindow().GetLogicalChildren().FirstOrDefault();
            
            grid?.Children.Remove(view);

            if (!_reserved) return;

            var originalChild = grid?.Children.FirstOrDefault();

            // this prevent exception: the control already has visual parent
            grid?.Children.Clear();
            window.Content = originalChild;
        }
    }
}
