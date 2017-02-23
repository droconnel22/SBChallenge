using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipbob.Service.Models.Inventory;

namespace Shipbob.Service.Models.InventoryStates
{
    internal class AverageTrafficInventoryState :IInventoryState
    {
        public IInventoryState CheckInventoryState(IReadOnlyDictionary<string, IEnumerable<IItem>> itemDictonary)
        {
            if (itemDictonary.ContainsKey("baseball") && !itemDictonary["baseball"].Any()) return new EmptyInventoryState();
            if (itemDictonary.ContainsKey("hat") && itemDictonary["hat"].Count() > 50) return new InitialzedInventoryState();
            if (itemDictonary.ContainsKey("bat") && itemDictonary["bat"].Count() > 50) return new InitialzedInventoryState();
            return this;
        }

        public int ReturnToClient() => 10;
    }
}
