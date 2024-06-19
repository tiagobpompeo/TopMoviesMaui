namespace TopMoviesMaui.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class TopMoviesMauiNavigationPage : NavigationPage
{
    public TopMoviesMauiNavigationPage()
    {
        InitializeComponent();
      
    }

    public TopMoviesMauiNavigationPage(Page root) : base(root)
    {
        InitializeComponent();
    }
}

