using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace Boost_Keybind
{
    [HarmonyPatch(typeof(PLShipControl), "FixedUpdate")]
    class FixedUpdatePatch
    {
        static void Postfix(PLShipControl __instance)
        {
            if((bool)typeof(PLShipControl).GetField("UpdateOthers", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(__instance) && PLTabMenu.Instance != null && !__instance.ShipInfo.InWarp && __instance.ControlEnabled && !PLNetworkManager.Instance.IsTyping && PLNetworkManager.Instance.MainMenu.GetActiveMenuCount() == 0 && PLTabMenu.Instance != null && !PLTabMenu.Instance.TabMenuActive)
            {
                if (Global.togglemode && Input.GetKeyDown(KeyCode.LeftShift))
                {
                    Global.CurrentToggle = !Global.CurrentToggle;
                }
                if(Input.GetKey(KeyCode.LeftShift) && !Global.togglemode && (Mathf.Abs(__instance.Throttle) > 0.5f || Mathf.Abs(__instance.ManeuverThrottle) > 0.5f))
                {
                    __instance.IsBoosting = true;
                }
                else if(Global.CurrentToggle)
                {
                    __instance.IsBoosting = true;
                }
                else
                {
                    __instance.IsBoosting = false;
                }
            }
        }
    }
}
