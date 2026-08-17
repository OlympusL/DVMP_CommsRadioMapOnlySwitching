using HarmonyLib;
using UnityModManagerNet;
using System;

namespace DVMP_CommsRadioMapOnlySwitching
{
    public static class Main
    {
        public static UnityModManager.ModEntry? mod;

        public static bool Load(UnityModManager.ModEntry modEntry)
        {
            mod = modEntry;
            mod.OnToggle = OnToggle;

            return true;
        }

        private static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            try
            {
                Harmony harmony = new Harmony(modEntry.Info.Id);

                if (value)
                {
                    harmony.PatchAll();
                }
                else
                {
                    harmony.UnpatchAll(modEntry.Info.Id);
                }
                return true;
            } catch (Exception e)
            {
                modEntry.Logger.Error($"Failed to {(value ? "enable" : "disable")} mod: {e}");
                return false;
            }
            
        }
    }
}
