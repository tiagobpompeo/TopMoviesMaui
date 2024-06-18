
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TopMoviesMaui.Services;
using TopMoviesMaui.Services.Navigation;

namespace TopMoviesMaui.ViewModels.Base
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        protected readonly IConnectionService _connectionService;
        protected readonly INavigationService _navigationService;
        protected readonly IDialogService _dialogService;
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;               
            }
        }
    

        public virtual Task InitializeAsync(object data)
        {
            return Task.FromResult(false);
        }

        protected void SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
            {
                return;
            }

            backingField = value;
            
        }

    }
}