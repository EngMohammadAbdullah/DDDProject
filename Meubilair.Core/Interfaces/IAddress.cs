using Meubilair.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meubilair.Core.Interfaces
{
    interface IAddress
    {
        Address Get(Address address);
        void Add(Address address);
        void Delete(Address address);
        void Update(Address address);
        IEnumerable<Address> GetAddresses();
        Address GetCustomerAddress(Customer customer);
    }
}
