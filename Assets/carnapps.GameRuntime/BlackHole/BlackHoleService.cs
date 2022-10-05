using carnapps.Context;
using carnapps.GameViewSystem;
using carnapps.Services.Abstract;
using UniRx;
using UnityEngine;

namespace carnapps.GameRuntime.BlackHole
{
    public class BlackHoleService : Service, IAttractorService
    {
        private readonly BlackHoleView _blackHole;
        private float _maxDistance;

        public BlackHoleService(ViewSystem viewSystem, BlackHoleView blackHolePrefab)
        {
            var viewModel = new BlackHoleViewModel();
            _blackHole = viewSystem.Create(blackHolePrefab, viewModel);

            var farthestPoint = new Vector2(Screen.width / 2, Screen.height / 2);
            _maxDistance = farthestPoint.magnitude;
        }

        public void Attract(IAttractable target)
        {
            var attractedObject = Observable.EveryFixedUpdate().Subscribe(_ =>
            {
                var gravityDirection = _blackHole.RectTransform.position - target.RectTransform.position;
                var attractionForce = Mathf.Pow(Mathf.Clamp01(gravityDirection.magnitude / _maxDistance) - 1, 2);
                target.Gravitate(gravityDirection.normalized, attractionForce);
            });
            attractedObject.AddTo(this);
        }
    }
}