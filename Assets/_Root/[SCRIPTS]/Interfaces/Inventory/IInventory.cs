using System.Collections.Generic;


namespace Game.Inventory
{
    internal interface IInventory  
    {
        IReadOnlyList<string> Items { get; }

        void AddItem(string id);  
        void RemoveItem(string id);
        bool Contains(string id);
    }
}
