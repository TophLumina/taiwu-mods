using System;
using GameData.Domains;

namespace TaiwuOptimization.Runtime;

internal static class DelayMonthSettings
{
    public static bool Enabled = true;
    public static bool ImmediateNeighborAreas = true;
    public static int FrameBudgetMs = 4;
    public static bool DelayEquipment = true;
    public static bool DelayMissionGoal = true;
    public static bool DelayLoseOverloadItems = false;
    public static bool DelayBrokenBlocks = true;

    public static void Load(string modId)
    {
        TryGet(modId, "Enabled", ref Enabled);
        TryGet(modId, "ImmediateNeighborAreas", ref ImmediateNeighborAreas);
        TryGet(modId, "FrameBudgetMs", ref FrameBudgetMs);
        TryGet(modId, "DelayEquipment", ref DelayEquipment);
        TryGet(modId, "DelayMissionGoal", ref DelayMissionGoal);
        TryGet(modId, "DelayLoseOverloadItems", ref DelayLoseOverloadItems);
        TryGet(modId, "DelayBrokenBlocks", ref DelayBrokenBlocks);

        FrameBudgetMs = Math.Clamp(FrameBudgetMs, 1, 20);
    }

    private static void TryGet(string modId, string key, ref bool value)
    {
        try
        {
            DomainManager.Mod.GetSetting(modId, key, ref value);
        }
        catch
        {
            // Keep defaults when the settings file is absent or the backend is not ready yet.
        }
    }

    private static void TryGet(string modId, string key, ref int value)
    {
        try
        {
            DomainManager.Mod.GetSetting(modId, key, ref value);
        }
        catch
        {
            // Keep defaults when the settings file is absent or the backend is not ready yet.
        }
    }
}
