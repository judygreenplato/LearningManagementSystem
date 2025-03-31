using LMS.Blazor.Client.Models;
using LMS.Shared.DTOs;

namespace LMS.Blazor.Client.Services;

public interface IApiService
{
    Task<TResponse?> GetAsync<TResponse>(string endpoint);
    Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest dto);
    Task<TResponse?> PutAsync<TRequest, TResponse>(string endpoint, TRequest dto);
	Task<TResponse?> DeleteAsync<TResponse>(string endpoint);
	Task<bool> PutAsync<TRequest>(string endpoint, TRequest? dto);
}