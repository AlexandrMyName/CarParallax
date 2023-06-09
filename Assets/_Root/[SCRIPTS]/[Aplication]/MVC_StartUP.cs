using Game.Controllers;
using Game.Models;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Main
{
    internal class MVC_StartUP : MonoBehaviour
    {
        
   

        private Profile _profile;
        private MainController _mainController;

 
        [Inject]
        private void  AddDependence(Profile profile, MainController mainCntrl)
        {
            _profile = profile;
            _mainController = mainCntrl;
            

        }
        private void OnDestroy() => _mainController?.Dispose();
       
    }
}
