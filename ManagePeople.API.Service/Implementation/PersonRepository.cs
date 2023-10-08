using ManagePeople.Data;
using ManagePeople.Data.DataModels.Person;
using ManagePeople.Repository.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePeople.Repository.Implementation
{
    public class PersonRepository : IPersonRepository
    {
        private DataContext _dbContext;
        public PersonRepository()
        {
            _dbContext = new DataContext();
        }
        public Task AddPerson(Person person)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeletePerson(int personCode)
        {
            throw new NotImplementedException();
        }

        public async Task<Person> GetPersonByCode(int personCode)
        {
            return await _dbContext.People.Where(person => person.Code == personCode).FirstAsync();
        }

        public async Task<List<Person>> GetPersons()
        {
            const string query = "EXEC [GetPersons]";
            return await _dbContext.Set<Person>().FromSqlRaw(query).ToListAsync();
        }

        public Task<bool> PersonAlreadyExist(string idNumber, bool isUpate)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
