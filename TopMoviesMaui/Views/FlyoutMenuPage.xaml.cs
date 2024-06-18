using System.Collections.ObjectModel;
using TopMoviesMaui.Models;

namespace TopMoviesMaui.Views;

public partial class FlyoutMenuPage : ContentPage
{

    ObservableCollection<FlyoutPageItem> flyoutPageItems = new ObservableCollection<FlyoutPageItem>();
    public ObservableCollection<FlyoutPageItem> FlyoutPageItems { get { return flyoutPageItems; } }
    public FlyoutMenuPage()
    {
        InitializeComponent();
        flyoutPageItems.Add(new FlyoutPageItem { Title = "Up Coming Movies", MenuIcon = "home.png" });
        collectionViewFlyout.ItemsSource = flyoutPageItems;
    }
}