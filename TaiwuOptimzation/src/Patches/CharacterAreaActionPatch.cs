using System.Reflection;
using GameData.Common;
using GameData.Domains.Character.Ai.ParallelAdvanceMonth;
using HarmonyLib;
using TaiwuOptimization.Runtime;

namespace TaiwuOptimization.Patches;

[HarmonyPatch]
internal static class CharacterAreaActionPatch
{
    private static MethodBase TargetMethod()
    {
        return AccessTools.Method(
            typeof(ParallelActionManager),
            "OfflineExecuteCharacterActionsInArea",
            new[] { typeof(DataContext), typeof(int), typeof(ICharacterParallelAction) });
    }

    private static bool Prefix(int areaId, ICharacterParallelAction action)
    {
        return !DelayMonthRuntime.TryDelayCharacterAreaAction(areaId, action);
    }
}
