using carnapps.Context.Abstract;
using carnapps.GameViewSystem.Abstract;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace carnapps.GameRuntime.GUI
{
    public class GUIView : View<GUIViewModel>
    {
        [SerializeField] private Slider _fuelSlider;

        public override async UniTask Initialize(GUIViewModel viewModel)
        {
            await base.Initialize(viewModel);

            Bind(viewModel.FuelAmount, x => _fuelSlider.value = x);
        }
    }
}