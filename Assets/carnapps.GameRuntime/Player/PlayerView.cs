using System;
using carnapps.GameViewSystem.Abstract;
using carnapps.Services.Abstract;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace carnapps.GameRuntime.Player
{
    public class PlayerView : View<PlayerViewModel>, IAttractable
    {
        [SerializeField] private Rigidbody2D _rigidbody;

        private IDisposable _inputSubscription;

        private float _attractionForce;

        public override async UniTask Initialize(PlayerViewModel viewModel)
        {
            await base.Initialize(viewModel);

            ResetPosition();

            _inputSubscription = Observable.EveryFixedUpdate().Subscribe(_ => ProcessInput());
        }

        public void ResetPosition()
        {
            // TODO randomize start position
            RectTransform.anchoredPosition = new Vector2(0, -400);
        }

        public void MoveTowards(Vector2 destination, float strength = 1)
        {
            var dir = (destination - RectTransform.anchoredPosition);
            _rigidbody.AddForce(dir * strength);
        }

        public void Gravitate(Vector2 attractor, float attractionForce)
        {
            var distance = (attractor - (Vector2) RectTransform.anchoredPosition).magnitude;
            MoveTowards(attractor, attractionForce);
            _attractionForce = attractionForce;
        }

        private void ProcessInput()
        {
            if (!Input.GetMouseButton(0)) return;

            if (!ViewModel.TrySpendFuel(_attractionForce)) return;

            var pos = Input.mousePosition - new Vector3(Screen.width / 2f, Screen.height / 2f, 0);
            MoveTowards(pos);
        }


        public override void Dispose()
        {
            base.Dispose();

            _inputSubscription?.Dispose();
        }
    }
}