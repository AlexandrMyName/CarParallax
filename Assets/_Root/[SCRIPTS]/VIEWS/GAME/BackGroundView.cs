using Game.Models;
using Tools.React;
using UnityEngine;

namespace Game.UI
{
    internal class BackGroundView : MonoBehaviour
    {
        private IReadOnlySubscriptionProperty<float> _diff;
        [SerializeField] private TileView[] _tiles; 

        public void Init(IReadOnlySubscriptionProperty<float> diff, CarModel carModel)
        {
            foreach(TileView tileView in _tiles)
            {
                tileView.Init(carModel);
            }


            _diff =  diff;
            _diff.Subscribe(Move);
        }
        private void OnDestroy() => _diff.Unsubscribe(Move);
        
        private void Move(float value)
        {
            foreach(var tile in _tiles)
                tile.Move(value);
             
        }

    }
}