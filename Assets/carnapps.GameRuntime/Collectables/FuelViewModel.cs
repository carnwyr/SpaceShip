namespace carnapps.GameRuntime.Collectables
{
    using carnapps.GameViewSystem.Abstract;
    using carnapps.GameRuntime.Player;

    public class FuelViewModel : ViewModel
    {
        private readonly float _fuelAmount;
        private readonly PlayerService _playerService;

        public FuelViewModel(float fuelAmount, PlayerService playerService)
        {
            _fuelAmount = fuelAmount;
            _playerService = playerService;
        }

        public void Collect()
        {
            _playerService.AddFuel(_fuelAmount);
        }
    }
}