using System;
using System.Collections.Generic;
using System.Linq;
using Shipbob.Data.Entities;

using Shipbob.Service.Models.Inventory;

namespace Shipbob.Service.Factory
{
    internal static class InventoryFactory
    {

        public static IEnumerable<IItem> Create(IEnumerable<ItemEntity> entityCollection) => entityCollection.Select(CreateItem);

        public static IEnumerable<ItemEntity> Create(IEnumerable<IItem> items) => items.Select(CreateItem);


        private static IItem CreateItem(ItemEntity entity) => 
            new Item(entity.ItemId,ItemTypeFactory.TranslateItemColor(entity.ItemColor), ItemTypeFactory.TranslateItemType(entity.ItemType));


        private static ItemEntity CreateItem(IItem item) => 
            new ItemEntity()
                            {
                                ItemId = item.ItemId,
                                ItemColor = ItemTypeFactory.TranslateItemColor(item.ItemColor),
                                ItemType =  ItemTypeFactory.TranslateItemType(item.ItemType)
                            };
     
    }
}