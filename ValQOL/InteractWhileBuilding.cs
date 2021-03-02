using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine;

namespace ValQOL
{
    [HarmonyPatch(typeof(Player), "UpdateHover")]
    public static class InteractWhileBuilding
    {
        private static MethodInfo InPlaceMode = AccessTools.Method(typeof(Character), "InPlaceMode");

        [HarmonyTranspiler]
        private static IEnumerable<CodeInstruction> Patch(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> il = instructions.ToList();
            for (int i = 0; i < il.Count; ++i)
            {
                if (il[i].Calls(InPlaceMode))
                {
                    il[i - 1].opcode = OpCodes.Nop;
                    il[i] = new CodeInstruction(OpCodes.Ldc_I4_0);
                }
            }

            return il.AsEnumerable();
        }
    }

    [HarmonyPatch(typeof(Hud), "Awake")]
    public static class MoveBuildingPieceHealthBar
    {
        private static void Postfix(Hud __instance)
        {
            Vector3 position = __instance.m_pieceHealthRoot.localPosition;
            __instance.m_pieceHealthRoot.localPosition = new Vector3(position.x, position.y + 20f, position.z);
        }
    }
}