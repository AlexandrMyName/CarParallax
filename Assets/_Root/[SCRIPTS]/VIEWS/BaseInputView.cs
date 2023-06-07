using System.Collections;
using System.Collections.Generic;
using Tools.React;
using UnityEngine;


namespace Game.UI
{
    internal class BaseInputView : MonoBehaviour
    {
        private SubscriptionProperty<float> _leftMove;
        private SubscriptionProperty<float> _rightMove;


        public void Init(
            IReadOnlySubscriptionProperty<float> leftMove,
            IReadOnlySubscriptionProperty<float> rightMove
            ){
            _leftMove = (SubscriptionProperty<float>) leftMove;
            _rightMove = (SubscriptionProperty<float>) rightMove;
        }

        protected void OnLeftMove(float value) => _leftMove.Value = value;
       
        protected void OnRightMove(float value) => _rightMove.Value = value;
         
    }
}
