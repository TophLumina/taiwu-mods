using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AiCondition : ConfigData<AiConditionItem, int>
{
	public static AiCondition Instance = new AiCondition();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "ParamStrings", "ParamInts", "GroupId", "TemplateId", "Type" };

	internal override int ToInt(int value)
	{
		return value;
	}

	internal override int ToTemplateId(int value)
	{
		return value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new AiConditionItem(0, EAiConditionType.Delay, LocalStringManager.GetConfig("AiCondition_language", "Name_0"), LocalStringManager.GetConfig("AiCondition_language", "Desc_0"), new List<int> { 11 }, null, 0));
		_dataArray.Add(new AiConditionItem(1, EAiConditionType.CheckPercentProb, LocalStringManager.GetConfig("AiCondition_language", "Name_1"), LocalStringManager.GetConfig("AiCondition_language", "Desc_1"), new List<int> { 11 }, null, 0));
		_dataArray.Add(new AiConditionItem(2, EAiConditionType.First, LocalStringManager.GetConfig("AiCondition_language", "Name_2"), LocalStringManager.GetConfig("AiCondition_language", "Desc_2"), null, null, 0));
		_dataArray.Add(new AiConditionItem(3, EAiConditionType.EquipCombatSkill, LocalStringManager.GetConfig("AiCondition_language", "Name_3"), LocalStringManager.GetConfig("AiCondition_language", "Desc_3"), null, new List<int> { 3, 2 }, 1));
		_dataArray.Add(new AiConditionItem(4, EAiConditionType.BreakCombatSkill, LocalStringManager.GetConfig("AiCondition_language", "Name_4"), LocalStringManager.GetConfig("AiCondition_language", "Desc_4"), null, new List<int> { 3, 2, 12 }, 1));
		_dataArray.Add(new AiConditionItem(5, EAiConditionType.LearnCombatSkill, LocalStringManager.GetConfig("AiCondition_language", "Name_5"), LocalStringManager.GetConfig("AiCondition_language", "Desc_5"), null, new List<int> { 3, 2 }, 1));
		_dataArray.Add(new AiConditionItem(6, EAiConditionType.InCurrentAttackRange, LocalStringManager.GetConfig("AiCondition_language", "Name_6"), LocalStringManager.GetConfig("AiCondition_language", "Desc_6"), null, new List<int> { 3, 0 }, 1));
		_dataArray.Add(new AiConditionItem(7, EAiConditionType.InCombatSkillRange, LocalStringManager.GetConfig("AiCondition_language", "Name_7"), LocalStringManager.GetConfig("AiCondition_language", "Desc_7"), null, new List<int> { 3, 0, 2 }, 1));
		_dataArray.Add(new AiConditionItem(8, EAiConditionType.AnyAttackRangeEdge, LocalStringManager.GetConfig("AiCondition_language", "Name_8"), LocalStringManager.GetConfig("AiCondition_language", "Desc_8"), null, new List<int> { 3 }, 1));
		_dataArray.Add(new AiConditionItem(9, EAiConditionType.MemoryEqualString, LocalStringManager.GetConfig("AiCondition_language", "Name_9"), LocalStringManager.GetConfig("AiCondition_language", "Desc_9"), new List<int> { 4, 4 }, null, 0));
		_dataArray.Add(new AiConditionItem(10, EAiConditionType.MemoryEqualBoolean, LocalStringManager.GetConfig("AiCondition_language", "Name_10"), LocalStringManager.GetConfig("AiCondition_language", "Desc_10"), new List<int> { 4 }, new List<int> { 1 }, 0));
		_dataArray.Add(new AiConditionItem(11, EAiConditionType.MemoryEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_11"), LocalStringManager.GetConfig("AiCondition_language", "Desc_11"), new List<int> { 4, 11 }, null, 0));
		_dataArray.Add(new AiConditionItem(12, EAiConditionType.MemoryNotEqualString, LocalStringManager.GetConfig("AiCondition_language", "Name_12"), LocalStringManager.GetConfig("AiCondition_language", "Desc_12"), new List<int> { 4, 4 }, null, 0));
		_dataArray.Add(new AiConditionItem(13, EAiConditionType.MemoryNotEqualBoolean, LocalStringManager.GetConfig("AiCondition_language", "Name_13"), LocalStringManager.GetConfig("AiCondition_language", "Desc_13"), new List<int> { 4 }, new List<int> { 1 }, 0));
		_dataArray.Add(new AiConditionItem(14, EAiConditionType.MemoryNotEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_14"), LocalStringManager.GetConfig("AiCondition_language", "Desc_14"), new List<int> { 4, 11 }, null, 0));
		_dataArray.Add(new AiConditionItem(15, EAiConditionType.MemoryAbove, LocalStringManager.GetConfig("AiCondition_language", "Name_15"), LocalStringManager.GetConfig("AiCondition_language", "Desc_15"), new List<int> { 4, 11 }, null, 0));
		_dataArray.Add(new AiConditionItem(16, EAiConditionType.MemoryBelow, LocalStringManager.GetConfig("AiCondition_language", "Name_16"), LocalStringManager.GetConfig("AiCondition_language", "Desc_16"), new List<int> { 4, 11 }, null, 0));
		_dataArray.Add(new AiConditionItem(17, EAiConditionType.CombatDifficulty, LocalStringManager.GetConfig("AiCondition_language", "Name_17"), LocalStringManager.GetConfig("AiCondition_language", "Desc_17"), null, new List<int> { 5 }, 1));
		_dataArray.Add(new AiConditionItem(18, EAiConditionType.TargetDistanceNearby, LocalStringManager.GetConfig("AiCondition_language", "Name_18"), LocalStringManager.GetConfig("AiCondition_language", "Desc_18"), null, new List<int> { 9 }, 1));
		_dataArray.Add(new AiConditionItem(19, EAiConditionType.TargetDistanceIsNot, LocalStringManager.GetConfig("AiCondition_language", "Name_19"), LocalStringManager.GetConfig("AiCondition_language", "Desc_19"), null, new List<int> { 0 }, 1));
		_dataArray.Add(new AiConditionItem(20, EAiConditionType.TargetDistanceIsNotFarthest, LocalStringManager.GetConfig("AiCondition_language", "Name_20"), LocalStringManager.GetConfig("AiCondition_language", "Desc_20"), null, null, 1));
		_dataArray.Add(new AiConditionItem(21, EAiConditionType.CastingSkillType, LocalStringManager.GetConfig("AiCondition_language", "Name_21"), LocalStringManager.GetConfig("AiCondition_language", "Desc_21"), null, new List<int> { 3, 7 }, 1));
		_dataArray.Add(new AiConditionItem(22, EAiConditionType.CastingSkill, LocalStringManager.GetConfig("AiCondition_language", "Name_22"), LocalStringManager.GetConfig("AiCondition_language", "Desc_22"), null, new List<int> { 3, 2 }, 1));
		_dataArray.Add(new AiConditionItem(23, EAiConditionType.CastingProgressMoreOrEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_23"), LocalStringManager.GetConfig("AiCondition_language", "Desc_23"), new List<int> { 11 }, new List<int> { 3 }, 1));
		_dataArray.Add(new AiConditionItem(24, EAiConditionType.CastingProgressLess, LocalStringManager.GetConfig("AiCondition_language", "Name_24"), LocalStringManager.GetConfig("AiCondition_language", "Desc_24"), new List<int> { 11 }, new List<int> { 3 }, 1));
		_dataArray.Add(new AiConditionItem(25, EAiConditionType.BlockPercentLess, LocalStringManager.GetConfig("AiCondition_language", "Name_25"), LocalStringManager.GetConfig("AiCondition_language", "Desc_25"), new List<int> { 11 }, new List<int> { 3 }, 1));
		_dataArray.Add(new AiConditionItem(26, EAiConditionType.IsCharacterHalfFallen, LocalStringManager.GetConfig("AiCondition_language", "Name_26"), LocalStringManager.GetConfig("AiCondition_language", "Desc_26"), null, new List<int> { 3 }, 1));
		_dataArray.Add(new AiConditionItem(27, EAiConditionType.CheckBanFlee, LocalStringManager.GetConfig("AiCondition_language", "Name_27"), LocalStringManager.GetConfig("AiCondition_language", "Desc_27"), null, null, 1));
		_dataArray.Add(new AiConditionItem(28, EAiConditionType.CheckFleeNormal, LocalStringManager.GetConfig("AiCondition_language", "Name_28"), LocalStringManager.GetConfig("AiCondition_language", "Desc_28"), null, null, 1));
		_dataArray.Add(new AiConditionItem(29, EAiConditionType.InHazard, LocalStringManager.GetConfig("AiCondition_language", "Name_29"), LocalStringManager.GetConfig("AiCondition_language", "Desc_29"), null, null, 1));
		_dataArray.Add(new AiConditionItem(30, EAiConditionType.OptionAttack, LocalStringManager.GetConfig("AiCondition_language", "Name_30"), LocalStringManager.GetConfig("AiCondition_language", "Desc_30"), null, null, 1));
		_dataArray.Add(new AiConditionItem(31, EAiConditionType.OptionChangeTrick, LocalStringManager.GetConfig("AiCondition_language", "Name_31"), LocalStringManager.GetConfig("AiCondition_language", "Desc_31"), null, null, 1));
		_dataArray.Add(new AiConditionItem(32, EAiConditionType.OptionChangeTrickFlaw, LocalStringManager.GetConfig("AiCondition_language", "Name_32"), LocalStringManager.GetConfig("AiCondition_language", "Desc_32"), null, null, 1));
		_dataArray.Add(new AiConditionItem(33, EAiConditionType.OptionChangeTrickAcupoint, LocalStringManager.GetConfig("AiCondition_language", "Name_33"), LocalStringManager.GetConfig("AiCondition_language", "Desc_33"), null, new List<int> { 10 }, 1));
		_dataArray.Add(new AiConditionItem(34, EAiConditionType.OptionChangeTrickNeiliType, LocalStringManager.GetConfig("AiCondition_language", "Name_34"), LocalStringManager.GetConfig("AiCondition_language", "Desc_34"), null, null, 1));
		_dataArray.Add(new AiConditionItem(35, EAiConditionType.OptionChangeWeapon, LocalStringManager.GetConfig("AiCondition_language", "Name_35"), LocalStringManager.GetConfig("AiCondition_language", "Desc_35"), null, new List<int> { 0, 0 }, 1));
		_dataArray.Add(new AiConditionItem(36, EAiConditionType.OptionTryDodge, LocalStringManager.GetConfig("AiCondition_language", "Name_36"), LocalStringManager.GetConfig("AiCondition_language", "Desc_36"), null, null, 1));
		_dataArray.Add(new AiConditionItem(37, EAiConditionType.OptionOtherAction, LocalStringManager.GetConfig("AiCondition_language", "Name_37"), LocalStringManager.GetConfig("AiCondition_language", "Desc_37"), null, new List<int> { 8 }, 1));
		_dataArray.Add(new AiConditionItem(38, EAiConditionType.OptionTeammateCommand, LocalStringManager.GetConfig("AiCondition_language", "Name_38"), LocalStringManager.GetConfig("AiCondition_language", "Desc_38"), null, new List<int> { 6 }, 1));
		_dataArray.Add(new AiConditionItem(39, EAiConditionType.OptionProactiveSkillType, LocalStringManager.GetConfig("AiCondition_language", "Name_39"), LocalStringManager.GetConfig("AiCondition_language", "Desc_39"), null, new List<int> { 7 }, 1));
		_dataArray.Add(new AiConditionItem(40, EAiConditionType.OptionCastBoost, LocalStringManager.GetConfig("AiCondition_language", "Name_40"), LocalStringManager.GetConfig("AiCondition_language", "Desc_40"), null, null, 1));
		_dataArray.Add(new AiConditionItem(41, EAiConditionType.OptionCastDefendBlock, LocalStringManager.GetConfig("AiCondition_language", "Name_41"), LocalStringManager.GetConfig("AiCondition_language", "Desc_41"), null, null, 1));
		_dataArray.Add(new AiConditionItem(42, EAiConditionType.OptionCastAgileBuff, LocalStringManager.GetConfig("AiCondition_language", "Name_42"), LocalStringManager.GetConfig("AiCondition_language", "Desc_42"), null, null, 1));
		_dataArray.Add(new AiConditionItem(43, EAiConditionType.OptionUseItemHealInjury, LocalStringManager.GetConfig("AiCondition_language", "Name_43"), LocalStringManager.GetConfig("AiCondition_language", "Desc_43"), null, null, 1));
		_dataArray.Add(new AiConditionItem(44, EAiConditionType.OptionUseItemHealPoison, LocalStringManager.GetConfig("AiCondition_language", "Name_44"), LocalStringManager.GetConfig("AiCondition_language", "Desc_44"), null, null, 1));
		_dataArray.Add(new AiConditionItem(45, EAiConditionType.OptionUseItemHealQiDisorder, LocalStringManager.GetConfig("AiCondition_language", "Name_45"), LocalStringManager.GetConfig("AiCondition_language", "Desc_45"), null, null, 1));
		_dataArray.Add(new AiConditionItem(46, EAiConditionType.OptionUseItemBuff, LocalStringManager.GetConfig("AiCondition_language", "Name_46"), LocalStringManager.GetConfig("AiCondition_language", "Desc_46"), null, null, 1));
		_dataArray.Add(new AiConditionItem(47, EAiConditionType.OptionUseItemPoison, LocalStringManager.GetConfig("AiCondition_language", "Name_47"), LocalStringManager.GetConfig("AiCondition_language", "Desc_47"), null, null, 1));
		_dataArray.Add(new AiConditionItem(48, EAiConditionType.OptionUseItemNeili, LocalStringManager.GetConfig("AiCondition_language", "Name_48"), LocalStringManager.GetConfig("AiCondition_language", "Desc_48"), null, null, 1));
		_dataArray.Add(new AiConditionItem(49, EAiConditionType.OptionUseItemWine, LocalStringManager.GetConfig("AiCondition_language", "Name_49"), LocalStringManager.GetConfig("AiCondition_language", "Desc_49"), null, null, 1));
		_dataArray.Add(new AiConditionItem(50, EAiConditionType.OptionUseItemRepairWeapon, LocalStringManager.GetConfig("AiCondition_language", "Name_50"), LocalStringManager.GetConfig("AiCondition_language", "Desc_50"), null, null, 1));
		_dataArray.Add(new AiConditionItem(51, EAiConditionType.OptionUseItemRepairArmor, LocalStringManager.GetConfig("AiCondition_language", "Name_51"), LocalStringManager.GetConfig("AiCondition_language", "Desc_51"), null, null, 1));
		_dataArray.Add(new AiConditionItem(52, EAiConditionType.CombatTypeEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_52"), LocalStringManager.GetConfig("AiCondition_language", "Desc_52"), null, new List<int> { 23 }, 1));
		_dataArray.Add(new AiConditionItem(53, EAiConditionType.AnyAffectingAgile, LocalStringManager.GetConfig("AiCondition_language", "Name_53"), LocalStringManager.GetConfig("AiCondition_language", "Desc_53"), null, new List<int> { 3 }, 1));
		_dataArray.Add(new AiConditionItem(54, EAiConditionType.SpecialAffectingAgile, LocalStringManager.GetConfig("AiCondition_language", "Name_54"), LocalStringManager.GetConfig("AiCondition_language", "Desc_54"), null, new List<int> { 3, 12, 2 }, 1));
		_dataArray.Add(new AiConditionItem(55, EAiConditionType.AnyAffectingDefense, LocalStringManager.GetConfig("AiCondition_language", "Name_55"), LocalStringManager.GetConfig("AiCondition_language", "Desc_55"), null, new List<int> { 3 }, 1));
		_dataArray.Add(new AiConditionItem(56, EAiConditionType.SpecialAffectingDefense, LocalStringManager.GetConfig("AiCondition_language", "Name_56"), LocalStringManager.GetConfig("AiCondition_language", "Desc_56"), null, new List<int> { 3, 12, 2 }, 1));
		_dataArray.Add(new AiConditionItem(57, EAiConditionType.IsTaiwu, LocalStringManager.GetConfig("AiCondition_language", "Name_57"), LocalStringManager.GetConfig("AiCondition_language", "Desc_57"), null, null, 1));
		_dataArray.Add(new AiConditionItem(58, EAiConditionType.InjuryMarkCountMoreOrEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_58"), LocalStringManager.GetConfig("AiCondition_language", "Desc_58"), null, new List<int> { 3, 0, 10, 13 }, 1));
		_dataArray.Add(new AiConditionItem(59, EAiConditionType.FlawMarkCountMoreOrEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_59"), LocalStringManager.GetConfig("AiCondition_language", "Desc_59"), null, new List<int> { 3, 0, 10 }, 1));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new AiConditionItem(60, EAiConditionType.AcupointMarkCountMoreOrEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_60"), LocalStringManager.GetConfig("AiCondition_language", "Desc_60"), null, new List<int> { 3, 0, 10 }, 1));
		_dataArray.Add(new AiConditionItem(61, EAiConditionType.PoisonMarkCountMoreOrEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_61"), LocalStringManager.GetConfig("AiCondition_language", "Desc_61"), null, new List<int> { 3, 0, 14 }, 1));
		_dataArray.Add(new AiConditionItem(62, EAiConditionType.MindMarkCountMoreOrEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_62"), LocalStringManager.GetConfig("AiCondition_language", "Desc_62"), null, new List<int> { 3, 0 }, 1));
		_dataArray.Add(new AiConditionItem(63, EAiConditionType.FatalMarkCountMoreOrEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_63"), LocalStringManager.GetConfig("AiCondition_language", "Desc_63"), null, new List<int> { 3, 0 }, 1));
		_dataArray.Add(new AiConditionItem(64, EAiConditionType.DieMarkCountMoreOrEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_64"), LocalStringManager.GetConfig("AiCondition_language", "Desc_64"), null, new List<int> { 3, 0 }, 1));
		_dataArray.Add(new AiConditionItem(65, EAiConditionType.QiDisorderMarkCountMoreOrEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_65"), LocalStringManager.GetConfig("AiCondition_language", "Desc_65"), null, new List<int> { 3, 0 }, 1));
		_dataArray.Add(new AiConditionItem(66, EAiConditionType.StateMarkCountMoreOrEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_66"), LocalStringManager.GetConfig("AiCondition_language", "Desc_66"), null, new List<int> { 3, 0 }, 1));
		_dataArray.Add(new AiConditionItem(67, EAiConditionType.HealthMarkCountMoreOrEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_67"), LocalStringManager.GetConfig("AiCondition_language", "Desc_67"), null, new List<int> { 3, 0 }, 1));
		_dataArray.Add(new AiConditionItem(68, EAiConditionType.HasGrowingWug, LocalStringManager.GetConfig("AiCondition_language", "Name_68"), LocalStringManager.GetConfig("AiCondition_language", "Desc_68"), null, new List<int> { 3, 15, 16, 17 }, 1));
		_dataArray.Add(new AiConditionItem(69, EAiConditionType.HasGrownWug, LocalStringManager.GetConfig("AiCondition_language", "Name_69"), LocalStringManager.GetConfig("AiCondition_language", "Desc_69"), null, new List<int> { 3, 17 }, 1));
		_dataArray.Add(new AiConditionItem(70, EAiConditionType.HasKingWug, LocalStringManager.GetConfig("AiCondition_language", "Name_70"), LocalStringManager.GetConfig("AiCondition_language", "Desc_70"), null, new List<int> { 3, 17 }, 1));
		_dataArray.Add(new AiConditionItem(71, EAiConditionType.NeiliAllocationPercentMoreOrEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_71"), LocalStringManager.GetConfig("AiCondition_language", "Desc_71"), null, new List<int> { 3, 18, 0 }, 1));
		_dataArray.Add(new AiConditionItem(72, EAiConditionType.CombatSkillEffectCountMoreOrEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_72"), LocalStringManager.GetConfig("AiCondition_language", "Desc_72"), null, new List<int> { 3, 12, 2, 0 }, 1));
		_dataArray.Add(new AiConditionItem(73, EAiConditionType.MobilityPercentMoreOrEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_73"), LocalStringManager.GetConfig("AiCondition_language", "Desc_73"), new List<int> { 11 }, new List<int> { 3 }, 1));
		_dataArray.Add(new AiConditionItem(74, EAiConditionType.MobilityLocking, LocalStringManager.GetConfig("AiCondition_language", "Name_74"), LocalStringManager.GetConfig("AiCondition_language", "Desc_74"), null, new List<int> { 3 }, 1));
		_dataArray.Add(new AiConditionItem(75, EAiConditionType.ConsummateLevelMoreOrEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_75"), LocalStringManager.GetConfig("AiCondition_language", "Desc_75"), null, new List<int> { 3, 0 }, 1));
		_dataArray.Add(new AiConditionItem(76, EAiConditionType.BossPhaseMoreOrEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_76"), LocalStringManager.GetConfig("AiCondition_language", "Desc_76"), null, new List<int> { 0 }, 1));
		_dataArray.Add(new AiConditionItem(77, EAiConditionType.TrickCountMoreOrEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_77"), LocalStringManager.GetConfig("AiCondition_language", "Desc_77"), null, new List<int> { 3, 19, 0 }, 1));
		_dataArray.Add(new AiConditionItem(78, EAiConditionType.OptionChangeWeaponIndex, LocalStringManager.GetConfig("AiCondition_language", "Name_78"), LocalStringManager.GetConfig("AiCondition_language", "Desc_78"), null, new List<int> { 0 }, 1));
		_dataArray.Add(new AiConditionItem(79, EAiConditionType.OptionChangeWeaponSpecial, LocalStringManager.GetConfig("AiCondition_language", "Name_79"), LocalStringManager.GetConfig("AiCondition_language", "Desc_79"), null, new List<int> { 20 }, 1));
		_dataArray.Add(new AiConditionItem(80, EAiConditionType.OptionChangeWeaponType, LocalStringManager.GetConfig("AiCondition_language", "Name_80"), LocalStringManager.GetConfig("AiCondition_language", "Desc_80"), null, new List<int> { 21 }, 1));
		_dataArray.Add(new AiConditionItem(81, EAiConditionType.CurrentWeaponIsSpecial, LocalStringManager.GetConfig("AiCondition_language", "Name_81"), LocalStringManager.GetConfig("AiCondition_language", "Desc_81"), null, new List<int> { 3, 20 }, 1));
		_dataArray.Add(new AiConditionItem(82, EAiConditionType.CurrentWeaponIsType, LocalStringManager.GetConfig("AiCondition_language", "Name_82"), LocalStringManager.GetConfig("AiCondition_language", "Desc_82"), null, new List<int> { 3, 21 }, 1));
		_dataArray.Add(new AiConditionItem(83, EAiConditionType.NeiliTypeFiveElementEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_83"), LocalStringManager.GetConfig("AiCondition_language", "Desc_83"), null, new List<int> { 3, 22 }, 1));
		_dataArray.Add(new AiConditionItem(84, EAiConditionType.AllMarkCountMoreOrEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_84"), LocalStringManager.GetConfig("AiCondition_language", "Desc_84"), null, new List<int> { 3, 0 }, 1));
		_dataArray.Add(new AiConditionItem(85, EAiConditionType.OuterOrInnerInjuryMarkCountMoreOrEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_85"), LocalStringManager.GetConfig("AiCondition_language", "Desc_85"), null, new List<int> { 3, 0, 13 }, 1));
		_dataArray.Add(new AiConditionItem(86, EAiConditionType.AllInjuryMarkCountMoreOrEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_86"), LocalStringManager.GetConfig("AiCondition_language", "Desc_86"), null, new List<int> { 3, 0 }, 1));
		_dataArray.Add(new AiConditionItem(87, EAiConditionType.AllFlawMarkCountMoreOrEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_87"), LocalStringManager.GetConfig("AiCondition_language", "Desc_87"), null, new List<int> { 3, 0 }, 1));
		_dataArray.Add(new AiConditionItem(88, EAiConditionType.AllAcupointMarkCountMoreOrEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_88"), LocalStringManager.GetConfig("AiCondition_language", "Desc_88"), null, new List<int> { 3, 0 }, 1));
		_dataArray.Add(new AiConditionItem(89, EAiConditionType.MemoryInternalAbove, LocalStringManager.GetConfig("AiCondition_language", "Name_89"), LocalStringManager.GetConfig("AiCondition_language", "Desc_89"), new List<int> { 4, 4 }, null, 0));
		_dataArray.Add(new AiConditionItem(90, EAiConditionType.MemoryInternalBelow, LocalStringManager.GetConfig("AiCondition_language", "Name_90"), LocalStringManager.GetConfig("AiCondition_language", "Desc_90"), new List<int> { 4, 4 }, null, 0));
		_dataArray.Add(new AiConditionItem(91, EAiConditionType.MemoryEqualCasting, LocalStringManager.GetConfig("AiCondition_language", "Name_91"), LocalStringManager.GetConfig("AiCondition_language", "Desc_91"), new List<int> { 4 }, new List<int> { 3 }, 1));
		_dataArray.Add(new AiConditionItem(92, EAiConditionType.AttackRangeEdgeMore, LocalStringManager.GetConfig("AiCondition_language", "Name_92"), LocalStringManager.GetConfig("AiCondition_language", "Desc_92"), null, new List<int> { 3, 9 }, 1));
		_dataArray.Add(new AiConditionItem(93, EAiConditionType.AttackRangeEdgeLess, LocalStringManager.GetConfig("AiCondition_language", "Name_93"), LocalStringManager.GetConfig("AiCondition_language", "Desc_93"), null, new List<int> { 3, 9 }, 1));
		_dataArray.Add(new AiConditionItem(94, EAiConditionType.EnvironmentLastNormalAttackAnyMiss, LocalStringManager.GetConfig("AiCondition_language", "Name_94"), LocalStringManager.GetConfig("AiCondition_language", "Desc_94"), null, null, 1));
		_dataArray.Add(new AiConditionItem(95, EAiConditionType.CurrentWeaponIsIndex, LocalStringManager.GetConfig("AiCondition_language", "Name_95"), LocalStringManager.GetConfig("AiCondition_language", "Desc_95"), null, new List<int> { 3, 0 }, 1));
		_dataArray.Add(new AiConditionItem(96, EAiConditionType.CastingDirectOrReverseSkill, LocalStringManager.GetConfig("AiCondition_language", "Name_96"), LocalStringManager.GetConfig("AiCondition_language", "Desc_96"), null, new List<int> { 3, 12, 2 }, 1));
		_dataArray.Add(new AiConditionItem(97, EAiConditionType.OptionCastSpecialCombatSkill, LocalStringManager.GetConfig("AiCondition_language", "Name_97"), LocalStringManager.GetConfig("AiCondition_language", "Desc_97"), null, new List<int> { 2 }, 1));
		_dataArray.Add(new AiConditionItem(98, EAiConditionType.OptionCastDirectOrReverseCombatSkill, LocalStringManager.GetConfig("AiCondition_language", "Name_98"), LocalStringManager.GetConfig("AiCondition_language", "Desc_98"), null, new List<int> { 2, 12 }, 1));
		_dataArray.Add(new AiConditionItem(99, EAiConditionType.BuffStatePowerSumMoreOrEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_99"), LocalStringManager.GetConfig("AiCondition_language", "Desc_99"), new List<int> { 24 }, new List<int> { 3, 0 }, 1));
		_dataArray.Add(new AiConditionItem(100, EAiConditionType.DebuffStatePowerSumMoreOrEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_100"), LocalStringManager.GetConfig("AiCondition_language", "Desc_100"), new List<int> { 24 }, new List<int> { 3, 0 }, 1));
		_dataArray.Add(new AiConditionItem(101, EAiConditionType.SpecialStatePowerSumMoreOrEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_101"), LocalStringManager.GetConfig("AiCondition_language", "Desc_101"), new List<int> { 24 }, new List<int> { 3, 0 }, 1));
		_dataArray.Add(new AiConditionItem(102, EAiConditionType.InMemoryCombatSkillRange, LocalStringManager.GetConfig("AiCondition_language", "Name_102"), LocalStringManager.GetConfig("AiCondition_language", "Desc_102"), new List<int> { 4 }, new List<int> { 3, 0 }, 1));
		_dataArray.Add(new AiConditionItem(103, EAiConditionType.OptionCastMemoryCombatSkill, LocalStringManager.GetConfig("AiCondition_language", "Name_103"), LocalStringManager.GetConfig("AiCondition_language", "Desc_103"), new List<int> { 4 }, null, 1));
		_dataArray.Add(new AiConditionItem(104, EAiConditionType.CurrentDistanceEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_104"), LocalStringManager.GetConfig("AiCondition_language", "Desc_104"), null, new List<int> { 0 }, 1));
		_dataArray.Add(new AiConditionItem(105, EAiConditionType.CurrentDistanceAbove, LocalStringManager.GetConfig("AiCondition_language", "Name_105"), LocalStringManager.GetConfig("AiCondition_language", "Desc_105"), null, new List<int> { 0 }, 1));
		_dataArray.Add(new AiConditionItem(106, EAiConditionType.CurrentDistanceBelow, LocalStringManager.GetConfig("AiCondition_language", "Name_106"), LocalStringManager.GetConfig("AiCondition_language", "Desc_106"), null, new List<int> { 0 }, 1));
		_dataArray.Add(new AiConditionItem(107, EAiConditionType.EnvironmentLastNormalAttackOutOfRange, LocalStringManager.GetConfig("AiCondition_language", "Name_107"), LocalStringManager.GetConfig("AiCondition_language", "Desc_107"), null, null, 1));
		_dataArray.Add(new AiConditionItem(108, EAiConditionType.OptionUnlockAttackWeapon, LocalStringManager.GetConfig("AiCondition_language", "Name_108"), LocalStringManager.GetConfig("AiCondition_language", "Desc_108"), null, new List<int> { 20 }, 1));
		_dataArray.Add(new AiConditionItem(109, EAiConditionType.OptionUnlockAttackWeaponType, LocalStringManager.GetConfig("AiCondition_language", "Name_109"), LocalStringManager.GetConfig("AiCondition_language", "Desc_109"), null, new List<int> { 21 }, 1));
		_dataArray.Add(new AiConditionItem(110, EAiConditionType.UnlockAttackValuePercentMoreOrEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_110"), LocalStringManager.GetConfig("AiCondition_language", "Desc_110"), new List<int> { 11 }, new List<int> { 3, 20 }, 1));
		_dataArray.Add(new AiConditionItem(111, EAiConditionType.OptionInterruptCasting, LocalStringManager.GetConfig("AiCondition_language", "Name_111"), LocalStringManager.GetConfig("AiCondition_language", "Desc_111"), null, null, 1));
		_dataArray.Add(new AiConditionItem(112, EAiConditionType.OptionInterruptAffectingDefense, LocalStringManager.GetConfig("AiCondition_language", "Name_112"), LocalStringManager.GetConfig("AiCondition_language", "Desc_112"), null, null, 1));
		_dataArray.Add(new AiConditionItem(113, EAiConditionType.OptionInterruptAffectingMove, LocalStringManager.GetConfig("AiCondition_language", "Name_113"), LocalStringManager.GetConfig("AiCondition_language", "Desc_113"), null, null, 1));
		_dataArray.Add(new AiConditionItem(114, EAiConditionType.OptionAutoCostTrick, LocalStringManager.GetConfig("AiCondition_language", "Name_114"), LocalStringManager.GetConfig("AiCondition_language", "Desc_114"), null, null, 1));
		_dataArray.Add(new AiConditionItem(115, EAiConditionType.OptionUseItemMisc, LocalStringManager.GetConfig("AiCondition_language", "Name_115"), LocalStringManager.GetConfig("AiCondition_language", "Desc_115"), null, new List<int> { 25 }, 1));
		_dataArray.Add(new AiConditionItem(116, EAiConditionType.AnyNotInfinitySilenceSkill, LocalStringManager.GetConfig("AiCondition_language", "Name_116"), LocalStringManager.GetConfig("AiCondition_language", "Desc_116"), null, new List<int> { 3 }, 1));
		_dataArray.Add(new AiConditionItem(117, EAiConditionType.AnyTeammate, LocalStringManager.GetConfig("AiCondition_language", "Name_117"), LocalStringManager.GetConfig("AiCondition_language", "Desc_117"), null, new List<int> { 3 }, 1));
		_dataArray.Add(new AiConditionItem(118, EAiConditionType.BreathPercentMoreOrEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_118"), LocalStringManager.GetConfig("AiCondition_language", "Desc_118"), new List<int> { 11 }, new List<int> { 3 }, 1));
		_dataArray.Add(new AiConditionItem(119, EAiConditionType.StancePercentMoreOrEqual, LocalStringManager.GetConfig("AiCondition_language", "Name_119"), LocalStringManager.GetConfig("AiCondition_language", "Desc_119"), new List<int> { 11 }, new List<int> { 3 }, 1));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new AiConditionItem(120, EAiConditionType.TargetDistanceGreaterThan, LocalStringManager.GetConfig("AiCondition_language", "Name_120"), LocalStringManager.GetConfig("AiCondition_language", "Desc_120"), null, new List<int> { 0 }, 1));
		_dataArray.Add(new AiConditionItem(121, EAiConditionType.PenetrationResist, LocalStringManager.GetConfig("AiCondition_language", "Name_121"), LocalStringManager.GetConfig("AiCondition_language", "Desc_121"), null, new List<int> { 3, 0 }, 1));
		_dataArray.Add(new AiConditionItem(122, EAiConditionType.PreparingAttackRatio, LocalStringManager.GetConfig("AiCondition_language", "Name_122"), LocalStringManager.GetConfig("AiCondition_language", "Desc_122"), null, new List<int> { 3, 0, 0 }, 1));
		_dataArray.Add(new AiConditionItem(123, EAiConditionType.MoveJump, LocalStringManager.GetConfig("AiCondition_language", "Name_123"), LocalStringManager.GetConfig("AiCondition_language", "Desc_123"), null, null, 1));
		_dataArray.Add(new AiConditionItem(124, EAiConditionType.ExistAttackRatio, LocalStringManager.GetConfig("AiCondition_language", "Name_124"), LocalStringManager.GetConfig("AiCondition_language", "Desc_124"), null, new List<int> { 0, 0 }, 1));
		_dataArray.Add(new AiConditionItem(125, EAiConditionType.ExistDefenseBounce, LocalStringManager.GetConfig("AiCondition_language", "Name_125"), LocalStringManager.GetConfig("AiCondition_language", "Desc_125"), null, new List<int> { 13 }, 1));
		_dataArray.Add(new AiConditionItem(126, EAiConditionType.AttackMiss, LocalStringManager.GetConfig("AiCondition_language", "Name_126"), LocalStringManager.GetConfig("AiCondition_language", "Desc_126"), null, null, 1));
		_dataArray.Add(new AiConditionItem(127, EAiConditionType.AnyReserve, LocalStringManager.GetConfig("AiCondition_language", "Name_127"), LocalStringManager.GetConfig("AiCondition_language", "Desc_127"), null, new List<int> { 3 }, 1));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AiConditionItem>(128);
		CreateItems0();
		CreateItems1();
		CreateItems2();
	}
}
