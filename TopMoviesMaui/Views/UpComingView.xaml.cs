using TopMoviesMaui.ViewModels;

namespace TopMoviesMaui.Views;

public partial class UpComingView : ContentPage
{

	public UpComingView()
	{
		InitializeComponent();

		BindingContext = new UpComingViewModel();

        listView.ItemSelected += (sender, e) =>
        {
            ((ListView)sender).SelectedItem = null;
        };
    }


    void TapGestureRecognizer_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {

    }
}
