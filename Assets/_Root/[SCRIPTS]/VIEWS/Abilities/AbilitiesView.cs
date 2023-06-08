using Configs.Inventory;
using Game.Inventory;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    internal interface IAbilityView
    {
        void Display(IReadOnlyList<IAbilityItem> items, Action<string> collback, IInventory inventory);
             
        void Clear();
    }
    internal class AbilitiesView : MonoBehaviour, IAbilityView
    {
      
        [SerializeField] GameObject _buttonPrefab;
        [SerializeField] Transform _placeForButtons;
        private readonly   Dictionary<string, AbilityButtonView> _buttonViews  = new Dictionary<string, AbilityButtonView>();


        private void OnDestroy() => Clear();
        
        public void Clear()
        {
            foreach(var view in _buttonViews.Values)
            {
                DestroyButtonView(view);
            }
            _buttonViews.Clear();
        }

        private void DestroyButtonView(AbilityButtonView view)
        {
            view.DeInit();
           Destroy(view.gameObject);
        }

        public void Display(IReadOnlyList<IAbilityItem> items, Action<string> callback, IInventory inventory)
        {
            foreach(var item in items)
            {
                if(inventory.Contains(item.Id))
                _buttonViews[item.Id] = CreateAbilityButtonView(item, callback);
            }
        }

        private AbilityButtonView CreateAbilityButtonView(IAbilityItem item, Action<string> callback )
        {
            var prefabButton = GameObject.Instantiate(_buttonPrefab, _placeForButtons, false);
            AbilityButtonView buttonView = prefabButton.GetComponent<AbilityButtonView>();

            buttonView.Init(item.Icon, () => callback?.Invoke(item.Id));
            return buttonView;
        }
    }
}