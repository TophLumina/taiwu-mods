using GameData.ActionPlanning.Interface;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Domains.Character;
using HarmonyLib;
using TaiwuRemoveAILimitation.Runtime;

namespace TaiwuRemoveAILimitation.Patches;

[HarmonyPatch(typeof(CharacterActionPlanner), nameof(CharacterActionPlanner.CheckNodeReachable))]
internal static class CharacterActionPlannerCheckNodeReachablePatch
{
    private static bool Prefix(
        CharacterActionPlanner __instance,
        INode<Character, StateKey> node,
        ref bool __result)
    {
        if (!TaiwuRemoveAILimitationSettings.EnableNpcActionLimitationRemoval)
        {
            return true;
        }

        __result = NpcActionLimitationRemoval.CheckNodeReachable(__instance, node);
        return false;
    }
}

[HarmonyPatch(typeof(CharacterActionPlanner), nameof(CharacterActionPlanner.Initialize))]
internal static class CharacterActionPlannerReachabilityDiagnosticsPatch
{
    private static void Postfix(CharacterActionPlanner __instance)
    {
        NpcActionReachabilityDiagnostics.LogPlannerOnce(__instance);
    }
}

[HarmonyPatch(typeof(CharacterPlanningAgent), nameof(CharacterPlanningAgent.CalcCurrentState))]
internal static class CharacterPlanningAgentCalcCurrentStatePatch
{
    private static bool Prefix(StateKey key, ref int __result)
    {
        if (!TaiwuRemoveAILimitationSettings.EnableNpcActionLimitationRemoval ||
            !NpcActionLimitationRemoval.TryGetLooseCurrentState(key, out int value))
        {
            return true;
        }

        __result = value;
        return false;
    }
}
