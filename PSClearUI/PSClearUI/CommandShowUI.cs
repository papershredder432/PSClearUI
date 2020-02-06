using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace papershredder432.PSClearUI
{
    class CommandShowUI : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Both;

        public string Name => "showui";

        public string Help => "Shows a UI effect";

        public string Syntax => "/showui <UIEffectID> [Player]";

        public List<string> Aliases => new List<string>() { "sui" };

        public List<string> Permissions => new List<string>() { "ps.showui" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (command.Length < 1)
            {
                UnturnedChat.Say(caller, "Invalid usage. /showui <UIEffectID> [player]");
                return;
            }

            string effectID = command[0];
            bool isNumeric = int.TryParse(effectID, out int n);

            if (isNumeric == false)
            {
                return;
            } else if (isNumeric == true)
            {
                string targetA = command[1];
                var target = UnturnedPlayer.FromName(targetA);

                if (target != null)
                {
                    EffectManager.sendUIEffect(Convert.ToUInt16(effectID), Convert.ToInt16(effectID), true);

                    var SID = caller as UnturnedPlayer;

                    EffectManager.sendUIEffectVisibility(Convert.ToInt16(effectID), SID.CSteamID, true, "", true);

                    UnturnedChat.Say(caller, $"Sent UI effect to {target.CharacterName}.");
                } else
                {
                    var SID = caller as UnturnedPlayer;

                    //EffectManager.sendUIEffect(Convert.ToUInt16(effectID), Convert.ToInt16(effectID), true);
                    EffectManager.sendUIEffectVisibility(Convert.ToInt16(effectID), SID.CSteamID, true, "", true);
                }
            }
        }
    }
}
