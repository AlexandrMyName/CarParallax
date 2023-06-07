
using System;

namespace Tools.React
{
    internal interface IReadOnlySubscriptionProperty<out T>
    {
        T Value { get; }

        void Subscribe(Action<T> method);
        void Unsubscribe(Action<T> method);
    }
}