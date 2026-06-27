using System.Collections.Generic;
using System.Reflection;
using Config;
using GameData.ActionPlanning.MonthlyAI.Node;
using GameData.Domains.Character;
using HarmonyLib;
using TaiwuOptimization.Runtime;
using Character = GameData.Domains.Character.Character;

namespace TaiwuOptimization.Patches;

[HarmonyPatch(typeof(PlanningActionNode), nameof(PlanningActionNode.MatchTargetCharacter))]
internal static class CharacterMatcherStageCachePatch
{
    // 只替换 action 目标匹配中的 `CharacterMatcherItem.Match(targetChar)`，保留后续原版条件和 action impl。
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        MethodInfo original = AccessTools.Method(
            typeof(CharacterMatcherHelper),
            nameof(CharacterMatcherHelper.Match),
            new[] { typeof(CharacterMatcherItem), typeof(Character) });
        MethodInfo replacement = AccessTools.Method(
            typeof(CharacterMatcherStageCache),
            nameof(CharacterMatcherStageCache.Match),
            new[] { typeof(CharacterMatcherItem), typeof(Character) });

        foreach (CodeInstruction instruction in instructions)
        {
            if (instruction.Calls(original))
            {
                instruction.operand = replacement;
            }

            yield return instruction;
        }
    }
}
