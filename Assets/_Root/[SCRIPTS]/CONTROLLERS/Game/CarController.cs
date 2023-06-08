using Configs.Inventory;
using Game.Models;
using Game.UI;
using System.Collections;
using System.Collections.Generic;
using Tools;
using Tools.React;
using UnityEngine;

namespace Game.Controllers
{
    internal class CarController : BaseController, IAbilityActivator
    {
        private readonly ResourcesPath _pathTool = new ResourcesPath("[PREFABS]/[VIEWS]/CarView");

        private CarView _view;
        private readonly Profile _profile;
        private readonly SubscriptionProperty<float> _diff;

        private readonly IReadOnlySubscriptionProperty<float> _leftMove;
        private readonly IReadOnlySubscriptionProperty<float> _rightMove;

        public GameObject ViewGameObject =>  _view.gameObject;

        public CarController(Profile profile, 
            IReadOnlySubscriptionProperty<float> leftMove,
            IReadOnlySubscriptionProperty<float> rightMove)
            ////////////[CAR CONTROLLER]\\\\\\\\\\\\\\\\
        {
            _diff = new SubscriptionProperty<float>();
            _rightMove = rightMove;
            _leftMove = leftMove;
            _profile = profile;
            _view = LoadView();
            _view.Init(_diff, 1);
            _rightMove.Subscribe(OnRightMove);
            _leftMove.Subscribe(OnLeftMove);
        }
        private CarView LoadView(Transform placeForUI = null)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab<GameObject>(_pathTool);
            GameObject viewOnScene = Object.Instantiate(prefab);
            AddGameObjects(viewOnScene);
            return viewOnScene.GetComponent<CarView>();
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
