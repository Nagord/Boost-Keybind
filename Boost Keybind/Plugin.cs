using PulsarPluginLoader;

namespace Boost_Keybind
{
    public class Plugin : PulsarPlugin
    {
        public override string Version => "0.1.0";

        public override string Author => "Dragon";

        public override string LongDescription => "Gives Boost a keybind";

        public override string Name => "Boost Keybind";

        public override string HarmonyIdentifier()
        {
            return "Dragon.Boost Keybind";
        }
    }
}
