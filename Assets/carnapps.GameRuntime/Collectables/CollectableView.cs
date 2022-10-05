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
        [SerializeField] private float _noSpawnBorder = 100;

        public override async UniTask Initialize(CollectableViewModel viewModel)
        {
            await base.Initialize(viewModel);

            RectTransform.anchoredPosition = viewModel.PositioningService.GetRandomPosition();

            RandomizePosition();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag.Equals(_playerTag, StringComparison.OrdinalIgnoreCase))
            {
                Collect();
            }
        }

        // TODO revamp, add positioning service
        public void RandomizePosition()
        {
            var posX = UnityEngine.Random.Range(_noSpawnBorder - Screen.width / 2f, Screen.width / 2f - _noSpawnBorder);
            var posY = UnityEngine.Random.Range(_noSpawnBorder - Screen.height / 2f,
                Screen.height / 2f - _noSpawnBorder);
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