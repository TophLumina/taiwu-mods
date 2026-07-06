using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains.Character;
using HarmonyLib;
using TaiwuRemoveAILimitation.Runtime;

namespace TaiwuRemoveAILimitation.Patches;

[HarmonyPatch(typeof(Character), "OfflineCreateNextAction")]
internal static class CharacterOfflineCreateNextActionLogPatch
{
    private static void Prefix(CharacterGoalData currentGoal, ref NpcActionCreationLogState __state)
    {
        if (!NpcActionLimitationRemovalLog.Enabled)
        {
            __state = default;
            return;
        }

        int actionTemplateId = -1;
        if (currentGoal?.Plan != null && currentGoal.Plan.Count > 0)
        {
            actionTemplateId = currentGoal.Plan[currentGoal.Plan.Count - 1];
        }

        __state = new NpcActionCreationLogState(
            actionTemplateId,
            currentGoal?.GoalTemplateId ?? -1,
            currentGoal == null ? (sbyte)-1 : (sbyte)currentGoal.State);
    }

    private static void Postfix(Character __instance, CharacterActionData? __result, NpcActionCreationLogState __state)
    {
        NpcActionLimitationRemovalLog.LogActionCreation(__instance, __state, __result);
    }
}

[HarmonyPatch(typeof(Character), "ExecuteAction")]
internal static class CharacterExecuteActionLogPatch
{
    private static void Prefix(CharacterActionData currentAction, ref NpcActionExecutionLogState __state)
    {
        if (!NpcActionLimitationRemovalLog.Enabled || currentAction == null)
        {
            __state = default;
            return;
        }

        __state = new NpcActionExecutionLogState(
            currentAction.ActionTemplateId,
            (int)currentAction.State);
    }

    private static void Postfix(Character __instance, CharacterActionData currentAction, CharacterActionData? __result, NpcActionExecutionLogState __state)
    {
        if (currentAction != null)
        {
            NpcActionLimitationRemovalLog.LogActionExecution(__instance, __state, currentAction, __result);
        }
    }
}
