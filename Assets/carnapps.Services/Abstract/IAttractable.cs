namespace carnapps.Services.Abstract
{
    using carnapps.GameViewSystem.Abstract;
    using UnityEngine;

    public interface IAttractable : IView
    {
        void Gravitate(Vector2 attractor, float attractionForce);
    }
}