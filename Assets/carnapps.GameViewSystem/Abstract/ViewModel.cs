namespace carnapps.GameViewSystem.Abstract
{
    using System;
    using UniRx;

    public abstract class ViewModel : IViewModel
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();

        public virtual void Dispose() 
        {
            _disposables.Dispose();
        }

        protected ViewModel Bind<V>(IObservable<V> observable, Action<V> action)
        {
            observable
                .Subscribe(x => action(x))
                .AddTo(_disposables);
            return this;
        }
    }
}