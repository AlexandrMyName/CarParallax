using System;
using UnityEngine;

namespace Tools.React
{
    internal class SubscriptionProperty<T> : IReadOnlySubscriptionProperty<T>
    {
        private T _value;
        private Action<T> _action;
        public T Value { 
            get => _value;
            set
            {
                _value = value;
                _action?.Invoke(_value);
                
            }
        }

        public void Subscribe(Action<T> method) => _action += method;
        public void Unsubscribe(Action<T> method) => _action -= method;
        
    }
}