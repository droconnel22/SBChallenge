using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shipbob.Service.Models.Inventory;

namespace Shipbob.Service.Service.Inventory
{
    public interface IInventoryService
    {
        Task<Tuple<IEnumerable<IItem>, int, int,int>> GetLatestInventoryAsync();

        IInventoryService CheckInventoryState();

    }
}
