using carnapps.Context.Abstract;
using carnapps.Services.Abstract;
using UnityEngine;

namespace carnapps.Services
{
    [CreateAssetMenu(menuName = "carnapps/" + nameof(PositioningServiceSource),
        fileName = nameof(PositioningServiceSource))]
    public class PositioningServiceSource : ServiceSource
    {
        [SerializeField] private float _noSpawnBorder = 100;
        
        public override IService CreateService(IContext context)
        {
            var positioningService = new PositioningService(_noSpawnBorder);
            context.Publish(positioningService);
            return positioningService;
        }
    }
}