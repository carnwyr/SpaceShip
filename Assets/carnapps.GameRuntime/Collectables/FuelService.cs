namespace carnapps.GameRuntime.Collectables
{
    using carnapps.Services.Abstract;
    using System.Collections.Generic;
    using UniRx;
    using carnapps.GameViewSystem;
    using carnapps.GameRuntime.Collectables.Abstract;

    // TODO pooling
    public class FuelService : IService
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();
        private readonly ViewSystem _viewSystem;

        private int _currentCount;

        public FuelService(ViewSystem viewSystem, int maxCount, CollectableView fuelPrefab)
        {
            _viewSystem = viewSystem;

            var collectableController = Observable.EveryUpdate()
                .Subscribe(_ => {
                    if (_currentCount < maxCount) 
                    {
                        Spawn(fuelPrefab);
                    }
                })
                .AddTo(_disposables);
        }

        private void Spawn(CollectableView fuelPrefab)
        {
            var viewModel = new FuelViewModel();
            var view = _viewSystem.Create(fuelPrefab, viewModel);

            //view.de => count--
        }

        public void Dispose() 
        {
            _disposables.Dispose();
        }
    }
}