namespace carnapps.GameRuntime.Collectables
{
    using carnapps.GameRuntime.Collectables.Abstract;
    using UnityEngine;

    public class FuelView : CollectableView<FuelViewModel>
    {
        [SerializeField] private Rigidbody2D _rigidbody;

        public override void Initialize(FuelViewModel viewModel)
        {
            base.Initialize(viewModel);
            
            RandomizePosition();
        }

        public void RandomizePosition()
        {
            // TODO randomize start position
            RectTransform.anchoredPosition = new Vector2(0, -400);
        }

        public override void Collect()
        {
            ViewModel.Collect();
            Dispose();
        }
        
        public override void Dispose()
        {
            base.Dispose();
        }
    }
}