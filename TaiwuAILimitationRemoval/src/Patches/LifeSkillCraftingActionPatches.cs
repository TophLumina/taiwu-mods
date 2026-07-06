using System;
using System.Collections.Generic;
using System.Reflection;
using Config;
using GameData.ActionPlanning.ActionImpl;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.Organization;
using GameData.Utilities;
using HarmonyLib;
using TaiwuRemoveAILimitation.Runtime;
using Character = GameData.Domains.Character.Character;

namespace TaiwuRemoveAILimitation.Patches;

[HarmonyPatch]
internal static class LifeSkillCraftingActionOfflineInitPatch
{
    [ThreadStatic]
    private static List<ItemKey>? _craftMaterials;

    private static MethodBase TargetMethod()
    {
        InterfaceMapping map = typeof(LifeSkillCraftingAction).GetInterfaceMap(typeof(ICharacterActionImpl));
        MethodInfo interfaceMethod = AccessTools.Method(
            typeof(ICharacterActionImpl),
            nameof(ICharacterActionImpl.OfflineInitActionData));

        for (int i = 0; i < map.InterfaceMethods.Length; i++)
        {
            if (map.InterfaceMethods[i] == interfaceMethod)
            {
                return map.TargetMethods[i];
            }
        }

        throw new MissingMethodException(
            typeof(LifeSkillCraftingAction).FullName,
            nameof(ICharacterActionImpl.OfflineInitActionData));
    }

    private static bool Prefix(
        LifeSkillCraftingAction __instance,
        DataContext context,
        Character character,
        ref bool __result)
    {
        if (!TaiwuRemoveAILimitationSettings.EnableNpcActionLimitationRemoval)
        {
            return true;
        }

        __result = InitActionDataWithLocalBuffers(__instance, context, character);
        return false;
    }

    private static bool InitActionDataWithLocalBuffers(
        LifeSkillCraftingAction action,
        DataContext context,
        Character character)
    {
        if (character.GetInventory().Items.Count <= 1)
        {
            return false;
        }

        if (!context.Random.CheckPercentProb(50 + character.GetPersonality(2)))
        {
            return false;
        }

        Span<sbyte> availableCraftingTypes = stackalloc sbyte[GameData.Domains.Character.LifeSkillType.CraftingTypes.Length];
        int availableCount = 0;
        foreach (sbyte craftingType in GameData.Domains.Character.LifeSkillType.CraftingTypes)
        {
            if (character.GetLifeSkillAttainment(craftingType) >= 200)
            {
                availableCraftingTypes[availableCount] = craftingType;
                availableCount++;
            }
        }

        if (availableCount == 0)
        {
            return false;
        }

        CollectionUtils.Shuffle(context.Random, availableCraftingTypes, availableCount);

        List<ItemKey> craftMaterials = GetCraftMaterialsBuffer();
        for (int i = 0; i < availableCount; i++)
        {
            sbyte craftingType = availableCraftingTypes[i];
            craftMaterials.Clear();
            character.GetInventory().GetCraftMaterials(craftingType, craftMaterials);
            if (craftMaterials.Count == 0)
            {
                continue;
            }

            ItemKey materialKey = craftMaterials.GetRandom(context.Random);
            MaterialItem materialItem = Config.Material.Instance[materialKey.TemplateId];
            ItemKey bestCraftTool = character.GetInventory()
                .GetBestCraftTool(craftingType, materialItem.Grade, out short _);
            if (!bestCraftTool.IsValid())
            {
                continue;
            }

            short makeItemTypeId = materialItem.CraftableItemTypes.GetRandom(context.Random);
            List<short> makeItemSubTypes = MakeItemType.Instance[makeItemTypeId].MakeItemSubTypes;
            short makeItemSubTypeId = makeItemSubTypes.GetRandom(context.Random);
            MakeItemSubTypeItem makeItemSubTypeItem = MakeItemSubType.Instance[makeItemSubTypeId];
            int requiredMoney = GetMakeItemRequiredResourceWorth(materialItem, makeItemSubTypeItem) *
                                OrganizationDomain.GetOrgMemberConfig(character.GetOrganizationInfo()).PurchaseItemDiscount /
                                100;

            if (character.GetResource(6) < requiredMoney)
            {
                continue;
            }

            int allPagesReadCookingSkillBookCount = character.GetAllPagesReadCookingSkillBookCount();
            short totalAttainment = (short)(character.GetLifeSkillAttainment(craftingType) +
                                            Config.CraftTool.Instance[bestCraftTool.TemplateId].AttainmentBonus);
            (sbyte, short) result = DomainManager.Building.GetMakeResultTargetItemGradeAndTemplateId(
                materialKey.TemplateId,
                totalAttainment,
                craftingType,
                makeItemSubTypes,
                makeItemSubTypeId,
                allPagesReadCookingSkillBookCount,
                context.Random,
                upgradeMakeItem: false,
                0);

            if (result.Item2 < 0)
            {
                continue;
            }

            action.ToolUsed = bestCraftTool;
            action.Material = materialKey;
            action.RequiredMoney = requiredMoney;
            action.ActionLifeSkillType = craftingType;
            action.TargetItemType = makeItemSubTypeItem.Result.ItemType;
            action.TargetItemTemplateId = result.Item2;
            break;
        }

        return true;
    }

    private static int GetMakeItemRequiredResourceWorth(
        MaterialItem materialItem,
        MakeItemSubTypeItem makeItemSubTypeItem)
    {
        return GlobalConfig.ResourcesWorth[materialItem.ResourceType] *
               makeItemSubTypeItem.ResourceTotalCount *
               materialItem.RequiredResourceAmount;
    }

    private static List<ItemKey> GetCraftMaterialsBuffer()
    {
        List<ItemKey>? buffer = _craftMaterials;
        if (buffer == null)
        {
            buffer = new List<ItemKey>(16);
            _craftMaterials = buffer;
        }

        buffer.Clear();
        return buffer;
    }
}
