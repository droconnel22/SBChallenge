using System.Collections.Generic;
using Shipbob.Service.Models.Inventory;

namespace Shipbob.Service.Models.InventoryStates
{
    internal interface IInventoryState
    {
        IInventoryState CheckInventoryState(IReadOnlyDictionary<string, IEnumerable<IItem>> itemDictonary);

        int ReturnToClient();

    }
}