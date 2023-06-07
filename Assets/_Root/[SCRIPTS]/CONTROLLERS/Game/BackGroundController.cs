using Game.Models;
using Game.UI;
using Tools.React;
using Tools;
using UnityEngine;


namespace Game.Controllers
{
    internal class BackGroundController : BaseController
    {

        private SubscriptionProperty<float> _diff;
        IReadOnlySubscriptionProperty<float> _leftMove;
        IReadOnlySubscriptionProperty<float> _rightMove;
        private readonly ResourcesPath _pathTool = new ResourcesPath("[PREFABS]/[VIEWS]/BackGroundView");
        private BackGroundView _view;
      

        public BackGroundController( 
            IReadOnlySubscriptionProperty<float> left,
            IReadOnlySubscriptionProperty<float> right)
        {
            ///////////////[BackGround]\\\\\\\\\\\\\\
            ///
            _leftMove = left;
            _rightMove = right;
            _diff = new SubscriptionProperty<float>();
            _leftMove.Subscribe(UpdateTilesLeft);
            _rightMove.Subscribe(UpdateTilesRight);

            _view = LoadView();
            _view.Init(_diff);
        }
        public override void OnDisposable()
        {
            _rightMove.Unsubscribe(UpdateTilesRight);
            _leftMove.Unsubscribe(UpdateTilesLeft);
        }
        private void UpdateTilesLeft(float value) => _diff.Value = value;
        private void UpdateTilesRight(float value) => _diff.Value = value;
        private BackGroundView LoadView(Transform placeForUI = null)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab<GameObject>(_pathTool);
            GameObject viewOnScene = Object.Instantiate(prefab);
            AddGameObjects(viewOnScene);
            return viewOnScene.GetComponent<BackGroundView>();
        }
    }
}
