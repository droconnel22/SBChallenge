using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shipbob.Data.Entities;
using Shipbob.Data.Repository;
using Shipbob.Service.Factory;
using Shipbob.Service.Models.Orders;
using Shipbob.Service.Service.Inventory;

namespace Shipbob.Service.Service.Order
{

    public class OrderService : IOrderService
    {
        public IEnumerable<IOrder> ContainedOrders { get; }


        private readonly BaseRepository<OrderEntity> orderRepository;
        public OrderService()
        {
            this.orderRepository = new BaseRepository<OrderEntity>();
        }

        public async Task<bool> PlaceOrder(IOrder order) => await this.orderRepository.AddEntityAsync(OrderFactory.CreateOrder(order));

        
        public IOrderService UpdateInventoryState(Func<IInventoryService> checkInventoryState)
        {
            checkInventoryState();
            return this;
        }
    }
}
