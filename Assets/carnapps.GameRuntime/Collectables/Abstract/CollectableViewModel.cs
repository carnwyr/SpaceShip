using System;
using carnapps.GameViewSystem.Abstract;
using carnapps.Services;

namespace carnapps.GameRuntime.Collectables.Abstract
{
    [Serializable]
    public abstract class CollectableViewModel : ViewModel
    {
        public PositioningService PositioningService { get; }

        public abstract void Collect();

        public CollectableViewModel(PositioningService positioningService)
        {
            PositioningService = positioningService;
        }
    }
}