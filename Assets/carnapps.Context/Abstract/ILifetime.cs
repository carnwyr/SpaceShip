namespace carnapps.Context.Abstract
{
    using System;
    using UniRx;

    public interface ILifetime : IDisposable
    {
        CompositeDisposable LifetimeContext { get; }
        ILifetime AddTo(ILifetime lifetime);
    }
}