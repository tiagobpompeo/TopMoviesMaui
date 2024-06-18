using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.Win32;
using TopMoviesMaui.ViewModels.Base;
using TopMoviesMaui.Bootstrap;
using TopMoviesMaui.ViewModels;
using TopMoviesMaui.Views;
using TopMoviesMaui.Services.Navigation;

namespace TopMoviesMaui.Services
{
    public class NavigationService : INavigationService
    {
        private readonly Dictionary<Type, Type> _mappings;

        protected Application CurrentApplication => Application.Current;

        public NavigationService()
        {
            _mappings = new Dictionary<Type, Type>();
            CreatePageViewModelMappings();
        }

        public async Task InitializeAsync()
        {          
            await NavigateToAsync<UpComingViewModel>();           
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), null);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }

        public Task NavigateToAsync(Type viewModelType)
        {
            return InternalNavigateToAsync(viewModelType, null);
        }

        public async Task ClearBackStack()
        {
            await CurrentApplication.MainPage.Navigation.PopToRootAsync();
        }

        public Task NavigateToAsync(Type viewModelType, object parameter)
        {
            return InternalNavigateToAsync(viewModelType, parameter);
        }

        public async Task NavigateBackAsync()
        {
            if (CurrentApplication.MainPage is FlyoutSamplePageView mainPage)
            {
                await mainPage.Detail.Navigation.PopAsync();
            }
            else if (CurrentApplication.MainPage != null)
            {
                await CurrentApplication.MainPage.Navigation.PopAsync();
            }
        }

        public virtual Task RemoveLastFromBackStackAsync()
        {
            if (CurrentApplication.MainPage is FlyoutSamplePageView mainPage)
            {
                mainPage.Detail.Navigation.RemovePage(
                    mainPage.Detail.Navigation.NavigationStack[mainPage.Detail.Navigation.NavigationStack.Count - 2]);
            }

            return Task.FromResult(true);
        }

        public async Task PopToRootAsync()
        {
            if (CurrentApplication.MainPage is FlyoutSamplePageView mainPage)
            {
                await mainPage.Detail.Navigation.PopToRootAsync();
            }
        }

        protected virtual async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreateAndBindPage(viewModelType, parameter);

            if (page is FlyoutSamplePageView)
            {
                CurrentApplication.MainPage = page;
            }
            //else if (page is LoginView)
            //{
            //    CurrentApplication.MainPage = page;
            //}
            else if (CurrentApplication.MainPage is FlyoutSamplePageView)
            {
                var mainPage = CurrentApplication.MainPage as FlyoutSamplePageView;

                if (mainPage.Detail is TopMoviesMauiNavigationPage navigationPage)
                {
                    var currentPage = navigationPage.CurrentPage;

                    if (currentPage.GetType() != page.GetType())
                    {
                        await navigationPage.PushAsync(page);
                    }
                }
                else
                {
                    navigationPage = new TopMoviesMauiNavigationPage(page);
                    mainPage.Detail = navigationPage;
                }

                mainPage.IsPresented = false;
            }
            else
            {
                var navigationPage = CurrentApplication.MainPage as TopMoviesMauiNavigationPage;

                if (navigationPage != null)
                {
                    await navigationPage.PushAsync(page);
                }
                else
                {
                    CurrentApplication.MainPage = new TopMoviesMauiNavigationPage(page);
                }
            }

            await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);
        }

        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!_mappings.ContainsKey(viewModelType))
            {
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
            }

            return _mappings[viewModelType];
        }

        protected Page CreateAndBindPage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            ViewModelBase viewModel = AppContainer.Resolve(viewModelType) as ViewModelBase;
            page.BindingContext = viewModel;

            return page;
        }

        //map to join VM and VIEW dont need ViewModel Locator others cases is resolve trought Utility.ViewModelLocator
        private void CreatePageViewModelMappings()
        {
            _mappings.Add(typeof(FlyoutMenuPageViewModel), typeof(FlyoutMenuPageView));
            _mappings.Add(typeof(FlyoutSamplePageViewModel), typeof(FlyoutSamplePageView));              
            _mappings.Add(typeof(UpComingViewModel), typeof(UpComingView));
            //others            
        }
    }
}