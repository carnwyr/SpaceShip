namespace carnapps.GameViewSystem
{
    using carnapps.Context.Abstract;
    using carnapps.Services;
    using carnapps.Services.Abstract;
    using UnityEngine;
    
    [CreateAssetMenu(menuName = "carnapps/"+nameof(ViewSystemSource), fileName = nameof(ViewSystemSource))]
    public class ViewSystemSource : ServiceSource
    {
        [SerializeField] private Canvas _canvas;
        
        public override IService CreateService(IContext context)
        {
            var viewSystem = new ViewSystem(_canvas);
            context.Publish(viewSystem);
            return viewSystem;
        }
    }
}