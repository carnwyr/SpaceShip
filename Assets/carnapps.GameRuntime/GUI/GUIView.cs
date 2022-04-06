namespace carnapps.GameRuntime.GUI
{
    using carnapps.GameViewSystem.Abstract;
    using UnityEngine.UI;
    using UnityEngine;

    public class GUIView : View<GUIViewModel>
    {
        [SerializeField] private Slider _fuelSlider;

        public override void Initialize(GUIViewModel viewModel)
        {
            base.Initialize(viewModel);

            Bind(viewModel.FuelAmount, x => _fuelSlider.value = x);
        }
    }
}