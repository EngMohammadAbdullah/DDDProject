using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meubilair.Core.Model
{
    public class Journey
    {
        public Guid Id { get; set; }
        public Car Car { get; set; }
        public Driver Driver { get; set; }
        public Route Route { get; set; }
        public DateTime Date { get; set; }

    }
}
