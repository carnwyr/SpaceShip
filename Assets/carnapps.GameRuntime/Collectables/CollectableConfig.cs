namespace carnapps.GameRuntime.Collectables
{
    using System;
    using UnityEngine;
    using carnapps.GameRuntime.Collectables.Abstract;
    using carnapps.GameViewSystem.Abstract;

    [Serializable]
    public class CollectableConfig {
        [SerializeField] private CollectableView<IViewModel> _collectableObject;
        [SerializeField] private int _maxCurrentCount;

        public CollectableView<IViewModel> CollectableObject => _collectableObject;
        public int MaxCurrentCount => _maxCurrentCount;
    }
}