namespace carnapps.GameRuntime.Collectables
{
    using carnapps.GameViewSystem.Abstract;
    using carnapps.GameRuntime.Collectables.Abstract;
    using UnityEngine;
    using System;

    [Serializable]
    [RequireComponent(typeof(Collider2D))]
    public class CollectableView : View<CollectableViewModel>
    {
        [SerializeField] private string _playerTag;

        public override void Initialize(CollectableViewModel viewModel)
        {
            base.Initialize(viewModel);
            
            RandomizePosition();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag.Equals(_playerTag, StringComparison.OrdinalIgnoreCase)) {
                Collect();
            }
        }

        // TODO revamp
        public void RandomizePosition()
        {
            var posX = UnityEngine.Random.Range(0 - Screen.width / 2f, Screen.width / 2f);
            var posY = UnityEngine.Random.Range(0 - Screen.height / 2f, Screen.height / 2f);
            RectTransform.anchoredPosition = new Vector2(posX, posY);
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