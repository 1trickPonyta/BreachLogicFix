using RimWorld;
using HarmonyLib;

namespace BreachLogicFix
{
    [HarmonyPatch(typeof(LordToil_AssaultColonyBreaching))]
    [HarmonyPatch("UpdateCurrentBreachTarget")]
    public static class Patch_LordToil_AssaultColonyBreaching_UpdateCurrentBreachTarget
    {
        public static void Postfix(LordToil_AssaultColonyBreaching __instance)
        {
            // If we have a mechanoid solo attacker, don't do that
            // I'm not even sure what the solo attacker designation is for, but it 
            // doesn't seem to be meant for mechs as it ends their breach.
            // Specifically, Centipedes with Inferno Cannons can be made the solo 
            // attacker because of their AoE attack (maybe that wasn't intentional?)
            if (__instance.Data.soloAttacker != null && __instance.Data.soloAttacker.RaceProps.IsMechanoid)
            {
                __instance.Data.soloAttacker = null;
            }
        }
    }
}
