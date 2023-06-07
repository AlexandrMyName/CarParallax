using Game.Models;
using Game.UI;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace Game.Controllers
{
    internal class SettingsController : BaseController
    {
        private readonly ResourcesPath _pathTool = new ResourcesPath("[PREFABS]/[VIEWS]/SettingsView");

        private SettingsView _view;
        private readonly Profile _profile;


        public SettingsController(Profile profile, Transform placeForUI)
        {
            _profile = profile;
            _view = LoadView(placeForUI);
            _view.Init(BackToMenu);
        }
        private SettingsView LoadView(Transform placeForUI = null)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab<GameObject>(_pathTool);
            GameObject viewOnScene = Object.Instantiate(prefab, placeForUI, false);
            AddGameObjects(viewOnScene);
            return viewOnScene.GetComponent<SettingsView>();
        }

        private void BackToMenu() => _profile._reactGameState.Value = GameState.Menu;
         
    }
}
