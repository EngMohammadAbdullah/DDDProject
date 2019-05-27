using Meubilair.Core;
using Meubilair.Core.RepositoryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meubilair.Model.Addresses
{
    public static class AddressService
    {
        private static IAddressRepository repository;
        private static IUnitOfWork unitOfWork;

        static AddressService()
        {
            AddressService.unitOfWork = new UnitOfWork();
            AddressService.repository =
               RepositoryFactory.GetRepository<IAddressRepository,
               Address>(AddressService.unitOfWork);
        }

        public static Address GetAddress(object childEntityKeyValue)
        {
            return AddressService.repository.FindBy(childEntityKeyValue);
        }
    }
}
