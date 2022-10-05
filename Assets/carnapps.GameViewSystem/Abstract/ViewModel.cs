using System;
using carnapps.Context;
using UniRx;

namespace carnapps.GameViewSystem.Abstract
{
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