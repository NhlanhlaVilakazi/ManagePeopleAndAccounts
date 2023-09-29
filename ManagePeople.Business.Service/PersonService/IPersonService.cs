using ManagePeople.ViewModels.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePeople.Business.PersonService
{
    public interface IPersonService
    {
        Task<List<PersonViewModel>> GetPersinList();
    }
}
