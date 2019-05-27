using System;

namespace Meubilair.Core.Model
{
    public class Route
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Address Satrt { get; set; }
        public Address FinalDestination { get; set; }

    }
}