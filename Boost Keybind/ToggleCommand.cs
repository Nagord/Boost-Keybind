using PulsarPluginLoader.Chat.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boost_Keybind
{
    class ToggleCommand : IChatCommand
    {
        public string[] CommandAliases()
        {
            return new string[] { "boosttogglemode", "btm" };
        }

        public string Description()
        {
            return "Enables/Disables toggle mode for boosting";
        }

        public bool Execute(string arguments, int SenderID)
        {
            Global.togglemode = !Global.togglemode;
            Global.CurrentToggle = false;
            string s = Global.togglemode ? "Enabled" : "Disabled";
            PulsarPluginLoader.Utilities.Messaging.Notification($"Togglemode {s}");
            return false;
        }

        public bool PublicCommand()
        {
            return false;
        }

        public string UsageExample()
        {
            return $"/{CommandAliases()[0]}";
        }
    }
}
