using HarmonyLib;
using System;

namespace DVMP_CommsRadioMapOnlySwitching
{
    [HarmonyPatch(typeof(JunctionSwitcherManager), "UpdateJunctionControl")]
    static class JunctionSwitcherManager_UpdateJunctionControl_Patch
    {
        static bool Prefix(
            JunctionSwitcher switcher,
            JunctionSwitchRemoteControllable junctionControl,
            bool indirectlyPointing
        )
        {
            try {
                if (switcher is JunctionSwitcher && !indirectlyPointing) return false;
                return true;
            }
            catch (Exception e)
            {
                Main.mod?.Logger.Log($"Exception in JunctionSwitcher patch: {e}");
                return true;
            }
            
        }
    }
}
