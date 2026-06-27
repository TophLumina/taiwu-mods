using System.Collections.Generic;
using System.Reflection;
using GameData.Common;
using GameData.Domains.Adventure;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using HarmonyLib;
using TaiwuOptimization.Runtime;
using Character = GameData.Domains.Character.Character;

namespace TaiwuOptimization.Patches;

[HarmonyPatch]
internal static class CharacterActionTargetMatcherSetFavorabilityPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterDomain),
            "SetFavorability",
            new[] { typeof(DataContext), typeof(int), typeof(int), typeof(short) });

    // FavorRange 和太吾关系类 matcher 依赖关系/好感版本。
    private static void Postfix(int charId, int relatedCharId)
    {
        CharacterActionTargetMatcherStageCache.InvalidateRelationTarget(charId);
        CharacterActionTargetMatcherStageCache.InvalidateRelationTarget(relatedCharId);
    }
}

[HarmonyPatch]
internal static class CharacterActionTargetMatcherSetOrganizationInfoPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(Character),
            nameof(Character.SetOrganizationInfo),
            new[] { typeof(OrganizationInfo), typeof(DataContext) });

    // IdentityType、Organization 和 CanStroll 依赖组织版本。
    private static void Postfix(Character __instance) =>
        CharacterActionTargetMatcherStageCache.InvalidateOrganizationTarget(__instance.GetId());
}

[HarmonyPatch]
internal static class CharacterActionTargetMatcherSetLocationPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(Character),
            nameof(Character.SetLocation),
            new[] { typeof(Location), typeof(DataContext) });

    // 第一版 matcher 白名单暂不缓存位置类 matcher，但保留版本入口供后续扩展。
    private static void Postfix(Character __instance) =>
        CharacterActionTargetMatcherStageCache.InvalidateLocationTarget(__instance.GetId());
}

[HarmonyPatch]
internal static class CharacterActionTargetMatcherSetExternalRelationStatePatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(Character),
            nameof(Character.SetExternalRelationState),
            new[] { typeof(ulong), typeof(DataContext) });

    private static void Postfix(Character __instance) =>
        CharacterActionTargetMatcherStageCache.InvalidateExternalRelationTarget(__instance.GetId());
}

[HarmonyPatch]
internal static class CharacterActionTargetMatcherSetKidnapperIdPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(Character),
            nameof(Character.SetKidnapperId),
            new[] { typeof(int), typeof(DataContext) });

    private static void Postfix(Character __instance) =>
        CharacterActionTargetMatcherStageCache.InvalidateKidnapperTarget(__instance.GetId());
}

[HarmonyPatch]
internal static class CharacterActionTargetMatcherSetLeaderIdPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(Character),
            nameof(Character.SetLeaderId),
            new[] { typeof(int), typeof(DataContext) });

    private static void Postfix(Character __instance) =>
        CharacterActionTargetMatcherStageCache.InvalidateLeaderTarget(__instance.GetId());
}

[HarmonyPatch]
internal static class CharacterActionTargetMatcherCrossAreaTravelPatch
{
    private static IEnumerable<MethodBase> TargetMethods()
    {
        yield return AccessTools.Method(
            typeof(CharacterDomain),
            nameof(CharacterDomain.SetCrossAreaTravelInfo),
            new[] { typeof(DataContext), typeof(int), typeof(CrossAreaMoveInfo) });
        yield return AccessTools.Method(
            typeof(CharacterDomain),
            nameof(CharacterDomain.RemoveCrossAreaTravelInfo),
            new[] { typeof(DataContext), typeof(int) });
    }

    private static void Postfix() =>
        CharacterActionTargetMatcherStageCache.InvalidateCrossAreaTravel();
}

[HarmonyPatch]
internal static class CharacterActionTargetMatcherSetAdventureTaiwuPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(AdventureDomain),
            nameof(AdventureDomain.SetAdventureTaiwu),
            new[] { typeof(AdventureTaiwu), typeof(DataContext) });

    private static void Postfix() =>
        CharacterActionTargetMatcherStageCache.InvalidateAdventureTaiwu();
}

[HarmonyPatch]
internal static class CharacterActionTargetMatcherSetInventoryPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(Character),
            nameof(Character.SetInventory),
            new[] { typeof(Inventory), typeof(DataContext) });

    // 背包整体替换时推进背包版本。
    private static void Postfix(Character __instance) =>
        CharacterActionTargetMatcherStageCache.InvalidateInventoryTarget(__instance.GetId());
}

[HarmonyPatch]
internal static class CharacterActionTargetMatcherSetEquipmentPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(Character),
            nameof(Character.SetEquipment),
            new[] { typeof(ItemKey[]), typeof(DataContext) });

    // 装备整体替换时推进装备版本。
    private static void Postfix(Character __instance) =>
        CharacterActionTargetMatcherStageCache.InvalidateEquipmentTarget(__instance.GetId());
}

[HarmonyPatch]
internal static class CharacterActionTargetMatcherSetCurrAgePatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(Character),
            nameof(Character.SetCurrAge),
            new[] { typeof(short), typeof(DataContext) });

    // AgeType 依赖年龄段版本。
    private static void Postfix(Character __instance) =>
        CharacterActionTargetMatcherStageCache.InvalidateAgeTarget(__instance.GetId());
}
