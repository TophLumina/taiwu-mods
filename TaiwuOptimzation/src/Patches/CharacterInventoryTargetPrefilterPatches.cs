using System.Reflection;
using System.Linq;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.Map;
using HarmonyLib;
using TaiwuOptimization.Runtime;
using Character = GameData.Domains.Character.Character;

namespace TaiwuOptimization.Patches;

[HarmonyPatch]
internal static class CharacterInventoryTargetPrefilterAddInventoryItemPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.GetDeclaredMethods(typeof(Character)).First(method =>
        {
            if (method.Name != nameof(Character.AddInventoryItem))
            {
                return false;
            }

            ParameterInfo[] parameters = method.GetParameters();
            return parameters.Length == 5 &&
                parameters[0].ParameterType == typeof(DataContext) &&
                parameters[1].ParameterType == typeof(ItemKey) &&
                parameters[2].ParameterType == typeof(int) &&
                parameters[3].ParameterType == typeof(bool);
        });

    // 只在成功加入后扩展“可能持有者”集合；删除不回收，保证预过滤不会漏掉原版候选。
    private static void Postfix(Character __instance, ItemKey itemKey, bool __result)
    {
        if (__result)
        {
            int charId = __instance.GetId();
            CharacterInventoryTargetPrefilter.AddPossibleHolder(charId, itemKey);
            CharacterActionTargetMatcherStageCache.InvalidateInventoryTarget(charId);
        }
    }
}

[HarmonyPatch]
internal static class CharacterInventoryTargetPrefilterOfflineCreateInventoryItemPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(Character),
            "OfflineCreateInventoryItem",
            new[] { typeof(DataContext), typeof(sbyte), typeof(short), typeof(int) });

    // 私有离线创建路径不一定经过 AddInventoryItem，因此单独捕获新增持有者。
    private static void Postfix(Character __instance, sbyte itemType, short templateId, int amount)
    {
        if (amount > 0)
        {
            int charId = __instance.GetId();
            CharacterInventoryTargetPrefilter.AddPossibleHolder(charId, itemType, templateId);
            CharacterActionTargetMatcherStageCache.InvalidateInventoryTarget(charId);
        }
    }
}

[HarmonyPatch]
internal static class CharacterInventoryTargetPrefilterChangeEquipmentPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(Character),
            nameof(Character.ChangeEquipment),
            new[] { typeof(DataContext), typeof(sbyte), typeof(sbyte), typeof(ItemKey) });

    // 换装可能把装备放回背包；作为预过滤只允许扩大可能持有者集合。
    private static void Postfix(Character __instance)
    {
        CharacterInventoryTargetPrefilter.AddCurrentInventory(__instance);
        int charId = __instance.GetId();
        CharacterActionTargetMatcherStageCache.InvalidateInventoryTarget(charId);
        CharacterActionTargetMatcherStageCache.InvalidateEquipmentTarget(charId);
    }
}

[HarmonyPatch]
internal static class CharacterInventoryTargetPrefilterSetInventoryPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(Character),
            nameof(Character.SetInventory),
            new[] { typeof(Inventory), typeof(DataContext) });

    // 直接替换背包时，将当前背包并入“可能持有者”集合；预过滤表只扩张，不删除旧候选。
    private static void Postfix(Character __instance)
    {
        int charId = __instance.GetId();
        CharacterInventoryTargetPrefilter.AddCurrentInventory(__instance);
        CharacterActionTargetMatcherStageCache.InvalidateInventoryTarget(charId);
    }
}

[HarmonyPatch]
internal static class CharacterInventoryTargetPrefilterChangeEquipmentArrayPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(Character),
            nameof(Character.ChangeEquipment),
            new[] { typeof(DataContext), typeof(ItemKey[]) });

    // 批量换装同样只做单调扩大，不从预过滤集合删除任何旧持有者。
    private static void Postfix(Character __instance)
    {
        CharacterInventoryTargetPrefilter.AddCurrentInventory(__instance);
        int charId = __instance.GetId();
        CharacterActionTargetMatcherStageCache.InvalidateInventoryTarget(charId);
        CharacterActionTargetMatcherStageCache.InvalidateEquipmentTarget(charId);
    }
}

[HarmonyPatch]
internal static class CharacterInventoryTargetPrefilterAttachPoisonsPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(Character),
            nameof(Character.AttachPoisonsToInventoryItem),
            new[] { typeof(DataContext), typeof(ItemKey), typeof(ItemKey[]) });

    // 淬毒可能替换物品 key；合并当前背包可覆盖所有成功变化。
    private static void Postfix(Character __instance)
    {
        CharacterInventoryTargetPrefilter.AddCurrentInventory(__instance);
        CharacterActionTargetMatcherStageCache.InvalidateInventoryTarget(__instance.GetId());
    }
}

[HarmonyPatch]
internal static class CharacterInventoryTargetPrefilterOnDeathTransferWugKingsPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(Character),
            nameof(Character.OnDeathTransferWugKings),
            new[] { typeof(DataContext), typeof(Location) });

    // 死亡蛊转移会直接写入背包；只扩展可能持有者集合。
    private static void Postfix(Character __instance)
    {
        CharacterInventoryTargetPrefilter.AddCurrentInventory(__instance);
        CharacterActionTargetMatcherStageCache.InvalidateInventoryTarget(__instance.GetId());
    }
}
