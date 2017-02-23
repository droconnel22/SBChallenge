using System.Collections.Generic;
using Shipbob.Service.Models.Inventory;
using ShipBob.Domain.ViewModels;
using System;
using System.Linq;

namespace ShipBob.Domain.Factory
{
    public static class InventoryFactory
    {

        //Reiterating here that tuples are great for prototyping objects but should never be sent to production code.
        public static InventoryViewModel Create(Tuple<IEnumerable<IItem>, int, int, int> itemTuple) => new InventoryViewModel()
        {
            Items = itemTuple.Item1.Select(ItemFactory.Create),
            InventoryCounts = new List<Tuple<string, int>>()
            { new Tuple<string, int>("baseball",itemTuple.Item2) ,
              new Tuple<string, int>("hat", itemTuple.Item3),
                new Tuple<string, int>("bat", itemTuple.Item4)
            }
            
        };

    }
}