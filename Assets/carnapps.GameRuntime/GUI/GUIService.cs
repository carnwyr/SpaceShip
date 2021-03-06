namespace carnapps.GameRuntime.GUI
{
    using carnapps.GameViewSystem;
    using carnapps.Services.Abstract;
    using carnapps.GameRuntime.Player;

    public class GUIService : Service
    {
        public GUIService(ViewSystem viewSystem, GUIView gui, PlayerService playerService)
        {
            var guiViewModel = new GUIViewModel(playerService.Fuel);
            var guiView = viewSystem.Create(gui, guiViewModel);
        }
    }
}