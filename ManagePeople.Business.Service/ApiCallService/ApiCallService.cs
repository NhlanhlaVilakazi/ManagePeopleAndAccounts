using ManagePeople.Business.HttpRequest;
using System.Net;

namespace ManagePeople.Business.ApiCallService
{
    public class ApiCallService<T> : IApiCallService<T> where T : class
    {
        public string requestUrl { get; set; } = null!;

        public async Task<IQueryable<T>> GetAll()
        {
            var response = await HttpRequestBase.httpClient.GetAsync(requestUrl);
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.ToString());
            var result = await response.Content.ReadAsAsync<IEnumerable<T>>();
            return result.AsQueryable();
        }

        public async Task<bool> Login(T target)
        {
            var response = await HttpRequestBase.httpClient.PostAsJsonAsync($"{requestUrl}/Login", target);
            var resp = await response.Content.ReadAsStringAsync();
            return await response.Content.ReadAsAsync<bool>();
        }

        public async Task<HttpStatusCode> Save(T target)
        {
            var response = await HttpRequestBase.httpClient.PostAsJsonAsync(requestUrl, target);
            return response.StatusCode;
        }
    }
}
