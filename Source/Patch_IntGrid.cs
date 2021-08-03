using Verse;
using HarmonyLib;

namespace BreachLogicFix
{
    [HarmonyPatch(typeof(IntGrid))]
    [HarmonyPatch("set_Item")]
    [HarmonyPatch(new[] { typeof(IntVec3), typeof(int) })]
    public static class Patch_IntGrid_set_Item
    {
        static AccessTools.FieldRef<IntGrid, int> mapSizeXRef =
            AccessTools.FieldRefAccess<IntGrid, int>("mapSizeX");
        static AccessTools.FieldRef<IntGrid, int> mapSizeZRef =
            AccessTools.FieldRefAccess<IntGrid, int>("mapSizeZ");

        public static bool Prefix(IntGrid __instance, ref IntVec3 c)
        {
            // Don't do anything if the cell (c) in question is off the map
            return c.x > -1 && c.x < mapSizeXRef(__instance) && c.z > -1 && c.z < mapSizeZRef(__instance);
        }
    }
}
