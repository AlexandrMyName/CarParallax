using Game.Models;
using Game.UI;
using Tools;
using UnityEngine;

namespace Game.Controllers
{
    internal class MainMenuController : BaseController
    {
        private readonly ResourcesPath _pathTool = new ResourcesPath("[PREFABS]/[VIEWS]/MainMenuView");
        private readonly MainMenuView _view;
        private readonly Profile _profile;

        public MainMenuController(Profile profile ,Transform placeForUI)
        {
            _profile = profile;
            _view = LoadView(placeForUI);
            _view.Init(OnStartGame, OnSettings, OnGarage);
        }
       
        private MainMenuView LoadView(Transform placeForUI = null)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab<GameObject>(_pathTool);
            GameObject mainMenuOnScene = Object.Instantiate(prefab, placeForUI, false);
            AddGameObjects(mainMenuOnScene);
            return mainMenuOnScene.GetComponent<MainMenuView>();
        }

        private void OnStartGame() => _profile._reactGameState.Value = GameState.Game;
        private void OnGarage() => _profile._reactGameState.Value = GameState.Inventory;
        private void OnSettings() => _profile._reactGameState.Value = GameState.Settings;

    }
}
