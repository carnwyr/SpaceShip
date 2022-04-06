namespace carnapps.GameRuntime.BlackHole
{
    using carnapps.Context.Abstract;
    using carnapps.GameViewSystem;
    using carnapps.Services;
    using carnapps.Services.Abstract;
    using UnityEngine;

    [CreateAssetMenu(menuName = "carnapps/"+nameof(BlackHoleServiceSource), fileName = nameof(BlackHoleServiceSource))]
    public class BlackHoleServiceSource : ServiceSource
    {
        [SerializeField] private BlackHoleView _blackHole;
        
        public override IService CreateService(IContext context)
        {
            var viewSystem = context.Get<ViewSystem>();
            
            var service = new BlackHoleService(viewSystem, _blackHole);
            
            context.Publish<IAttractorService>(service);
            return service;
        }
    }
}