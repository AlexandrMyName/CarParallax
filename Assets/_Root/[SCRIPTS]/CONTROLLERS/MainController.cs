using Game.Models;
using Game.UI;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers
{
    internal class MainController : BaseController
    {
        private readonly Transform _placeForUI;
        private readonly Profile _profile;

        private MainMenuView _mainMenuView;



        private Dictionary<string ,BaseController> _controllers;

        public MainController(Profile profile,Transform placeForUI)
        {
             CreateController();
            _placeForUI = placeForUI;
            _profile = profile;

            _profile._reactGameState.Subscribe(OnChangeGameState);
            OnChangeGameState(_profile._reactGameState.Value);
        }
      
        private void OnChangeGameState(GameState state)
        {
            DisposeControllers();
            switch (state)
            {
                case GameState.Menu:
                    CreateController(nameof(MainMenuController), new MainMenuController(_profile, _placeForUI));
                    break;

                case GameState.Game:
                    CreateController(nameof(GameController), new GameController(_profile, _placeForUI));
                    break;

                case GameState.Settings:
                    CreateController(nameof(SettingsController), new SettingsController(_profile, _placeForUI));
                    break;

                case GameState.Inventory:
                    CreateController(nameof(GarageController), new GarageController(_profile, _placeForUI));
                    break;
            }
        }
       
        public override void OnDisposable()
        {
            _profile._reactGameState.Unsubscribe(OnChangeGameState);
            DisposeControllers();
        }

        private void CreateController(string nameController = null, BaseController addedcontroller = null)
        {
            _controllers ??= new Dictionary<string, BaseController>();

            if (nameController == null) return;
            if (_controllers.ContainsKey(nameController))
                _controllers[nameController] = addedcontroller;
            else
                _controllers.Add(nameController, addedcontroller);
        }
        private void DisposeControllers()
        {
            foreach(var controller in _controllers.Values)
                controller?.Dispose();
        }
    }
}