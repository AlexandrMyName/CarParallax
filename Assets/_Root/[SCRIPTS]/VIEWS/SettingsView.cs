using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.UI
{
    public class SettingsView : MonoBehaviour
    {
        [SerializeField] private Button _backToMenu;


        public void Init(UnityAction backToMenu)
        {
            _backToMenu.onClick.AddListener(backToMenu);
        }

        private void OnDestroy()
        {
            _backToMenu.onClick.RemoveAllListeners();
        }
    }
}