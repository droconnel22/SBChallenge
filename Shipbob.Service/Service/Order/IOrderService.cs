using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shipbob.Service.Models.Orders;
using Shipbob.Service.Service.Inventory;

namespace Shipbob.Service.Service.Order
{
    public interface IOrderService
    {
        IEnumerable<IOrder> ContainedOrders { get; }

        Task<bool> PlaceOrder(IOrder order);

        IOrderService UpdateInventoryState(Func<IInventoryService> checkInventoryState);
    }
}
