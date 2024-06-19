using System.Windows.Input;
using TopMoviesMaui.Models;
using TopMoviesMaui.Services;
using TopMoviesMaui.Services.Navigation;
using TopMoviesMaui.ViewModels.Base;


namespace TopMoviesMaui.ViewModels
{
    public class UpComingDetailViewModel : ViewModelBase
    {
        #region Attributes
        private Movies.Result _selectedMovie;
        private readonly INavigationService _navigationService;
        private MovieDetailService _detailMovie;
        readonly IConnectionService _connectionService;
        private MovieDetails _movieDetail;
        public string _title;
        public string _genreMain;
        private string _name;
        private Movies.Result _moviesResult;
        private MovieDetails _moviesDetail;
        #endregion

        #region Properties
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public string GenreMain
        {
            get => _genreMain;
            set => SetProperty(ref _genreMain, value);
        }

        public Movies.Result SelectedMovie
        {
            get => _moviesResult;
            set => SetProperty(ref _moviesResult, value);
        }

        public MovieDetails MovieDetail
        {
            get => _moviesDetail;
            set => SetProperty(ref _moviesDetail, value);
        }

        #endregion

        #region Commands

        #endregion


        #region Constructor
        public UpComingDetailViewModel()
        {
            
        }
        #endregion

        #region Methods
        public override async Task InitializeAsync(object data)
        {
            if (data != null)
            {
                //SelectedMovie = (Movies.Result)data;//data from home view
                //web service Detail by id
                var movieSelected = (Movies.Result)data;

                _detailMovie = new MovieDetailService();

                MovieDetail = await _detailMovie.GetAllMovieDetailAsync(movieSelected.Id);

                Title = MovieDetail.Title;
                var genre = MovieDetail.Genres;
                GenreMain = genre[0].Name + "  -  " + genre[1].Name + "  -  " + genre[2].Name;
            }

        }

        private void AddListTapped(object obj)
        {
            //_dialogService.ShowToast("Movie Add List");
        }

        private void LikeTapped(object obj)
        {
            //_dialogService.ShowToast("Liked");
        }
        #endregion
    }
}