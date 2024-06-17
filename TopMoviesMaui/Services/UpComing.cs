using System;
using TopMoviesMaui.Constants;
using TopMoviesMaui.Models;
using TopMoviesMaui.Repository;

namespace TopMoviesMaui.Services
{
	public class UpComing:IUpComing
    {
        private readonly IGenericRepository _genericRepository;

        public UpComing()        
        {
            _genericRepository = new GenericRepository();
        }

        public async Task<List<Movies.Result>> GetAllMoviesAsync(int page)
        {          
            string uri = $"{ApiConstants.BaseApiUrl}upcoming?api_key={ApiConstants.Api_key}&language=en-us&page={page}";
            var movies = await _genericRepository.GetAsync<Movies>(uri);
            //GeneralVar.TotalPages = movies.Total_pages;//count
            var listMovies = movies.Results;
            //Cache.InsertObject(page.ToString(), listMovies, DateTimeOffset.Now.AddSeconds(20));
            return listMovies;
            
        }

        public async Task<GenreClass> GetAllGenresAsync()
        {
            var genres = await _genericRepository.GetAsync<GenreClass>(ApiConstants.UrlGenre);
            return genres;
        }
    }
}