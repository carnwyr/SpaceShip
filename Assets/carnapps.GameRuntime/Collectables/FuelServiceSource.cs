using carnapps.Context.Abstract;
using carnapps.GameRuntime.Player;
using carnapps.GameViewSystem;
using carnapps.Services;
using carnapps.Services.Abstract;
using UnityEngine;

namespace carnapps.GameRuntime.Collectables
{
    [CreateAssetMenu(menuName = "carnapps/" + nameof(FuelServiceSource), fileName = nameof(FuelServiceSource))]
    public class FuelServiceSource : ServiceSource
    {
        [SerializeField] private int _maxCurrentCount;
        [SerializeField] private CollectableView _collectableObject;

        public CollectableView CollectableObject => _collectableObject;
        public int MaxCurrentCount => _maxCurrentCount;

        public override IService CreateService(IContext context)
        {
            var viewSystem = context.Get<ViewSystem>();
            var playerService = context.Get<PlayerService>();
            var positioningService = context.Get<PositioningService>();

            var service = new FuelService(viewSystem, playerService, positioningService, _maxCurrentCount, _collectableObject);

            context.Publish(service);
            return service;
        }
    }
}