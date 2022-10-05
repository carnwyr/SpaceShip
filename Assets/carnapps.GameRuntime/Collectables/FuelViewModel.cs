using carnapps.GameRuntime.Collectables.Abstract;
using carnapps.GameRuntime.Player;
using carnapps.Services;

namespace carnapps.GameRuntime.Collectables
{
    public class FuelViewModel : CollectableViewModel
    {
        private readonly float _fuelAmount = 100;
        private readonly PlayerService _playerService;

        public FuelViewModel(PlayerService playerService, PositioningService positioningService) : base(
            positioningService)
        {
            //_fuelAmount = fuelAmount;
            _playerService = playerService;
        }

        public override void Collect()
        {
            _playerService.AddFuel(_fuelAmount);
        }
    }
}