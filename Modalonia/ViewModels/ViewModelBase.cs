using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Modalonia.ViewModels
{
    internal abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string name = "")
        {
            if (Equals(storage, value)) return false;

            storage = value;
            OnPropertyChanged(name);

            return true;
        }
    }
}