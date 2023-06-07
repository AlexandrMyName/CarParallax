using Configs.Inventory;
using System.Collections.Generic;
using Tools.Generic;


namespace Game.Inventory
{
    internal class ItemRepository : BaseRepository<string, IItem, ItemConfig >
    {
        public ItemRepository(IEnumerable<ItemConfig> configs) : base(configs) { }
        protected override IItem CreateItem(ItemConfig config) => new Item(config.Id, new ItemInfo(config.Title, config.Icon));
        protected override string GetKey(ItemConfig config) => config.Id;
    }
}