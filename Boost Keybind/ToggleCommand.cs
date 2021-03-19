using PulsarPluginLoader.Chat.Commands;

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
            PLXMLOptionsIO.Instance.CurrentOptions.SetStringValue("BoostToggleMode", Global.togglemode.ToString());
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
    [HarmonyLib.HarmonyPatch(typeof(PLServer), "Start")]
    class LoadSetting
    {
        static void Postfix ()
        {
            if(bool.TryParse(PLXMLOptionsIO.Instance.CurrentOptions.GetStringValue("BoostToggleMode"), out bool result))
            {
                Global.togglemode = result;
            }
        }
    }
}
