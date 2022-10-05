using carnapps.Context.Abstract;
using carnapps.Services.Abstract;
using UnityEngine;

namespace carnapps.Services
{
    [CreateAssetMenu(menuName = "carnapps/" + nameof(PositioningServiceSource),
        fileName = nameof(PositioningServiceSource))]
    public class PositioningServiceSource : ServiceSource
    {
        public override IService CreateService(IContext context)
        {
            var positioningService = new PositioningService();
            context.Publish(positioningService);
            return positioningService;
        }
    }
}