using carnapps.GameRuntime.Player;
using carnapps.GameViewSystem;
using carnapps.Services.Abstract;

namespace carnapps.GameRuntime.GUI
{
    public class GUIService : Service
    {
        public GUIService(ViewSystem viewSystem, GUIView gui, PlayerService playerService)
        {
            var guiViewModel = new GUIViewModel(playerService.Fuel);
            var guiView = viewSystem.Create(gui, guiViewModel);
        }
    }
}