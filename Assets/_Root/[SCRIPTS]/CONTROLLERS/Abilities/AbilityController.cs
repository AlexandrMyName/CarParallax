using Configs.Inventory;
using Game.Inventory;
using Game.Models;
using Game.UI;
using Tools;
using UnityEngine;

namespace Game.Controllers
{
    internal class AbilityController : BaseController
    {
        private readonly ResourcesPath _pathView = new ResourcesPath("[PREFABS]/[VIEWS]/AbilityView");

        private readonly ResourcesPath _pathItemConfigs = new ResourcesPath("[CONFIGS]/Abilities/AbilitiesItemConfigsDataBase");

        private AbilityItemRepository _itemsAbilityRepository;
        private AbilitiesView _view; 
        private IAbilityActivator _activator;
        private IInventory _inventoryModel;

        public AbilityController(Transform placeForUI,  IAbilityActivator activator, Profile profile)
        {
            _inventoryModel =  profile._inventory;
            _activator = activator;
            var abilityItemConfigs = LoadAbilitiesItemConfigs();
            _itemsAbilityRepository = LoadRepository(abilityItemConfigs);
            _view = LoadView(placeForUI);
            _view.Display(abilityItemConfigs.Configs, OnAbilityViewClicked , _inventoryModel);
        }
        
        private AbilitiesItemConfigsDataBase LoadAbilitiesItemConfigs()
        {
            var configs = ResourcesLoader.LoadPrefab<AbilitiesItemConfigsDataBase>(_pathItemConfigs);
            return configs;
        }

        private AbilityItemRepository LoadRepository(AbilitiesItemConfigsDataBase configs)
        {
            var repository = new AbilityItemRepository(configs.Configs);
            AddRepository(repository);
            return repository;
        }
        private AbilitiesView LoadView(Transform placeForUI = null)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab<GameObject>(_pathView);
            GameObject viewOnScene = Object.Instantiate(prefab, placeForUI, false);
            AddGameObjects(viewOnScene);
            return viewOnScene.GetComponent<AbilitiesView>();
        }

        private void OnAbilityViewClicked(string abilityID)
        {
            if(_itemsAbilityRepository.Items.TryGetValue(abilityID,out var ability))
             if(_inventoryModel.Contains(abilityID)) ability.Apply(_activator);
        }
    }
}
