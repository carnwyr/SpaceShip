namespace carnapps.GameRuntime.Collectables.Abstract
{
    using carnapps.GameViewSystem.Abstract;
    using UnityEngine;

    public abstract class CollectableView<T> : View<T> where T: IViewModel 
    {
        public abstract void Collect();
        
        public void OnCollisionEnter(Collision collision) => Collect();

    }
}