using System;

namespace Utilities.Reactive
{
    public interface IReadOnlyVariable<T>
    {
        T Value { get; }

        IDisposable Subscribe(Action<T, T> action);
    }
}
