using System;
using TopMovies.Business.Models;

namespace TopMovies.Business
{
    public interface IGenericRepositoryBusiness
    {      
        Task<T> PostAsync<T>(string uri, T data, string authToken = "");     
        Task<R> PostAsync<T, R>(string uri, T data, string authToken = "");
        Task PostAsync(string uri, string data);
    }
}

