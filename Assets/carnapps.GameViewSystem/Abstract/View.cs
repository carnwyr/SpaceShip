namespace carnapps.GameViewSystem.Abstract
{
    using UnityEngine;
    using UniRx;
    using System;

    [RequireComponent(typeof(RectTransform))]
    public abstract class View<T> : MonoBehaviour, IView<T> where T: IViewModel
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();

        protected T ViewModel;
        
        public RectTransform RectTransform => transform as RectTransform;
        
        public virtual void Initialize(T viewModel)
        {
            ViewModel = viewModel;
            ViewModel.AddTo(_disposables);
        }

        public virtual void Dispose() 
        {
            _disposables.Dispose();
        }

        protected View<T> Bind<V>(IObservable<V> observable, Action<V> action)
        {
            observable
                .Subscribe(x => action(x))
                .AddTo(_disposables);
            return this;
        }
    }
}