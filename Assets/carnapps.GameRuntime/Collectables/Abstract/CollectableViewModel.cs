namespace carnapps.GameRuntime.Collectables.Abstract
{
    using carnapps.GameViewSystem.Abstract;
    using System;

    [Serializable]
    public abstract class CollectableViewModel : ViewModel 
    {
        public abstract void Collect();
    }
}