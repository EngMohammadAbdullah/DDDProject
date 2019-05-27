using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meubilair.Core.Model
{
    public class Address
    {
        public int Id { get; set; }
        public string  Land { get; set; }
        public string  Street { get; set; }
        public string  Number { get; set; }
        public string  PostCode { get; set; }

    }
}
