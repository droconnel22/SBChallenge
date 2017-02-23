using System.Collections.Generic;
using Shipbob.Service.Models.Inventory;
using Shipbob.Service.Models.Orders;
using Shipbob.Service.Service;

namespace Shipbob.Service.CacheController
{
    public sealed class NotImplementedCacheController : ICacheController
    {
        private static NotImplementedCacheController instance;

        public static NotImplementedCacheController GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new NotImplementedCacheController();
                return instance;
            }
        }

        public bool UpdateCache(IEnumerable<IItem> items) => false;

        public bool UpdateCache(IEnumerable<IOrder> orders) => false;

        public IEnumerable<IItem> GetFromCache(IEnumerable<IItem> items) => new List<IItem>();

        public IEnumerable<IOrder> GetFromCache(IEnumerable<IOrder> orders) => new List<IOrder>();
    }
}