namespace carnapps.GameRuntime.GUI
{
    using carnapps.GameViewSystem;
    using carnapps.Services.Abstract;
    using carnapps.GameRuntime.Player;

    public class GUIService : IService
    {
        public GUIService(ViewSystem viewSystem, GUIView gui, PlayerService playerService)
        {
            var guiViewModel = new GUIViewModel(playerService.Fuel);
            var guiView = viewSystem.Create(gui, guiViewModel);
        }

        public void Dispose() {}
    }
}