using Configs.Inventory;
using Game.Inventory;
using Game.UI;
using Tools;
using UnityEngine;

namespace Game.Controllers
{
    internal class InventoryController : BaseController
    {
        private readonly ResourcesPath _pathView = new ResourcesPath("[PREFABS]/[VIEWS]/InventoryView");

        private readonly ResourcesPath _pathItemConfigs = new ResourcesPath("[CONFIGS]/InventorySystem/DataBaseItemsConfig");

        private ItemRepository _itemsRepository;
        private InventoryView _inventoryView;
        private IInventory _inventory;
        public InventoryController (Transform placeForUI, IInventory model)
        {
             _inventory = model;
            _itemsRepository = LoadRepository();
            _inventoryView = LoadView(placeForUI);


            _inventoryView.Display(_itemsRepository.Items.Values, OnClickedItem);

            foreach(string itemId in model.Items)
            {
                _inventoryView.Sellect(itemId);
            }

        }

        private ItemRepository LoadRepository( )
        {
            var configs = ResourcesLoader.LoadPrefab<DataBaseItemsConfig>(_pathItemConfigs);
            var repository = new ItemRepository(configs.Configs);
            AddDisposableObject(repository);
            return repository;
        }
        private InventoryView LoadView(Transform placeForUI = null)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab<GameObject>(_pathView);
            GameObject viewOnScene = Object.Instantiate(prefab, placeForUI, false);
            AddGameObjects(viewOnScene);
            return viewOnScene.GetComponent<InventoryView>();
        }

        private void OnClickedItem(string itemID)
        {
            bool isSellected = _inventory.Contains(itemID);
            
            if (isSellected) UnsellectItem(itemID);
            else SellectItem(itemID);
        }

        private void SellectItem(string itemID)
        {
            _inventory.AddItem(itemID);
            _inventoryView.Sellect(itemID);
            
        }
        private void UnsellectItem(string itemID)
        {
            _inventory.RemoveItem(itemID);
            _inventoryView.Unsellect(itemID); 
             
        }
    }
}
