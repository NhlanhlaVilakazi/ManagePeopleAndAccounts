using ManagePeople.ViewModels.Person;

namespace ManagePeople.Business.PersonService
{
    public interface IPersonService
    {
        Task<List<PersonViewModel>> GetPersinList();
        Task<PersonViewModel> GetByCode(int personCode);
    }
}
