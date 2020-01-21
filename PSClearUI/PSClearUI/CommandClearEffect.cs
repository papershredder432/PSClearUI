using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;

namespace papershredder432.PSClearUI
{
    class CommandClearEffect : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "cleareffect";

        public string Help => "Clears an Effect.";

        public string Syntax => "/cleareffect <EffectID>";

        public List<string> Aliases => new List<string>() { "ce", "cleare" };

        public List<string> Permissions => new List<string>() { "ps.cleareffect" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (!PSClearUI.Instance.Configuration.Instance.PSClearUIEnabled) return;

            if (command.Length < 1)
            {
                UnturnedChat.Say(caller, "Correct usage: /cleareffect <EffectID>");
                return;
            }

            var SID = caller as UnturnedPlayer;

            try
            {
                EffectManager.askEffectClearByID(Convert.ToUInt16(command[0]), SID.CSteamID);
                UnturnedChat.Say(caller, $"Cleared effect {command[0]}");
            } catch (InvalidProgramException e)
            {
                UnturnedChat.Say(caller, "Invalid input.");
                return;
            }
            
        }
    }
}
