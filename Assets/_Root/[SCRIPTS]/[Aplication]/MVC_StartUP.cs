using Game.Controllers;
using Game.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Main
{
    internal class MVC_StartUP : MonoBehaviour
    {
        
        [SerializeField] private float _defaultSpeed;
        [SerializeField] private Transform _placeForUI;

        private Profile _profile;
        private MainController _mainController;

        private void Awake()
        {    
            _profile = new Profile(_defaultSpeed,GameState.Menu);
            _mainController = new MainController(_profile, _placeForUI);
        }
        private void OnDestroy() => _mainController?.Dispose();
       
    }
}
