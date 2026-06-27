using System.Reflection;
using GameData.Common;
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
