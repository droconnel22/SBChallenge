using System.Collections.Generic;
using Shipbob.Service.Models.Inventory;
using Shipbob.Service.Models.Orders;

namespace Shipbob.Service.CacheController
{
    public interface ICacheController
    {
        bool UpdateCache(IEnumerable<IItem> items);

        bool UpdateCache(IEnumerable<IOrder> orders);

        IEnumerable<IItem> GetFromCache(IEnumerable<IItem> items);

        IEnumerable<IOrder> GetFromCache(IEnumerable<IOrder> orders);
    }
}