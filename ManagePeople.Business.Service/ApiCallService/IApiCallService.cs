using System.Net;

namespace ManagePeople.Business.ApiCallService
{
    public interface IApiCallService<T> where T : class
    {
        Task<HttpStatusCode> Save(T target);
    }
}
