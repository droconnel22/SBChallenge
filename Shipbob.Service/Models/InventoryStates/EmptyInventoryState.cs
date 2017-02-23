using System.Collections.Generic;
using System.Linq;
using Shipbob.Service.Models.Inventory;

namespace Shipbob.Service.Models.InventoryStates
{
    internal class EmptyInventoryState : IInventoryState
    {
        public IInventoryState CheckInventoryState(IReadOnlyDictionary<string, IEnumerable<IItem>> itemDictonary)
        {
            if (itemDictonary.ContainsKey("baseball") && itemDictonary["baseball"].Any()) return new InitialzedInventoryState();
            if (itemDictonary.ContainsKey("hat") && itemDictonary["hat"].Any()) return new InitialzedInventoryState();
            if (itemDictonary.ContainsKey("bat") && itemDictonary["bat"].Any()) return new InitialzedInventoryState();
            return this;
        }

        public int ReturnToClient() => 0;
    }
}