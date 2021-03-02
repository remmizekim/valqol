using HarmonyLib;

namespace ValQOL
{
    [HarmonyPatch(typeof(Chat), "OnNewChatMessage")]
    public static class ShowChatOnMessage
    {
        private static void Postfix(ref Chat __instance, ref float ___m_hideTimer)
        {
            ___m_hideTimer = 0.0f;
            __instance.m_chatWindow.gameObject.SetActive(true);
        }
    }
}
