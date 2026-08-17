using HarmonyLib;


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
            if (switcher is JunctionSwitcher && !indirectlyPointing) return false;
            return true;
        }
    }
}
