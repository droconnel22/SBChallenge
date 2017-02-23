using System.Collections.Generic;
using System.Linq;
using Shipbob.Service.Models.Inventory;

namespace Shipbob.Service.Models.InventoryStates
{
    internal class InitialzedInventoryState : IInventoryState
    {
        public InitialzedInventoryState()
        {
        }

        public IInventoryState CheckInventoryState(IReadOnlyDictionary<string, IEnumerable<IItem>> itemDictonary)
        {
            if (itemDictonary.ContainsKey("baseball") && !itemDictonary["baseball"].Any() || itemDictonary.ContainsKey("hat") && !itemDictonary["hat"].Any() || itemDictonary.ContainsKey("bat") && !itemDictonary["bat"].Any()) return new EmptyInventoryState();
            if (itemDictonary.ContainsKey("baseball") && itemDictonary["baseball"].Count() > 50 || itemDictonary.ContainsKey("hat") && itemDictonary["hat"].Count() > 50 || itemDictonary.ContainsKey("bat") && itemDictonary["bat"].Count() > 50) return new AverageTrafficInventoryState();
            return new AverageTrafficInventoryState();
        }

        public int ReturnToClient() => 5;
    }
}