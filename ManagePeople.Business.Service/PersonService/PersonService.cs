using ManagePeople.Business.HttpRequest;
using ManagePeople.ViewModels.Person;

namespace ManagePeople.Business.PersonService
{
    public class PersonService : IPersonService
    {
        private readonly string requestUrl;
        public PersonService()
        {
            requestUrl = "Person";
        }

        public async Task<PersonViewModel> GetByCode(int personCode)
        {
            var response = await HttpRequestBase.httpClient.GetAsync(requestUrl + $"/{personCode}");
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.ToString());
            return await response.Content.ReadAsAsync<PersonViewModel>();
        }

        public async Task<List<PersonViewModel>> GetPersinList()
        {
            var response = await HttpRequestBase.httpClient.GetAsync(requestUrl);
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.ToString());
            return  await response.Content.ReadAsAsync<List<PersonViewModel>>();
        }
    }
}
