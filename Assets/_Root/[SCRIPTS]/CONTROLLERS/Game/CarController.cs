using Game.Models;
using Game.UI;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace Game.Controllers
{
    internal class CarController : BaseController
    {
        private readonly ResourcesPath _pathTool = new ResourcesPath("[PREFABS]/[VIEWS]/CarView");

        private CarView _view;
        private readonly Profile _profile;


        public CarController(Profile profile, Transform placeForUI)
        {
            _profile = profile;
            _view = LoadView();
            
        }
        private CarView LoadView(Transform placeForUI = null)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab<GameObject>(_pathTool);
            GameObject viewOnScene = Object.Instantiate(prefab);
            AddGameObjects(viewOnScene);
            return viewOnScene.GetComponent<CarView>();
        }

       
    }
}
