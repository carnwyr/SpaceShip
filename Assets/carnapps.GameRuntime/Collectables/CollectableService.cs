namespace carnapps.GameRuntime.Collectables
{
    using carnapps.Services.Abstract;
    using System.Collections.Generic;
    using UniRx;
    using carnapps.GameRuntime.Collectables.Abstract;
    using carnapps.GameViewSystem.Abstract;

    public class CollectableService : IService
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();
        private readonly IDictionary<CollectableConfig, int> _collectableCounts = new Dictionary<CollectableConfig, int>();

        public CollectableService(IList<CollectableConfig> collectableConfigs)
        {
            foreach (var config in collectableConfigs)
            {
                _collectableCounts.Add(config, 0);
                var collectableController = Observable.EveryUpdate()
                    .Subscribe(_ => {
                        if (_collectableCounts[config] < config.MaxCurrentCount) 
                        {
                            Spawn(config.CollectableObject);
                        }
                    })
                    .AddTo(_disposables);
            }
        }

        private void Spawn(CollectableView<IViewModel> collectable)
        {
            //var viewModel = new viewModel;
            //viewSystem.show(view)
            //view.ondispose => count--
        }

        public void Dispose() 
        {
            _disposables.Dispose();
        }
    }
}