using ManagePeople.Data.DataModels.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePeople.Repository.Interface
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetPersons();
        Task<Person> GetPersonByCode(int personCode);
        Task UpdatePerson(Person person);
        Task<int> DeletePerson(int personCode);
        Task AddPerson(Person person);
        Task<bool> PersonAlreadyExist(string idNumber, bool isUpate);
    }
}
