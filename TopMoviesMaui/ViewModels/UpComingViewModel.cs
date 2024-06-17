using System;

using System.Collections.ObjectModel;
using TopMoviesMaui.Models;


namespace TopMoviesMaui.ViewModels
{
    public class UpComingViewModel:BindableObject
	{      
        public ObservableCollection<Movies.Result> MoviesOut { get; set; }

        public UpComingViewModel()
		{

            MoviesOut = new ObservableCollection<Movies.Result> ();

            MoviesOut.Add(new Movies.Result
            {
                Id = 0,
                Poster_path ="Img",
                Title = "Filme 1",
                Genre_ids = null,
                Release_date= DateTime.Now
            });

            MoviesOut.Add(new Movies.Result
            {
                Id = 0,
                Poster_path = "Img2",
                Title = "Filme 2",
                Genre_ids = null,
                Release_date = DateTime.Now
            });
        }
	}
}

