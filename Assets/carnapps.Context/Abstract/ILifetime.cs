using System;
using System.Threading;
using UniRx;

namespace carnapps.Context.Abstract
{
    public interface ILifetime : IDisposable
    {
        CompositeDisposable LifetimeContext { get; }
        ReactiveCommand<Unit> OnDisposed { get; }
        ILifetime AddTo(ILifetime lifetime);
        CancellationToken AsCancellationToken();
    }
}