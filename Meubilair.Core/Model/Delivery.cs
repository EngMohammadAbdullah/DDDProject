using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meubilair.Core.Model
{
    public class Delivery
    {
        public Guid Id { get; set; }
        public Address Source { get; set; }
        public Brunch Brunch { get; set; }
        public Address Destination { get; set; }
        public Route Route { get; set; }

    }
}
