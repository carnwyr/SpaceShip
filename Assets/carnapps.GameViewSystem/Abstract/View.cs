using System;
using System.Threading;
using carnapps.Context;
using carnapps.Context.Abstract;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace carnapps.GameViewSystem.Abstract
{
    [RequireComponent(typeof(RectTransform))]
    public abstract class View<T> : MonoBehaviour, IView<T> where T : IViewModel
    {
        private readonly ILifetime _lifetime = new Lifetime();

        protected T ViewModel;

        public RectTransform RectTransform => transform as RectTransform;
        public CompositeDisposable LifetimeContext => _lifetime.LifetimeContext;
        public ReactiveCommand<Unit> OnDisposed => _lifetime.OnDisposed;
        public ILifetime AddTo(ILifetime lifetime) => _lifetime.AddTo(lifetime);
        public CancellationToken AsCancellationToken() => _lifetime.AsCancellationToken();

        public virtual UniTask Initialize(T viewModel)
        {
            ViewModel = viewModel;
            ViewModel.AddTo(_lifetime);
            _lifetime.AddTo(gameObject);
            return UniTask.CompletedTask;
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