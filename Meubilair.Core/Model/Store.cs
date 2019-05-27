using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meubilair.Core.Model
{
    public class Store
    {
        public int Id { get; set; }
        public Brunch Brunch { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }

    }
}
