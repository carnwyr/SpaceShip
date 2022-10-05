using carnapps.GameViewSystem.Abstract;
using UniRx;

namespace carnapps.GameRuntime.GUI
{
    public class GUIViewModel : ViewModel
    {
        public IReactiveProperty<float> FuelAmount { get; }

        public GUIViewModel(IReactiveProperty<float> fuel)
        {
            FuelAmount = fuel;
        }
    }
}