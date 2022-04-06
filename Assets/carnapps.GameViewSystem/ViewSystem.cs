namespace carnapps.GameViewSystem
{
    using carnapps.GameViewSystem.Abstract;
    using carnapps.Services.Abstract;
    using UnityEngine;
    
    public class ViewSystem : IService
    {
        private readonly Canvas _canvas;
        
        public ViewSystem(Canvas canvas)
        {
            _canvas = Object.Instantiate(canvas);
        }

        public T Create<T, V>(T obj, V viewModel) 
            where T : View<V> 
            where V : IViewModel
        {
            var view = Object.Instantiate(obj, _canvas.transform, false);
            view.Initialize(viewModel);
            return view;
        }

        public void Dispose()
        {
            
        }
    }
}