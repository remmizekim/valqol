using HarmonyLib;
using System;

namespace ValQOL
{
    [HarmonyPatch(typeof(DLCMan), "IsDLCInstalled", new Type[] { typeof(uint) })]
    public static class UnlockDLC
    {
        private static bool Prefix(ref bool __result)
        {
            // Mark all DLC as enabled
            __result = true;
            return false;
        }
    }
}
