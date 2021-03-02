using BepInEx;
using HarmonyLib;

namespace ValQOL
{
    [BepInPlugin("org.remmiz.plugins.valqol", "ValQOL", "0.0.3.0")]
    public class ValQOL : BaseUnityPlugin
    {
        void Awake()
        {
            Configuration.Current = new Configuration();
            Configuration.Current.DeleteHotkey = Config.Bind<string>("General", "DiscardHotkey", "delete", "The hotkey to discard an item");

            string gitRepo = "https://github.com/remmizekim/valqol";
            string gitApiRepo = "https://api.github.com/repos/remmizekim/valqol/tags";

            var harmony = new Harmony("mod.valhardmode");
            harmony.PatchAll();
        }
    }
}