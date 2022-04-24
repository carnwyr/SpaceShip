namespace carnapps.GameViewSystem.Abstract
{
    using System;
    using UniRx;
    using carnapps.Context;

    public abstract class ViewModel : Lifetime, IViewModel
    {
        protected ViewModel Bind<V>(IObservable<V> observable, Action<V> action)
        {
            observable
                .Subscribe(x => action(x))
                .AddTo(this);
            return this;
        }
    }
}