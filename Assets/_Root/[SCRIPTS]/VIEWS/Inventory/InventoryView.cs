using Game.Inventory;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.UI
{
    internal class InventoryView : MonoBehaviour
    {
        [SerializeField] private Transform _placeForItems;
        [SerializeField] private GameObject _itemViewPrefab;


         private Dictionary<string,ItemView> _itemViews = new Dictionary<string,ItemView>();


        public void Display(IEnumerable<IItem> items, Action<string> onClick)
        {
            Clear();

            foreach(var item in items)
               _itemViews.Add(item.Id, CreateItemView(item,onClick));
            
        }


        private ItemView CreateItemView(IItem item, Action<string> onClick)
        {
            GameObject itemView =  GameObject.Instantiate(_itemViewPrefab,_placeForItems,false);
            ItemView viewItem = itemView.GetComponent<ItemView>();
            viewItem.Init(item, () => onClick?.Invoke(item.Id));
            return viewItem;
        }

        public void Sellect(string itemID) => _itemViews[itemID].Sellect();
        public void Unsellect(string itemID) => _itemViews[itemID].UnSellect();

        private void Clear()
        {
            foreach(var item in _itemViews.Values)
            {
                item.DeInit();
                Destroy(item.gameObject);
            }
            _itemViews.Clear();
        }

    }
}