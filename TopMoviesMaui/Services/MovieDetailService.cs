using System;
using TopMoviesMaui.Constants;
using TopMoviesMaui.Models;
using TopMoviesMaui.Repository;

namespace TopMoviesMaui.Services
{
	public class MovieDetailService: IMovieDetailService
    {
        private readonly GenericRepository _genericRepository;

        public MovieDetailService()
        { 
            _genericRepository = new GenericRepository();
        }

        public async Task<MovieDetails> GetAllMovieDetailAsync(int movieId)
        {            
            string uri = $"{ApiConstants.DetailMovieBaseUrl}movie/{movieId}?api_key={ApiConstants.Api_key}&language=en-US";
            MovieDetails response = await _genericRepository.GetAsync<MovieDetails>(uri);
            //Cache.InsertObject(movieId.ToString(), response, DateTimeOffset.Now.AddSeconds(20));
            return response;            
        }

    }
}

