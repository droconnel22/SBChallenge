using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ServiceStack;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using Shipbob.Service.Models.Inventory;
using Shipbob.Service.Models.Orders;
using Shipbob.Service.Service;
using StackExchange.Redis;

namespace Shipbob.Service.CacheController
{
   internal class RedisCacheController: ICacheController
   {
       private IDatabase redisDatabase;

       private IRedisTypedClient<IItem> itemRedisTypedClient;

        public RedisCacheController()
        {
            
        }

       private void ConnectToDatabase()
       {
            this.redisDatabase = RedisConnectorHelper.Connection.GetDatabase();
       }


       public bool UpdateCache(IEnumerable<IItem> items)
       {
            this.itemRedisTypedClient.Lists["items"].AddRange(items);
            //Insert logic, etc
           return true;
       }

       public bool UpdateCache(IEnumerable<IOrder> orders)
       {
           throw new NotImplementedException();
       }

       public IEnumerable<IItem> GetFromCache(IEnumerable<IItem> items)
       {
           throw new NotImplementedException();
       }

       public IEnumerable<IOrder> GetFromCache(IEnumerable<IOrder> orders)
       {
           throw new NotImplementedException();
       }
    }
}
