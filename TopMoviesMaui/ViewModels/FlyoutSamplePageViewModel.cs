using System;
using TopMoviesMaui.ViewModels.Base;

namespace TopMoviesMaui.ViewModels
{
	public class FlyoutSamplePageViewModel : ViewModelBase
    {
        private FlyoutMenuPageViewModel _menuViewModel;

        public FlyoutSamplePageViewModel()
        {
            _menuViewModel = new FlyoutMenuPageViewModel();
        }

        public FlyoutMenuPageViewModel MenuViewModel
        {
            get => _menuViewModel;
            set
            {
                _menuViewModel = value;
                //OnPropertyChanged();
            }
        }

        public override async Task InitializeAsync(object data)
        {
            await Task.WhenAll
            (
                //_menuViewModel.InitializeAsync(data),
                _navigationService.NavigateToAsync<UpComingViewModel>()
            );
        }
    }
}