using Firebase.Database;
using Firebase.Database.Query;
using TopMoviesMaui.Models;
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

    void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
    {
        try
        {
            RegisterRealTimeDataBase();
        }
        catch (Exception ex)
        {

        }
    }

    public static void RegisterRealTimeDataBase()
    {
        FirebaseClient client = new FirebaseClient("seulinkdatabasenofirebase");

        var movies = client.Child("MoviesUpComing").OnceAsync<Movies.Result>();

        if (movies.Result.Count == 0)
        {
            //sample in firebase playground
            client.Child("MoviesUpComing").PostAsync(new Movies.Result
            {
                Adult = false,
                Backdrop_path = "/18wozP6NjPSNBSgCga5bN7yUSzl.jpg",
                Genre_ids = new List<int> { 35, 14, 27 },
                Id = 917496,
                Original_language = "en",
                Original_title = "Beetlejuice Beetlejuice",
                Overview = "After a family tragedy, three generations of the Deetz family return home to Winter River. Still haunted by Beetlejuice, Lydia's life is turned upside down when her teenage daughter, Astrid, accidentally opens the portal to the Afterlife.",
                Popularity = 1462.87,
                Poster_path = "/kKgQzkUCnQmeTPkyIwHly2t6ZFI.jpg",
                Release_date = DateTime.Now,
                Title = "Beetlejuice Beetlejuice",
                Video = false,
                Vote_average = 7.182,
                Vote_count = 351,
            });
        }
    }

}
