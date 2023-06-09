using JoostenProductions;
using System;
using System.Collections;
using System.Collections.Generic;
using Tools.React;
using UnityEngine;


namespace Game.UI
{
    internal abstract class BaseInputView : MonoBehaviour
    {
        private SubscriptionProperty<float> _leftMove;
        private SubscriptionProperty<float> _rightMove;
        private Action _backAction;
        private Action _cachedBackMethod;

        public void Init(
            IReadOnlySubscriptionProperty<float> leftMove,
            IReadOnlySubscriptionProperty<float> rightMove
            ){
            _leftMove = (SubscriptionProperty<float>) leftMove;
            _rightMove = (SubscriptionProperty<float>) rightMove;
        }
        private void Awake() => UpdateManager.SubscribeToUpdate(Move);
        private void OnDestroy()
        {
            UpdateManager.UnsubscribeFromUpdate(Move);
            DeInitBackMethod();
        }

        
        protected abstract void Move();
        public void InitBackMethod(Action backMethod)
        {
            _cachedBackMethod = backMethod;
            _backAction += _cachedBackMethod;  
        }
        protected void DeInitBackMethod()
        {
            if( _cachedBackMethod != null )
                    _backAction -= _cachedBackMethod;
        }

        protected void BackToMenu() => _backAction?.Invoke();
        protected void OnLeftMove(float value) => _leftMove.Value = value;
        protected void OnRightMove(float value) => _rightMove.Value = value;
         
    }
}
