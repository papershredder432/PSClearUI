using Rocket.API;
using SDG.Unturned;
using System.Collections.Generic;

namespace papershredder432.PSClearUI
{
    class CommandClearAll : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "clearall";

        public string Help => "Clears all Effects.";

        public string Syntax => "/clearall";

        public List<string> Aliases => new List<string>() { "ca", "cleara" };

        public List<string> Permissions => new List<string>() { "ps.clearall" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (!PSClearUI.Instance.Configuration.Instance.PSClearUIEnabled) return;

            EffectManager.askEffectClearAll();
            
        }
    }
}
