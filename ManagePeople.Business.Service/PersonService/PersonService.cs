using ManagePeople.Business.HttpRequest;
using ManagePeople.ViewModels.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePeople.Business.PersonService
{
    public class PersonService : IPersonService
    {
        private readonly string requestUrl;
        public PersonService()
        {
            requestUrl = "Person";
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
