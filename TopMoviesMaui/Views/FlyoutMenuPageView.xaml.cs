using System.Collections.ObjectModel;
using TopMoviesMaui.Bootstrap;
using TopMoviesMaui.Models;
using TopMoviesMaui.Services.Navigation;
using TopMoviesMaui.ViewModels;

namespace TopMoviesMaui.Views;

public partial class FlyoutMenuPageView : ContentPage
{
    ObservableCollection<FlyoutPageItem> flyoutPageItems = new ObservableCollection<FlyoutPageItem>();
    public ObservableCollection<FlyoutPageItem> FlyoutPageItems { get { return flyoutPageItems; } }

    public FlyoutMenuPageView()
    {
        InitializeComponent();

        switch (Device.RuntimePlatform)
        {
            case Device.iOS:
                this.IconImageSource = "hamburguer.png";
                break;
            case Device.Android:

                break;
            default:
                break;
        }


        flyoutPageItems.Add(new FlyoutPageItem { Title = "Up Coming Movies"});
        collectionViewFlyout.ItemsSource = flyoutPageItems;

    }

    void OnCollectionViewSelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        var navigationService = AppContainer.Resolve<INavigationService>();
        navigationService.NavigateToAsync<UpComingDetailViewModel>();
    }
}