using System.Net;

namespace ManagePeople.Business.ApiCallService
{
    public interface IApiCallService<T> where T : class
    {
        string requestUrl { get; set; } 
        Task<HttpStatusCode> Save(T target);
        Task<bool> Login(T target);
    }
}
