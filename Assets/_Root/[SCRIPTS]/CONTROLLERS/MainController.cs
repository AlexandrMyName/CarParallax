using Game.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers
{
    internal class MainController : BaseController
    {
        private readonly Transform _placeForUI;
        private readonly Profile _profile;
        
        private MainMenuController _menuMainController;
        private SettingsController _settingsController;
        private GameController _gameController;
        public MainController(Profile profile,Transform placeForUI)
        {
            _placeForUI = placeForUI;
            _profile = profile;
            _profile._reactGameState.Subscribe(OnChangeGameState);
            OnChangeGameState(_profile._reactGameState.Value);
            
        }

        public override void OnDisposable()
        {
            _profile._reactGameState.Unsubscribe(OnChangeGameState);

            _menuMainController?.Dispose();
            _gameController?.Dispose();
            _settingsController?.Dispose();
        }



        private void OnChangeGameState(GameState state)
        {
             
            switch (state)
            {
                case GameState.Menu:
                    _menuMainController = new MainMenuController(_profile, _placeForUI);
                    _settingsController?.Dispose();
                    _gameController?.Dispose();
                    break;
                case GameState.Game:
                    _gameController = new GameController(_profile, _placeForUI);
                    _menuMainController?.Dispose();
                    _settingsController?.Dispose();
                    break;
                case GameState.Settings:
                    _settingsController = new SettingsController(_profile, _placeForUI);
                    _menuMainController?.Dispose();
                    _gameController?.Dispose();
                    break;
                case GameState.Inventory:
                    _menuMainController?.Dispose();
                    _settingsController?.Dispose();
                    _gameController?.Dispose();
                    break;

                 default:
                    _menuMainController?.Dispose();
                    _settingsController?.Dispose();
                    _gameController?.Dispose();
                    break;

            }
        }
    }
}