using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePeople.Data.DataModels.Person
{
    public class Person : BasePrimaryKey
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? IdNumber { get; set; }
    }
}
