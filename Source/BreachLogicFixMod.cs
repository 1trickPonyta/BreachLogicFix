using Verse;
using HarmonyLib;

namespace BreachLogicFix
{
    public class BreachLogicFixMod : Mod
    {
        public const string PACKAGE_ID = "breachlogicfix.1trickPonyta";
        public const string PACKAGE_NAME = "Breach Logic Fix";

        public BreachLogicFixMod(ModContentPack content) : base(content)
        {
            var harmony = new Harmony(PACKAGE_ID);
            harmony.PatchAll();

            Log.Message($"[{PACKAGE_NAME}] Loaded.");
        }
    }
}
