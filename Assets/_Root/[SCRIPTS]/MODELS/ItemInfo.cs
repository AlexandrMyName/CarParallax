 
using UnityEngine;
 

namespace Game.Inventory
{
    internal struct ItemInfo 
    {
        public ItemInfo(string title, Sprite icon)
        {
            Title = title;
            Icon = icon;
        }

        public string Title { get; }
        public Sprite Icon { get; }
    }
}