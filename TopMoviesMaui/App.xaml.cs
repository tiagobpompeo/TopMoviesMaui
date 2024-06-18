using TopMoviesMaui.Views;

namespace TopMoviesMaui;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();	
        MainPage = new FlyoutSamplePage();       
	}
}

