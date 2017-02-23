using System;
using System.Collections.Generic;

namespace ShipBob.Domain.ViewModels
{
    public class InventoryViewModel
    {
        public IEnumerable<ItemViewModel> Items { get; set; }

        public List<Tuple<string, int>> InventoryCounts { get; set; }

        public InventoryViewModel()
        {
            this.Items = new List<ItemViewModel>();
            this.InventoryCounts = new List<Tuple<string, int>>();
        }
    }
}