using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ManagePeople.Business.HttpRequest
{
    public class HttpRequestBase
    {
        public static readonly HttpClient httpClient = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true });
        static HttpRequestBase()
        {
            //var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var _url = "https://localhost:7245/api/"; /*config.GetSection("AppSettings:Url").Value;*/
            httpClient.BaseAddress = new Uri(_url);
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "xxxx");
        }
    }
}
