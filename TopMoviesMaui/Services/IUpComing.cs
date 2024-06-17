using System;
using TopMoviesMaui.Models;

namespace TopMoviesMaui.Services
{
    public interface IUpComing
    {
        Task<List<Movies.Result>> GetAllMoviesAsync(int page);
        Task<GenreClass> GetAllGenresAsync();
    }
}

