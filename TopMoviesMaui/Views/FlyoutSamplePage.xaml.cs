using TopMoviesMaui.Models;

namespace TopMoviesMaui.Views;

public partial class FlyoutSamplePage : FlyoutPage
{
    public FlyoutSamplePage()
    {
        InitializeComponent();

        flyoutPage.collectionViewFlyout.SelectionChanged += OnSelectionChanged;
    }


    void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = e.CurrentSelection.FirstOrDefault() as FlyoutPageItem;
        if (item != null)
        {

            if (!((IFlyoutPageController)this).ShouldShowSplitMode)
                IsPresented = false;

            switch (item.Title)
            {
                case "Up Coming Movies":
                    Detail = new NavigationPage(new UpComingView());
                    break;
            }
        }
    }
}