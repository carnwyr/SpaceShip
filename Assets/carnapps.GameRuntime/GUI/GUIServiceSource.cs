namespace carnapps.GameRuntime.GUI
{
    using carnapps.Context.Abstract;
    using carnapps.GameViewSystem;
    using carnapps.Services;
    using carnapps.GameRuntime.Player;
    using UnityEngine;
    using carnapps.Services.Abstract;

    [CreateAssetMenu(menuName = "carnapps/"+nameof(GUIServiceSource), fileName = nameof(GUIServiceSource))]
    public class GUIServiceSource : ServiceSource
    {
        [SerializeField] private GUIView _gui;
        
        public override IService CreateService(IContext context)
        {
            var viewSystem = context.Get<ViewSystem>();
            var playerService = context.Get<PlayerService>();
            
            return new GUIService(viewSystem, _gui, playerService);
        }
    }
}