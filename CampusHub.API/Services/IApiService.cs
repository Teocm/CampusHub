
using CampusHub.Shared.Responses;

namespace CampusHub.API.Services
{
    public interface IApiService
    {
        Task<Response> GetListAsync<T>(string servicePrefix, string controller);
    }
}


