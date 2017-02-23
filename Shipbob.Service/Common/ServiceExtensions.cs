using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipbob.Data.Entities;
using Shipbob.Service.Factory;
using Shipbob.Service.Models.Inventory;

namespace Shipbob.Service.Common
{
   internal static class ServiceExtensions
   {
       public static IEnumerable<IItem> ConvertToModel(this IEnumerable<ItemEntity> entities) => InventoryFactory.Create(entities);

       public static IEnumerable<ItemEntity> ConvertToEntity(this IEnumerable<IItem> items)=> InventoryFactory.Create(items);

   }
}
