using Game.Models;
using Tools.React;
using UnityEngine;

namespace Game.Controllers
{
    internal class GameController : BaseController
    {
        private IReadOnlySubscriptionProperty<float> _leftMove;
        private IReadOnlySubscriptionProperty<float> _rightMove;
        private InputController _inputController;
        private BackGroundController _backGroundController;
        private CarController _carController;
        private AbilityController _abilityController;
        private ObstacleController _obstacleController;
        public GameController(Profile profile, Transform placeForUI)
        {
            _leftMove = new SubscriptionProperty<float>();
            _rightMove = new SubscriptionProperty<float>();

            //////////////[GAME CONTROLLER]\\\\\\\\\\\\\\\\\
            _carController = new CarController(profile, _leftMove,_rightMove);
            _inputController = new InputController(profile, _leftMove, _rightMove);
            _backGroundController = new BackGroundController(_leftMove, _rightMove,profile);
            _abilityController = new AbilityController(placeForUI, _carController, profile);
            _obstacleController = new ObstacleController(profile, _leftMove, _rightMove);
            AddDisposableObject(_carController);
            AddDisposableObject(_backGroundController);
            AddDisposableObject(_inputController);
            AddDisposableObject(_abilityController);
            AddDisposableObject(_obstacleController);
        }

        
    }
}
