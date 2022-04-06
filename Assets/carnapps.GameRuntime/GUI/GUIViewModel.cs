namespace carnapps.GameRuntime.GUI
{
    using carnapps.GameViewSystem.Abstract;
    using UniRx;

    public class GUIViewModel : ViewModel
    {
        public IReactiveProperty<float> FuelAmount { get; }

        public GUIViewModel(IReactiveProperty<float> fuel)
        {
            FuelAmount = fuel;
        }
    }
}