using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AndroidX.AppCompat.View.Menu;
using Microsoft.Win32;
using TopMoviesMaui.ViewModels.Base;
using TopMoviesMaui.ViewModels;
using TopMoviesMaui.Views;
using TopMoviesMaui.Services.Navigation;
using AndroidX.Lifecycle;

namespace TopMoviesMaui.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        public Task ClearBackStack()
        {
            throw new NotImplementedException();
        }

        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        public Task NavigateBackAsync()
        {
            throw new NotImplementedException();
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            throw new NotImplementedException();
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            throw new NotImplementedException();
        }

        public Task NavigateToAsync(Type viewModelType)
        {
            throw new NotImplementedException();
        }

        public Task NavigateToAsync(Type viewModelType, object parameter)
        {
            throw new NotImplementedException();
        }

        public Task PopToRootAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveLastFromBackStackAsync()
        {
            throw new NotImplementedException();
        }
    }

    
}