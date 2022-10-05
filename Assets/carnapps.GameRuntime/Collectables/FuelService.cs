using carnapps.Context;
using carnapps.GameRuntime.Player;
using carnapps.GameViewSystem;
using carnapps.Services;
using carnapps.Services.Abstract;
using UniRx;

namespace carnapps.GameRuntime.Collectables
{
    // TODO pooling
    public class FuelService : Service
    {
        private readonly ViewSystem _viewSystem;
        private readonly PlayerService _playerService;
        private readonly PositioningService _positioningService;

        private int _currentCount;

        public FuelService(ViewSystem viewSystem, PlayerService playerService, PositioningService positioningService, 
            int maxCount, CollectableView fuelPrefab)
        {
            _viewSystem = viewSystem;
            _playerService = playerService;
            _positioningService = positioningService;

            var collectableController = Observable.EveryUpdate()
                .Subscribe(_ =>
                {
                    if (_currentCount < maxCount)
                    {
                        Spawn(fuelPrefab);
                    }
                })
                .AddTo(this);
        }

        private void Spawn(CollectableView fuelPrefab)
        {
            var viewModel = new FuelViewModel(_playerService, _positioningService);
            var view = _viewSystem.Create(fuelPrefab, viewModel);
            _currentCount++;

            view.OnDisposed.Subscribe(_ => _currentCount--).AddTo(this);
        }
    }
}