﻿using System;
using System.Threading.Tasks;
using TopMoviesMaui.ViewModels.Base;

namespace TopMoviesMaui.Services.Navigation
{
    public interface INavigationService
    {
        Task InitializeAsync();

        Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase;

        Task NavigateToAsync(Type viewModelType);

        Task ClearBackStack();

        Task NavigateToAsync(Type viewModelType, object parameter);

        Task NavigateBackAsync();

        Task RemoveLastFromBackStackAsync();

        Task PopToRootAsync();
    }
}

