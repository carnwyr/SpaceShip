namespace carnapps.GameRuntime.Collectables
{
    using carnapps.Context.Abstract;
    using carnapps.GameViewSystem;
    using carnapps.Services;
    using carnapps.Services.Abstract;
    using UnityEngine;
    using System.Collections.Generic;

    [CreateAssetMenu(menuName = "carnapps/"+nameof(CollectablesServiceSource), fileName = nameof(CollectablesServiceSource))]
    public class CollectablesServiceSource : ServiceSource
    {
        [SerializeField] private List<CollectableConfig> _collectables;

        private IList<CollectableService> _services = new List<CollectableService>();

        public override IService CreateService(IContext context)
        {
            var viewSystem = context.Get<ViewSystem>();

            var service = new CollectableService(_collectables);
            context.Publish(service);

            return service;
        }
    }
}