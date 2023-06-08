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

        public GameController(Profile profile, Transform placeForUI)
        {
            _leftMove = new SubscriptionProperty<float>();
            _rightMove = new SubscriptionProperty<float>();

            //////////////[GAME CONTROLLER]\\\\\\\\\\\\\\\\\
            _carController = new CarController(profile, _leftMove,_rightMove);
            _inputController = new InputController(profile, _leftMove, _rightMove);
            _backGroundController = new BackGroundController(_leftMove, _rightMove,profile);
            AddController(_carController);
            AddController(_backGroundController);
            AddController(_inputController);
        }

        
    }
}
