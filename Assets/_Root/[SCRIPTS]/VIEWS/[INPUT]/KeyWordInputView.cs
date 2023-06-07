using JoostenProductions;
using UnityEngine;

namespace Game.UI
{
    internal class KeyWordInputView : BaseInputView
    {
        [SerializeField] private float _sensetivity = 1f;
        private void Awake() => UpdateManager.SubscribeToUpdate(Move);
        private void OnDestroy() => UpdateManager.UnsubscribeFromUpdate(Move);

        private void Move()
        {
            float horizontalAxis = Input.GetAxis("Horizontal");

            float mainValue = horizontalAxis * _sensetivity *  Time.deltaTime;

            if(horizontalAxis > 0) OnRightMove(mainValue);
            else if(horizontalAxis < 0 ) OnLeftMove(mainValue);
        }
    }
}