using System.Collections.Generic;
 

namespace Game.Inventory
{
    internal class InventoryModel : IInventory
    {
        private readonly List <string> _itemsID;
        public IReadOnlyList<string> Items => _itemsID;


        public InventoryModel()
        {
            _itemsID = new List<string>();
        }
        public void AddItem(string id)
        {
            if (!Contains(id)) _itemsID.Add(id);
            
        }

        public bool Contains(string id) => _itemsID.Contains(id);

        public void RemoveItem(string id)
        {
             if(Contains(id)) _itemsID.Remove(id);
        }
    }
}