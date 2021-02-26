using BepInEx.Configuration;

namespace ValQOL
{
    public class Configuration
    {
        public static Configuration Current { get; set; }

        public ConfigEntry<string> DeleteHotkey { get; set; }
    }
}
