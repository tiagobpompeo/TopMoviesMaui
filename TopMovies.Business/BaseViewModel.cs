using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TopMovies.Business
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {

        }

        protected bool SetProperty<T>(ref T backingstore, T value,
            [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingstore, value))
                return false;

            backingstore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changes = PropertyChanged;
            if (changes == null)
            {
                return;
            }

            changes.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
