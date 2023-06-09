using Game.Models;
using Game.UI;
using Tools.React;
using Tools;
using UnityEngine;

namespace Game.Controllers
{
    internal class ObstacleController : BaseController
    {

        private readonly ResourcesPath _pathTool = new ResourcesPath("[PREFABS]/[VIEWS]/ObstaclesView");

        private ObstaclesView _view;
        private readonly Profile _profile;
        private readonly SubscriptionProperty<float> _diff;

        private readonly IReadOnlySubscriptionProperty<float> _leftMove;
        private readonly IReadOnlySubscriptionProperty<float> _rightMove;

        

        public ObstacleController(Profile profile,
            IReadOnlySubscriptionProperty<float> leftMove,
            IReadOnlySubscriptionProperty<float> rightMove)
        ////////////[OBSTACLE CONTROLLER]\\\\\\\\\\\\\\\\
        {
            _diff = new SubscriptionProperty<float>();
            _rightMove = rightMove;
            _leftMove = leftMove;
            _profile = profile;
            _view = LoadView();
            _view.Init(_diff,_profile.Car);
            _rightMove.Subscribe(OnRightMove);
            _leftMove.Subscribe(OnLeftMove);
        }
        private ObstaclesView LoadView(Transform placeForUI = null)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab<GameObject>(_pathTool);
            GameObject viewOnScene = Object.Instantiate(prefab);
            AddGameObjects(viewOnScene);
            return viewOnScene.GetComponent<ObstaclesView>();
        }
        public override void OnDisposable()
        {
            _rightMove.Unsubscribe(OnRightMove);
            _leftMove.Unsubscribe(OnLeftMove);
        }
        private void OnRightMove(float value) => _diff.Value = value;
        private void OnLeftMove(float value) => _diff.Value = value;

    }
}
