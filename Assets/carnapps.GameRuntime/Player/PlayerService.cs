namespace carnapps.GameRuntime.Player
{
    using carnapps.GameViewSystem;
    using carnapps.Services.Abstract;
    using UniRx;
    using System;
    using UnityEngine;

    public class PlayerService : IService
    {
        private readonly PlayerViewModel _playerViewModel;

        private IDisposable _fuelSubscription;

        public IReactiveProperty<float> Fuel { get; } = new ReactiveProperty<float>();

        public PlayerService(ViewSystem viewSystem, IAttractorService attractorService, PlayerView player, float fuel, float fuelSpendingRate)
        {
            _playerViewModel = new PlayerViewModel(fuel, fuelSpendingRate);
            var playerView = viewSystem.Create(player, _playerViewModel);
            
            attractorService.Attract(playerView);

            _fuelSubscription = _playerViewModel.Fuel
                .Subscribe(x => Fuel.Value = Mathf.Clamp01(x / _playerViewModel.MaxFuel));
        }

        public void AddFuel(float fuelAmount) => _playerViewModel.AddFuel(fuelAmount);

        public void Dispose() {
            _fuelSubscription?.Dispose();
        }
    }
}