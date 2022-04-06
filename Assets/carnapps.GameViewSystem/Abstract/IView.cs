namespace carnapps.GameViewSystem.Abstract
{
    using UnityEngine;
    using System;

    public interface IView : IDisposable
    {
        RectTransform RectTransform { get; }
    }
}