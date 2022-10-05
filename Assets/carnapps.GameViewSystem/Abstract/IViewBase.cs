using carnapps.Context.Abstract;
using UnityEngine;

namespace carnapps.GameViewSystem.Abstract
{
    public interface IViewBase : ILifetime
    {
        RectTransform RectTransform { get; }
    }
}