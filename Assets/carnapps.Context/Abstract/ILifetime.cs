namespace carnapps.Context.Abstract
{
    using System;
    using UniRx;

    public interface ILifetime : IDisposable
    {
        CompositeDisposable LifetimeContext { get; }
        ReactiveCommand<Unit> OnDisposed { get; }
        ILifetime AddTo(ILifetime lifetime);
    }
}