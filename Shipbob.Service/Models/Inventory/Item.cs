using System;

namespace Shipbob.Service.Models.Inventory
{
    public sealed class Item : IItem, IEquatable<Item>
    {
        public Item(int itemId,string itemColor, string itemType)
        {
            if(string.IsNullOrEmpty(itemColor)) throw new ArgumentNullException(nameof(itemColor));
            if(string.IsNullOrEmpty(itemType)) throw new ArgumentNullException(nameof(itemType));

            this.ItemId = itemId;
            this.ItemColor = itemColor;
            this.ItemType = itemType;
        }

        public int ItemId { get; }
        public string ItemColor { get; }
        public string ItemType { get; }

        public bool Equals(Item other) =>
                string.Equals(this.ItemColor, other.ItemColor, StringComparison.InvariantCultureIgnoreCase) &&
                string.Equals(this.ItemType, other.ItemType, StringComparison.InvariantCultureIgnoreCase);

        public override bool Equals(object obj) => this.Equals(obj);

        //public static bool operator == (Item a) => this.Equals(a);
        

        //public static bool operator != (Item a, Item b) => !(a == b);
        

        public override int GetHashCode() => base.GetHashCode();
    }
}
