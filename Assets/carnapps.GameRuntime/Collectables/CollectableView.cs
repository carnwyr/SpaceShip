using System;
using carnapps.GameRuntime.Collectables.Abstract;
using carnapps.GameViewSystem.Abstract;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace carnapps.GameRuntime.Collectables
{
    [Serializable]
    [RequireComponent(typeof(Collider2D))]
    public class CollectableView : View<CollectableViewModel>
    {
        [SerializeField] private string _playerTag;

        public override async UniTask Initialize(CollectableViewModel viewModel)
        {
            await base.Initialize(viewModel);

            RectTransform.anchoredPosition = viewModel.PositioningService.GetRandomPosition();
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag.Equals(_playerTag, StringComparison.OrdinalIgnoreCase))
            {
                Collect();
            }
        }

        public void Collect()
        {
            ViewModel.Collect();
            Dispose();
        }
    }
}