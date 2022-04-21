﻿namespace carnapps.GameViewSystem.Abstract
{
    using UnityEngine;
    using System;

    public interface IView<in T> : IViewBase where T: IViewModel
    {
        RectTransform RectTransform { get; }

        void Initialize(T viewModel);
    }
}