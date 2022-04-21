namespace carnapps.Services.Abstract
{
    using carnapps.GameViewSystem.Abstract;
    using UnityEngine;

    public interface IAttractable : IViewBase
    {
        void Gravitate(Vector2 attractor, float attractionForce);
    }
}