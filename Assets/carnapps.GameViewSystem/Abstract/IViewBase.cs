namespace carnapps.GameViewSystem.Abstract
{
    using UnityEngine;
    using System;

    public interface IViewBase : IDisposable
    {
        RectTransform RectTransform { get; }
    }
}