﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TopMoviesMaui.Models;
using TopMoviesMaui.Services;
using TopMoviesMaui.ViewModels.Base;
using TopMoviesMaui.Views;

namespace TopMoviesMaui.ViewModels
{
    public class UpComingViewModel:ViewModelBase
    {
        #region Attributes
        public UpComing _upComingService;        
        private IConnectionService _connectionService;//keep
        public int pageIndex = 1;
        public bool _isWorking;
        public string _searchText;
        public string _title; 
        public ObservableCollection<Movies.Result> MoviesOut { get; set; }
        public string _genreMain;
        public string genreOut;
        public string connectionMessage;      
        public bool isrefreshing;
        #endregion

        #region Properties
        public bool IsRefreshing
        {
            get { return this.isrefreshing; }
            set { SetValue(ref this.isrefreshing, value); }
        }

        public string ConnectionMessage
        {
            get { return connectionMessage; }
            set
            {
                connectionMessage = value;               
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;               
            }
        }

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;              
            }
        }

        public bool IsWorking
        {
            get => _isWorking;
            set
            {
                _isWorking = value;                
            }
        }

        public string GenreMain
        {
            get { return _genreMain; }
            set
            {
                _genreMain = value;               
            }
        }
        #endregion

        #region Command
        public ICommand MovieTappedCommand => new Command<Movies.Result>(OnMovieTapped);
        public ICommand SearchCommand => new Command<string>(SearchMovie);
        public ICommand TextChangeInSearchCommand { get; private set; }
        #endregion

        #region Constructor
        public UpComingViewModel()
        {         
                      
            Title = "Upcoming";
            TextChangeInSearchCommand = new Command(PerformSearch);

            MoviesOut = new ObservableCollection<Movies.Result>();          

            _upComingService = new UpComing();
            _ = LoadData();           
        }

        private async Task LoadData()
        {
            IsWorking = true;

            var movies = await _upComingService.GetAllMoviesAsync(pageIndex);

            var count = movies.Count;

            foreach (var pos in movies)
            {
                MoviesOut.Add(new Movies.Result
                {
                    Poster_path = pos.Poster_path,
                    Title = pos.Title,
                    Id = pos.Id,
                    Release_date = pos.Release_date
                });
            }
   
            IsWorking = false;         
         
        }
        #endregion

        #region Methods
        private async void CheckConnection()
        {
            //var connection = await this._connectionService.CheckConnection();

            //if (!connection.IsSuccess)
            //{
            //    await Application.Current.MainPage.DisplayAlert("Conexão de Rede", connection.Message, "OK");
            //    return;
            //}
        }

        private async void OnMovieTapped(Movies.Result selectedMovie)
        {
            Console.WriteLine("OnMovieTapped " + selectedMovie.Id);

            var navigationPage = Application.Current.MainPage as NavigationPage;

            if (navigationPage != null)
            {
                await navigationPage.PushAsync(new UpComingDetailView(null));
            }
            else
            {
                Application.Current.MainPage = new NavigationPage(new UpComingDetailView(selectedMovie));
            }           
        }

        public void PerformSearch()
        {
            if (string.IsNullOrWhiteSpace(this._searchText))
            {
            }
            else
            {
                //Movies = new InfiniteScrollCollection<Movies.Result>(_ItemsUnfiltered.Where(i => (i is Movies.Result && (((Movies.Result)i)
                // .Title.ToLower()
                // .Contains(_searchText.ToLower())))));
            }
        }

        private void SearchMovie(string movieText)
        {
            //Movies = new InfiniteScrollCollection<Movies.Result>(_ItemsUnfiltered.Where(i => (i is Movies.Result && (((Movies.Result)i)
            //    .Title.ToLower()
            //    .Contains(movieText.ToLower())))));
        }

        public override Task InitializeAsync(object data)
        {
            return base.InitializeAsync(data);
        }

        #endregion
    }
}