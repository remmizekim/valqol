using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace ValQOL
{
    [HarmonyPatch(typeof(InventoryGui), "UpdateItemDrag")]
    public static class DeleteItems
    {
        static void Postfix(InventoryGui __instance, ItemDrop.ItemData ___m_dragItem, Inventory ___m_dragInventory, int ___m_dragAmount, ref GameObject ___m_dragGo)
        {
            if (Input.GetKeyDown(Configuration.Current.DeleteHotkey.Value) && ___m_dragItem != null && ___m_dragInventory.ContainsItem(___m_dragItem))
            {
                ZLog.LogWarning($"Deleting {___m_dragAmount}/{___m_dragItem.m_stack} {___m_dragItem.m_shared.m_name}");

                // Cancel equip queue and unequip
                Player.m_localPlayer.RemoveFromEquipQueue(___m_dragItem);
                Player.m_localPlayer.UnequipItem(___m_dragItem, false);

                if (___m_dragAmount == ___m_dragItem.m_stack)
                {
                    // Remove full stack
                    ___m_dragInventory.RemoveItem(___m_dragItem);

                }
                else
                {
                    // Remove less than full stack
                    ___m_dragInventory.RemoveItem(___m_dragItem, ___m_dragAmount);
                }

                // Destroy game object
                UnityEngine.Object.Destroy(___m_dragGo);
                ___m_dragGo = null;

                // Refresh crafting panel
                __instance.GetType().GetMethod("UpdateCraftingPanel", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(__instance, new object[] { false });
            }
        }
    }
}
