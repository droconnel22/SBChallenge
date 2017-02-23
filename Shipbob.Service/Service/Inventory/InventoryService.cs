using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Shipbob.Service.CacheController;
using Shipbob.Service.Models;
using Shipbob.Service.Models.Inventory;
using Shipbob.Service.Models.InventoryStates;

namespace Shipbob.Service.Service.Inventory
{

    public class InventoryService : IInventoryService        
    {
        private IInventoryState InventoryState { get; set; }

        private readonly IReadOnlyDictionary<string, IEnumerable<IItem>> itemDictonary;

        private readonly ICacheController cacheStrategy;

        public InventoryService(ICacheController cacheStrategy, IDictionary<string, IEnumerable<IItem>> dictionary)
        {
            this.cacheStrategy = cacheStrategy;
            this.itemDictonary = new ReadOnlyDictionary<string, IEnumerable<IItem>>(dictionary);
            this.InventoryState = new InitialzedInventoryState();
        }
        
        public IInventoryService CheckInventoryState()
        {
            this.InventoryState = this.InventoryState.CheckInventoryState(this.itemDictonary);
            return this;
        }

        //Tuples are great for prototyping objects, but should be avoided for production code.
       public async Task<Tuple<IEnumerable<IItem>,int,int,int>> GetLatestInventoryAsync()
        {
            
           var itemsToClient = new List<IItem>();

            itemsToClient.AddRange(this.itemDictonary["bat"].Take(this.InventoryState.ReturnToClient()).ToList());
            itemsToClient.AddRange(this.itemDictonary["hat"].Take(this.InventoryState.ReturnToClient()).ToList());
            itemsToClient.AddRange(this.itemDictonary["baseball"].Take(this.InventoryState.ReturnToClient()).ToList());

           return new Tuple<IEnumerable<IItem>, int, int,int>(itemsToClient,this.itemDictonary["bat"].Count(), this.itemDictonary["hat"].Count(), this.itemDictonary["baseball"].Count());
        }
    }
}
