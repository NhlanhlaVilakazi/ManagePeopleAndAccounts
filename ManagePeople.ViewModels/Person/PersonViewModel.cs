using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePeople.ViewModels.Person
{
    public class PersonViewModel
    {
        public int Code { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? IdNumber { get; set; }
    }
}
