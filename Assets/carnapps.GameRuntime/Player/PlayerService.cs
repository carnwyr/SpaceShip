using carnapps.Context;
using carnapps.GameViewSystem;
using carnapps.Services.Abstract;
using UniRx;
using UnityEngine;

namespace carnapps.GameRuntime.Player
{
    public class PlayerService : Service
    {
        private readonly PlayerViewModel _playerViewModel;

        public IReactiveProperty<float> Fuel { get; } = new ReactiveProperty<float>();

        public PlayerService(ViewSystem viewSystem, IAttractorService attractorService, PlayerView player, float fuel,
            float fuelSpendingRate)
        {
            _playerViewModel = new PlayerViewModel(fuel, fuelSpendingRate);
            var playerView = viewSystem.Create(player, _playerViewModel);

            attractorService.Attract(playerView);

            _playerViewModel.Fuel
                .Subscribe(x => Fuel.Value = Mathf.Clamp01(x / _playerViewModel.MaxFuel))
                .AddTo(this);
        }

        public void AddFuel(float fuelAmount) => _playerViewModel.AddFuel(fuelAmount);
    }
}