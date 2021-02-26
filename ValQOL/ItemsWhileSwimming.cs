using HarmonyLib;

namespace ValQOL
{
    [HarmonyPatch(typeof(Character), "IsSwiming")]
    public static class ItemsWhileSwimming
    {
        static bool Prefix(Humanoid __instance, ref bool __result)
        {
            string callingMethod = (new System.Diagnostics.StackTrace()).GetFrame(2).GetMethod().Name;
            if ((callingMethod == "EquipItem" || callingMethod == "UpdateEquipment") && __instance.IsPlayer())
            {
                __result = false;
                return false; // Don't call underlying method
            }

            return true;
        }
    }
}