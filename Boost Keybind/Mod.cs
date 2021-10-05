using PulsarModLoader;

namespace Boost_Keybind
{
    public class Mod : PulsarMod
    {
        public Mod()
        {
            if (bool.TryParse(PLXMLOptionsIO.Instance.CurrentOptions.GetStringValue("BoostToggleMode"), out bool result))
            {
                Global.togglemode = result;
            }
        }

        public override string Version => "0.2.1";

        public override string Author => "Dragon";

        public override string LongDescription => "Gives Boost a keybind";

        public override string Name => "Boost Keybind";

        public override string HarmonyIdentifier()
        {
            return "Dragon.Boost Keybind";
        }
    }
}
