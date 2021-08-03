namespace BreachLogicFix
{
    public static class Debug
    {
        public static void Log(string message)
        {
#if DEBUG
            Verse.Log.Message($"[{BreachLogicFixMod.PACKAGE_NAME}] {message}");
#endif
        }
    }
}
