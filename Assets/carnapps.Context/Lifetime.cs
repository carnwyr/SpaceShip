namespace carnapps.Context
{
    using UniRx;
    using carnapps.Context.Abstract;

    public class Lifetime : ILifetime
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();

        public CompositeDisposable LifetimeContext => _disposables;

        public ReactiveCommand<Unit> OnDisposed { get; } = new ReactiveCommand<Unit>();

        public ILifetime AddTo(ILifetime lifetime)
        {
            return this.AddTo(lifetime.LifetimeContext);
        }

        public virtual void Dispose()
        {
            _disposables.Dispose();
            OnDisposed.Execute(Unit.Default);
            OnDisposed.Dispose();
        }
    }
}