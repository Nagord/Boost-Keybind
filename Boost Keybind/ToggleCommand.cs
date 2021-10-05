using PulsarModLoader.Chat.Commands.CommandRouter;

namespace Boost_Keybind
{
    class ToggleCommand : ChatCommand
    {
        public override string[] CommandAliases()
        {
            return new string[] { "boosttogglemode", "btm" };
        }

        public override string Description()
        {
            return "Enables/Disables toggle mode for boosting";
        }

        public override void Execute(string arguments)
        {
            Global.togglemode = !Global.togglemode;
            Global.CurrentToggle = false;
            PLXMLOptionsIO.Instance.CurrentOptions.SetStringValue("BoostToggleMode", Global.togglemode.ToString());
            string s = Global.togglemode ? "Enabled" : "Disabled";
            PulsarModLoader.Utilities.Messaging.Notification($"Togglemode {s}");
        }

        public string UsageExample()
        {
            return $"/{CommandAliases()[0]}";
        }
    }
}
