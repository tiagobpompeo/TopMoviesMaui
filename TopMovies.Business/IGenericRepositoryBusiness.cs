using System;
namespace TopMovies.Business
{
    public interface IGenericRepositoryBusiness
    {      
        Task<T> PostAsync<T>(string uri, T data, string authToken = "");     
        Task<R> PostAsync<T, R>(string uri, T data, string authToken = "");
    }
}

