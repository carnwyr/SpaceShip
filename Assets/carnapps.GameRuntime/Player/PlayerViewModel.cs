namespace carnapps.GameRuntime.Player
{
    using carnapps.GameViewSystem.Abstract;
    using UniRx;
    using UnityEngine;

    public class PlayerViewModel : ViewModel
    {
        private readonly float _fuelSpendingRate;

        private readonly IReactiveProperty<float> _fuel = new ReactiveProperty<float>();

        public float MaxFuel { get; }
        public IReadOnlyReactiveProperty<float> Fuel => _fuel;

        public PlayerViewModel(float fuel, float fuelSpendingRate)
        {
            MaxFuel = fuel;
            _fuel.Value = MaxFuel;
            _fuelSpendingRate = fuelSpendingRate;
        }

        public bool TrySpendFuel(float spendingModifier) {
            if (_fuel.Value > 0) 
            {
                var spendingRate = (1 - _fuelSpendingRate) * spendingModifier + _fuelSpendingRate;
                _fuel.Value -= spendingRate;
                return true;
            }
            return false;
        }

        public void AddFuel(float fuelAmount)
        {
            _fuel.Value = Mathf.Min(_fuel.Value + fuelAmount, MaxFuel);
        }
    }
}