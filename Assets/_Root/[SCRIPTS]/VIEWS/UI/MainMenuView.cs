using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
 

namespace Game.UI
{
    internal class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonStartGame;
        [SerializeField] private Button _buttonSettings;
        [SerializeField] private Button _buttonGarage;


        public void Init(UnityAction start, UnityAction settings, UnityAction garage)
        {
            _buttonStartGame.onClick.AddListener(start);
            _buttonSettings.onClick.AddListener(settings);
            _buttonGarage.onClick.AddListener(garage);
        }
        
        private void OnDestroy()
        {
            _buttonStartGame.onClick.RemoveAllListeners();
            _buttonSettings.onClick.RemoveAllListeners();
            _buttonGarage.onClick.RemoveAllListeners();
        }
    }
}
