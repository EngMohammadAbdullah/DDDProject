using Meubilair.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meubilair.Repositories.Order
{
    public static class OrderService
    {
        private static readonly IOredrRepository repository;
        private static IUnitOfWork unitOfWork;
        static OrderService()
        {
            OrderService.unitOfWork = new UnitOfWork();
            OrderService.repository = OrderFactory.
                GetRepository<IOredrRepository, Order>(unitOfWork);

        }
    }
}
