using System.Threading;
using carnapps.Context.Abstract;
using UniRx;

namespace carnapps.Context
{
    public class Lifetime : ILifetime
    {
        public CompositeDisposable LifetimeContext { get; } = new CompositeDisposable();

        public ReactiveCommand<Unit> OnDisposed { get; } = new ReactiveCommand<Unit>();

        public ILifetime AddTo(ILifetime lifetime)
        {
            return this.AddTo(lifetime.LifetimeContext);
        }

        public CancellationToken AsCancellationToken()
        {
            var source = new CancellationTokenSource();
            OnDisposed.Subscribe(_ => source.Cancel()).AddTo(this);
            return source.Token;
        }

        public virtual void Dispose()
        {
            LifetimeContext.Dispose();
            OnDisposed.Execute(Unit.Default);
            OnDisposed.Dispose();
        }
    }
}