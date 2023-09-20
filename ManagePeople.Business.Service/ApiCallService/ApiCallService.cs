using ManagePeople.Business.HttpRequest;
using System.Net;

namespace ManagePeople.Business.ApiCallService
{
    public class ApiCallService<T> : IApiCallService<T> where T : class
    {
        private string requestUrl { get; set; } = null!;
        public async Task<HttpStatusCode> Save(T target)
        {
            var response = await HttpRequestBase.httpClient.PostAsJsonAsync(requestUrl, target);
            return response.StatusCode;
        }
    }
}
