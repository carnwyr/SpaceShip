namespace carnapps.GameViewSystem.Abstract
{
    using UnityEngine;
    using UniRx;
    using System;
    using carnapps.Context.Abstract;
    using carnapps.Context;

    [RequireComponent(typeof(RectTransform))]
    public abstract class View<T> : MonoBehaviour, IView<T> where T: IViewModel
    {
        private readonly ILifetime _lifetime = new Lifetime();

        protected T ViewModel;
        
        public RectTransform RectTransform => transform as RectTransform;
        public CompositeDisposable LifetimeContext => _lifetime.LifetimeContext;
        public ReactiveCommand<Unit> OnDisposed => _lifetime.OnDisposed;
        public ILifetime AddTo(ILifetime lifetime) => _lifetime.AddTo(lifetime);

        public virtual void Initialize(T viewModel)
        {
            ViewModel = viewModel;
            ViewModel.AddTo(_lifetime);
            _lifetime.AddTo(gameObject);
        }

        public virtual void Dispose() 
        {
            Destroy(gameObject);
        }

        protected View<T> Bind<V>(IObservable<V> observable, Action<V> action)
        {
            observable
                .Subscribe(x => action(x))
                .AddTo(_lifetime);
            return this;
        }
    }
}