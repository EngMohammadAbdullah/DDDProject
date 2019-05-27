using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meubilair.Core.Model
{
    public class Product
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public float Weight { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Color Color { get; set; }


    }
}
