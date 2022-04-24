namespace carnapps.GameViewSystem.Abstract
{
    using UnityEngine;
    using carnapps.Context.Abstract;

    public interface IViewBase : ILifetime
    {
        RectTransform RectTransform { get; }
    }
}