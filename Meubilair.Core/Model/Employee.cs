using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meubilair.Core.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string PhoneNumber { get; set; }
        public Brunch Brunch { get; set; }


    }
}
