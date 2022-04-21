namespace carnapps.GameRuntime.Collectables
{
    using carnapps.Context.Abstract;
    using carnapps.GameViewSystem;
    using carnapps.Services;
    using carnapps.Services.Abstract;
    using UnityEngine;
    using carnapps.GameRuntime.Player;

    [CreateAssetMenu(menuName = "carnapps/"+nameof(FuelServiceSource), fileName = nameof(FuelServiceSource))]
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

            var service = new FuelService(viewSystem, playerService, _maxCurrentCount, _collectableObject);

            context.Publish(service);
            return service;
        }
    }
}