using System;
using System.Collections.Generic;
using System.Reflection;
using Config;
using GameData.ActionPlanning.ActionImpl;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Utilities;
using HarmonyLib;
using TaiwuRemoveAILimitation.Runtime;
using Character = GameData.Domains.Character.Character;

namespace TaiwuRemoveAILimitation.Patches;

[HarmonyPatch]
internal static class GainExpByReadingActionOfflineInitPatch
{
    [ThreadStatic]
    private static List<ItemKey>? _candidateBooks;

    private static MethodBase TargetMethod()
    {
        InterfaceMapping map = typeof(GainExpByReadingAction).GetInterfaceMap(typeof(ICharacterActionImpl));
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
            typeof(GainExpByReadingAction).FullName,
            nameof(ICharacterActionImpl.OfflineInitActionData));
    }

    private static bool Prefix(
        GainExpByReadingAction __instance,
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
        GainExpByReadingAction action,
        DataContext context,
        Character character)
    {
        action.ItemKey = SelectBookToReadForExp(context, character);
        if (!action.ItemKey.IsValid())
        {
            return false;
        }

        sbyte grade = Config.SkillBook.Instance[action.ItemKey.TemplateId].Grade;
        short durabilityReduction = 3;
        short currDurability = DomainManager.Item.GetElement_SkillBooks(action.ItemKey.Id).GetCurrDurability();
        if (durabilityReduction > currDurability)
        {
            durabilityReduction = currDurability;
        }

        action.ExpGain = SkillGradeData.Instance[grade].ReadingExpGainPerPage * durabilityReduction;
        action.DurabilityReduction = durabilityReduction;
        return true;
    }

    private static ItemKey SelectBookToReadForExp(DataContext context, Character character)
    {
        int charId = character.GetId();
        Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> charCombatSkills =
            DomainManager.CombatSkill.GetCharCombatSkills(charId);
        List<ItemKey> candidates = GetCandidateBooksBuffer();

        foreach (ItemKey key in character.GetInventory().Items.Keys)
        {
            if (key.ItemType != 10)
            {
                continue;
            }

            GameData.Domains.Item.SkillBook book = DomainManager.Item.GetElement_SkillBooks(key.Id);
            if (book.GetCurrDurability() >= book.GetMaxDurability())
            {
                continue;
            }

            if (book.IsCombatSkillBook())
            {
                if (charCombatSkills.TryGetValue(book.GetCombatSkillTemplateId(), out GameData.Domains.CombatSkill.CombatSkill? skill) &&
                    skill != null &&
                    CombatSkillStateHelper.IsReadNormalPagesMeetConditionOfBreakout(skill.GetReadingState()))
                {
                    candidates.Add(key);
                }

                continue;
            }

            int learnedLifeSkillIndex = character.FindLearnedLifeSkillIndex(book.GetLifeSkillTemplateId());
            if (learnedLifeSkillIndex >= 0 && character.GetLearnedLifeSkills()[learnedLifeSkillIndex].IsAllPagesRead())
            {
                candidates.Add(key);
            }
        }

        return candidates.Count == 0 ? ItemKey.Invalid : candidates.GetRandom(context.Random);
    }

    private static List<ItemKey> GetCandidateBooksBuffer()
    {
        List<ItemKey>? buffer = _candidateBooks;
        if (buffer == null)
        {
            buffer = new List<ItemKey>(8);
            _candidateBooks = buffer;
        }

        buffer.Clear();
        return buffer;
    }
}
