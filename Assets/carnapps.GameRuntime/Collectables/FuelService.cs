namespace carnapps.GameRuntime.Collectables
{
    using carnapps.Services.Abstract;
    using UniRx;
    using carnapps.GameViewSystem;
    using carnapps.GameRuntime.Player;

    // TODO pooling
    public class FuelService : IService
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();
        private readonly ViewSystem _viewSystem;
        private readonly PlayerService _playerService;

        private int _currentCount;

        public FuelService(ViewSystem viewSystem, PlayerService playerService, int maxCount, CollectableView fuelPrefab)
        {
            _viewSystem = viewSystem;
            _playerService = playerService;

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
            var viewModel = new FuelViewModel(_playerService);
            var view = _viewSystem.Create(fuelPrefab, viewModel);
            _currentCount++;

            //view.de => count--
        }

        public void Dispose() 
        {
            _disposables.Dispose();
        }
    }
}