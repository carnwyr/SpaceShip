namespace carnapps.GameRuntime.BlackHole
{
    using System;
    using System.Collections.Generic;
    using carnapps.GameViewSystem;
    using carnapps.Services.Abstract;
    using UniRx;
    using UnityEngine;

    public class BlackHoleService : IAttractorService
    {
        private readonly BlackHoleView  _blackHole;
        private readonly IList<IDisposable> _attractedObjects = new List<IDisposable>();
        private float _maxDistance;

        public BlackHoleService(ViewSystem viewSystem, BlackHoleView blackHole)
        {
            var viewModel = new BlackHoleViewModel();            
            _blackHole = viewSystem.Create(blackHole, viewModel);

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
            _attractedObjects.Add(attractedObject);
        }

        public void Dispose()
        {
            foreach (var target in _attractedObjects)
            {
                target.Dispose();
            }
        }
    }
}