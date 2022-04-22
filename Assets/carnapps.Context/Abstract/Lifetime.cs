namespace carnapps.Context.Abstract
{
    using UniRx;
    using carnapps.Context.Abstract;

    public abstract class Lifetime : ILifetime
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();

        public CompositeDisposable LifetimeContext => _disposables;

        public ILifetime AddTo(ILifetime lifetime)
        {
            return this.AddTo(lifetime.LifetimeContext);
        }

        public virtual void Dispose()
        {
            _disposables.Dispose();
        }
    }
}