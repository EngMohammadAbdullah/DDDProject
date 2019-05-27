using Meubilair.Core;
using Meubilair.Core.RepositoryFramework;
using Meubilair.Model.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meubilair.Model.Orders
{
    public static class OrderService
    {
        private static readonly IOrderRepository repository;
        private static IUnitOfWork unitOfWork;
        static OrderService()
        {
            OrderService.unitOfWork = new UnitOfWork();
            OrderService.repository = RepositoryFactory.GetRepository<IOrderRepository, Order>(OrderService.unitOfWork);
           

        }

        public static IList<Order> GetAllOrders()
        {
            return OrderService.repository.FindAll();
        }
    }
}
