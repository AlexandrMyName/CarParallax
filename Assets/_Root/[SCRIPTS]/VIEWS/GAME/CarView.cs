using Game.Inventory;
using Tools.React;
using UnityEngine;


namespace Game.UI
{
    internal class CarView : MonoBehaviour
    {

        private IReadOnlySubscriptionProperty<float> _diff;
        private float _speedWeel;
        [SerializeField] GameObject _rightWeel;
        [SerializeField] GameObject _leftWeel;

        private Quaternion _rotation;
        public void Init(IReadOnlySubscriptionProperty<float> diff, float speedWeel)
        {
            _rotation = Quaternion.identity;
            _speedWeel = speedWeel;
            _diff = diff;
            _diff.Subscribe(RotateWeels);
            
        }
        private void RotateWeels(float value)
        {
           
            _leftWeel.transform.Rotate(Vector3.forward * (value < 0 ? 1 : -1) * _speedWeel);
            _rightWeel.transform.Rotate(Vector3.forward * (value < 0 ? 1 : -1) * _speedWeel);
        }
    }
}
