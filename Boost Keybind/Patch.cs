using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace Boost_Keybind
{
    [HarmonyPatch(typeof(PLShipControl), "FixedUpdate")]
    class FixedUpdatePatch
    {
        static bool state = false;
        static void Postfix(PLShipControl __instance)
        {
            if ((bool)typeof(PLShipControl).GetField("UpdateOthers", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(__instance) && PLTabMenu.Instance != null && !__instance.ShipInfo.InWarp && __instance.ControlEnabled && !PLNetworkManager.Instance.IsTyping && PLNetworkManager.Instance.MainMenu.GetActiveMenuCount() == 0 && PLTabMenu.Instance != null && !PLTabMenu.Instance.TabMenuActive)
            {
                if (Global.togglemode && PLInput.Instance.GetButtonDown(PLInputBase.EInputActionName.pilot_boost))
                {
                    Global.CurrentToggle = !Global.CurrentToggle;
                }
                if (PLInput.Instance.GetButton(PLInputBase.EInputActionName.pilot_boost) && !Global.togglemode && (Mathf.Abs(__instance.Throttle) > 0.5f || Mathf.Abs(__instance.ManeuverThrottle) > 0.5f) && __instance.Boost > 0f && !(state == false && __instance.Boost <= 0.2f))
                {
                    __instance.IsBoosting = true;
                    state = true;
                }
                else if (Global.CurrentToggle)
                {
                    if (!(__instance.Throttle > 0.001f || __instance.ManeuverThrottle > 0.001f) || __instance.Boost <= 0f)
                    {
                        Global.CurrentToggle = false;
                        __instance.IsBoosting = false;
                    }
                    else
                    {
                        __instance.IsBoosting = true;
                    }
                }
                else
                {
                    __instance.IsBoosting = false;
                    state = false;
                }
            }
        }
    }
}
