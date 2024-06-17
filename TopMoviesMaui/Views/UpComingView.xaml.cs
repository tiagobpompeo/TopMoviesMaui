using TopMoviesMaui.ViewModels;

namespace TopMoviesMaui.Views;

public partial class UpComingView : ContentPage
{

	public UpComingView()
	{
		InitializeComponent();

		BindingContext = new UpComingViewModel();
    }

    void ListView_ItemTapped(System.Object sender, Microsoft.Maui.Controls.ItemTappedEventArgs e)
    {

    }

    void TapGestureRecognizer_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {

    }
}
