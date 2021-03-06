namespace carnapps.GameRuntime.Collectables
{
    using carnapps.GameRuntime.Collectables.Abstract;
    using carnapps.GameRuntime.Player;

    public class FuelViewModel : CollectableViewModel
    {
        private readonly float _fuelAmount = 100;
        private readonly PlayerService _playerService;

        public FuelViewModel(PlayerService playerService)
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