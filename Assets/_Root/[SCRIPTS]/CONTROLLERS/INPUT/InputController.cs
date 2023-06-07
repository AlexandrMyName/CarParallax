
using Game.Models;
using Game.UI;
using System.Collections;
using System.Collections.Generic;
using Tools;
using Tools.React;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Controllers
{
    internal class InputController : BaseController
    {
         
        private BaseInputView _view;
        private readonly Profile _profile;

        private readonly ResourcesPath _pathTool = new ResourcesPath("[PREFABS]/[VIEWS]/KeyInputView");

        public InputController(Profile profile, 
            IReadOnlySubscriptionProperty<float> left,
            IReadOnlySubscriptionProperty<float> right){
            ///////////////[INPUT]\\\\\\\\\\\\\\\\\\\\\
            _profile = profile;
            _view = LoadView();
            _view.Init(left,right);
        }
        private KeyWordInputView LoadView(Transform placeForUI = null)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab<GameObject>(_pathTool);
            GameObject viewOnScene = Object.Instantiate(prefab);
            AddGameObjects(viewOnScene);
            return viewOnScene.GetComponent<KeyWordInputView>();
        }

        
    }
}