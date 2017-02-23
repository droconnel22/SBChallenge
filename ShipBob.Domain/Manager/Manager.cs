using System.Threading.Tasks;
using Shipbob.Service.CacheController;
using Shipbob.Service.Service;
using Shipbob.Service.Service.Inventory;
using Shipbob.Service.Service.Order;
using ShipBob.Domain.ViewModels;
using Shipbob.Service.ServiceBuilder;
using ShipBob.Domain.Common;

namespace ShipBob.Domain.Manager
{
    public class Manager : IManager
    {
        private IInventoryService inventoryService;

        private readonly IOrderService orderService;

        private readonly IInventoryServiceBuilder inventoryServiceBuilder;

        public Manager(IInventoryServiceBuilder builder, IOrderService orderService)
        {
            this.inventoryServiceBuilder = builder;
            this.orderService = orderService;
        }
       
        public async Task InitailzeAsync() => this.inventoryService = await this.inventoryServiceBuilder
            .SetCachingService(new NotImplementedCacheController())
            .BuildAsync();

        public async Task<InventoryViewModel> GetInventoryAsync() =>
          (await this.inventoryService
                .CheckInventoryState()
                .GetLatestInventoryAsync())
            .ConvertToItemViewModels();

        public async Task<bool> PlaceOrder(OrderViewModel orderViewModel) =>await this.orderService
            .UpdateInventoryState(this.inventoryService.CheckInventoryState)
            .PlaceOrder(orderViewModel.ConvertToOrderModel());

      
    }

 
}