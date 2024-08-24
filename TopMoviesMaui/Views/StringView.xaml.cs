using TopMovies.Business;

namespace TopMoviesMaui.Views;

public partial class StringView : ContentPage
{
    public StringViewModel vm;
    
    public StringView()
	{
		InitializeComponent();
        this.BindingContext = vm = new StringViewModel();        
    }
}
