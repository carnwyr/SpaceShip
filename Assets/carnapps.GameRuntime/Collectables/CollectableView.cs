namespace carnapps.GameRuntime.Collectables
{
    using carnapps.GameViewSystem.Abstract;
    using carnapps.GameRuntime.Collectables.Abstract;
    using UnityEngine;
    using System;

    [Serializable]
    public class CollectableView : View<CollectableViewModel>
    {
        [SerializeField] private Rigidbody2D _rigidbody;

        public override void Initialize(CollectableViewModel viewModel)
        {
            base.Initialize(viewModel);
            
            RandomizePosition();
        }

        public void RandomizePosition()
        {
            // TODO randomize position
            RectTransform.anchoredPosition = new Vector2(0, 400);
        }

        public void Collect()
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