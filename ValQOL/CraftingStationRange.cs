using HarmonyLib;

namespace ValQOL
{
    [HarmonyPatch(typeof(CraftingStation), "Start")]
    public static class CraftingStationRange
    {
        private static void Postfix(ref CraftingStation __instance)
        {
            // Double use range for crafting stations
            __instance.m_useDistance = __instance.m_useDistance * 2;
        }
    }
}