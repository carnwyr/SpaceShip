using carnapps.GameViewSystem.Abstract;
using UnityEngine;

namespace carnapps.Services.Abstract
{
    public interface IAttractable : IViewBase
    {
        void Gravitate(Vector2 attractor, float attractionForce);
    }
}