using Configs.Inventory;
using Game.Inventory;
using Game.Models;
using Game.UI;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace Game.Controllers
{
    internal class GarageController : BaseController
    {
        private readonly ResourcesPath _pathView = new ResourcesPath("[PREFABS]/[VIEWS]/GarageView");

        private readonly ResourcesPath _pathItemUpgradeConfigs = new ResourcesPath("[CONFIGS]/InventorySystem/DataBaseUpgradableItemConfig");

        private InventoryController _inventoryController;

        private UpgradableItemRepository _repositoryForUpgrade;

        private GarageView _garageView;

        private Profile _profile; 


        public GarageController(Profile profile, Transform placeForUI)
        {
            _profile = profile;
            _inventoryController = CreateInventoryController(placeForUI, profile);
            _garageView = LoadView(placeForUI);
            _repositoryForUpgrade = LoadRepository();
            _garageView.Init(OnClickedApply);
        }
        private UpgradableItemRepository LoadRepository()
        {
            var configs = ResourcesLoader.LoadPrefab<DataBaseUpgradableItemConfig>(_pathItemUpgradeConfigs);
            var repository = new  UpgradableItemRepository(configs.Configs);
            AddDisposableObject(repository);
            return repository;
        }
        private GarageView LoadView(Transform placeForUI = null)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab<GameObject>(_pathView);
            GameObject viewOnScene = Object.Instantiate(prefab, placeForUI, false);
            AddGameObjects(viewOnScene);
            return viewOnScene.GetComponent<GarageView>();
        }
        private InventoryController CreateInventoryController(Transform placeForUI,Profile profile)
        {
             
            var inventoryCntr = new InventoryController(placeForUI, profile._inventory);
            AddDisposableObject(inventoryCntr);

            return inventoryCntr;
        }
        private void OnClickedApply()
        {
            _profile.Car.Restore();
            TryUpgradeItems(_profile._inventory.Items, _profile.Car, 
                 _repositoryForUpgrade.Items);


            Debug.Log("Current method:" + " APPLY | SPEED/VALUE : " + _profile.Car.Speed);

            _profile._reactGameState.Value = GameState.Menu;
        }

        
        private void TryUpgradeItems(IEnumerable<string> items,
             IUpgradable upgradableModel,
             IReadOnlyDictionary<string,IUpgabableHandler> handlers
            ){
            //////////[UPGRADE WITH HANDLERS]\\\\\\\\\\\\\\\
             
            foreach (var item in items)
            {
                if(handlers.TryGetValue(item, out var handler))
                {
                    handler.Upgrade(upgradableModel);

                }
            }
        }
    }
}
