namespace carnapps.GameRuntime.Player
{
    using carnapps.Context.Abstract;
    using carnapps.GameViewSystem;
    using carnapps.Services;
    using carnapps.Services.Abstract;
    using UnityEngine;
    
    [CreateAssetMenu(menuName = "carnapps/"+nameof(PlayerServiceSource), fileName = nameof(PlayerServiceSource))]
    public class PlayerServiceSource : ServiceSource
    {
        [SerializeField] private PlayerView _player;
        [SerializeField] private float _maxFuel;
        [SerializeField] private float _fuelSpendingRate;
        
        public override IService CreateService(IContext context)
        {
            var viewSystem = context.Get<ViewSystem>();
            var attractorService = context.Get<IAttractorService>();
            
            var service = new PlayerService(viewSystem, attractorService, _player, _maxFuel, _fuelSpendingRate);
            context.Publish(service);

            return service;
        }
    }
}