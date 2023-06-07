

namespace Game.Inventory
{
    internal class Item : IItem
    {
        public Item(string id, ItemInfo info)
        {
            Id = id;
            Info = info;
        }

        public string Id { get;  }

        public ItemInfo Info { get; }
    }
}