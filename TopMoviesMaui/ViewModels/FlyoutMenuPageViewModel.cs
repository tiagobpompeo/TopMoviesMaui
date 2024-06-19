using System;

using System.Collections.ObjectModel;
using System.Windows.Input;
using TopMoviesMaui.ViewModels.Base;
using TopMoviesMaui.Models;

namespace TopMoviesMaui.ViewModels
{
	public class FlyoutMenuPageViewModel:ViewModelBase
    {
        private ObservableCollection<MainMenuItem> _menuItems;
   
        public FlyoutMenuPageViewModel()
        {
            MenuItems = new ObservableCollection<MainMenuItem>();
            LoadMenuItems();
        }

        public string WelcomeText => "Hello ";

        public ICommand MenuItemTappedCommand => new Command(OnMenuItemTapped);

        public ObservableCollection<MainMenuItem> MenuItems { get; set; }
       
        private void OnMenuItemTapped(object menuItemTappedEventArgs)
        {
            var menuItem = ((menuItemTappedEventArgs as ItemTappedEventArgs)?.Item as MainMenuItem);

            if (menuItem != null && menuItem.MenuText == "Log out")
            {
                _navigationService.ClearBackStack();
            }

            var type = menuItem?.ViewModelToLoad;
            _navigationService.NavigateToAsync(type);
        }

        private void LoadMenuItems()
        {
            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Upcoming",
                ViewModelToLoad = typeof(UpComingViewModel),
                MenuItemType = MenuItemType.MainPage
            });

         

        }
    }
}