using Rocket.Core.Logging;
using Rocket.Core.Plugins;

namespace papershredder432.PSClearUI
{
    public class PSClearUI : RocketPlugin<PSClearUIConfiguration>
    {
        public static PSClearUI Instance;

        protected override void Load()
        {
            Instance = this;
            Logger.LogWarning("[PSClearUI] Loaded, made by papershredder432, join the support Discord here: https://discord.gg/ydjYVJ2");
        }

        protected override void Unload()
        {
            Instance = null;
            Logger.LogWarning("[PSClearUI] Unloaded.");
        }
    }
}
