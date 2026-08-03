using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AiAction : ConfigData<AiActionItem, int>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static AiAction Instance = new AiAction();

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
		_dataArray.Add(new AiActionItem(0, EAiActionType.NormalAttack, LocalStringManager.GetConfig("AiAction_language", "Name_0"), LocalStringManager.GetConfig("AiAction_language", "Desc_0"), null, null, 1));
		_dataArray.Add(new AiActionItem(1, EAiActionType.ChangeTrick, LocalStringManager.GetConfig("AiAction_language", "Name_1"), LocalStringManager.GetConfig("AiAction_language", "Desc_1"), new List<int> { 4 }, null, 1));
		_dataArray.Add(new AiActionItem(2, EAiActionType.ChangeTrickFlaw, LocalStringManager.GetConfig("AiAction_language", "Name_2"), LocalStringManager.GetConfig("AiAction_language", "Desc_2"), new List<int> { 4 }, null, 1));
		_dataArray.Add(new AiActionItem(3, EAiActionType.ChangeTrickAcupoint, LocalStringManager.GetConfig("AiAction_language", "Name_3"), LocalStringManager.GetConfig("AiAction_language", "Desc_3"), new List<int> { 4 }, new List<int> { 10 }, 1));
		_dataArray.Add(new AiActionItem(4, EAiActionType.ChangeTrickNeiliType, LocalStringManager.GetConfig("AiAction_language", "Name_4"), LocalStringManager.GetConfig("AiAction_language", "Desc_4"), new List<int> { 4 }, null, 1));
		_dataArray.Add(new AiActionItem(5, EAiActionType.CastSkill, LocalStringManager.GetConfig("AiAction_language", "Name_5"), LocalStringManager.GetConfig("AiAction_language", "Desc_5"), null, new List<int> { 2 }, 1));
		_dataArray.Add(new AiActionItem(6, EAiActionType.CastSkillAttackBest, LocalStringManager.GetConfig("AiAction_language", "Name_6"), LocalStringManager.GetConfig("AiAction_language", "Desc_6"), null, null, 1));
		_dataArray.Add(new AiActionItem(7, EAiActionType.CastSkillDefendBest, LocalStringManager.GetConfig("AiAction_language", "Name_7"), LocalStringManager.GetConfig("AiAction_language", "Desc_7"), null, null, 1));
		_dataArray.Add(new AiActionItem(8, EAiActionType.CastSkillDefendBlock, LocalStringManager.GetConfig("AiAction_language", "Name_8"), LocalStringManager.GetConfig("AiAction_language", "Desc_8"), null, null, 1));
		_dataArray.Add(new AiActionItem(9, EAiActionType.CastSkillAgileBuff, LocalStringManager.GetConfig("AiAction_language", "Name_9"), LocalStringManager.GetConfig("AiAction_language", "Desc_9"), null, null, 1));
		_dataArray.Add(new AiActionItem(10, EAiActionType.CastSkillAgileSpeed, LocalStringManager.GetConfig("AiAction_language", "Name_10"), LocalStringManager.GetConfig("AiAction_language", "Desc_10"), null, null, 1));
		_dataArray.Add(new AiActionItem(11, EAiActionType.CastSkillCastBoost, LocalStringManager.GetConfig("AiAction_language", "Name_11"), LocalStringManager.GetConfig("AiAction_language", "Desc_11"), null, null, 1));
		_dataArray.Add(new AiActionItem(12, EAiActionType.MoveToAttackRangeCenter, LocalStringManager.GetConfig("AiAction_language", "Name_12"), LocalStringManager.GetConfig("AiAction_language", "Desc_12"), null, new List<int> { 0 }, 1));
		_dataArray.Add(new AiActionItem(13, EAiActionType.MoveToNearbyEscape, LocalStringManager.GetConfig("AiAction_language", "Name_13"), LocalStringManager.GetConfig("AiAction_language", "Desc_13"), null, null, 1));
		_dataArray.Add(new AiActionItem(14, EAiActionType.MoveToTargetDistance, LocalStringManager.GetConfig("AiAction_language", "Name_14"), LocalStringManager.GetConfig("AiAction_language", "Desc_14"), null, new List<int> { 0 }, 1));
		_dataArray.Add(new AiActionItem(15, EAiActionType.MoveToFarthest, LocalStringManager.GetConfig("AiAction_language", "Name_15"), LocalStringManager.GetConfig("AiAction_language", "Desc_15"), null, null, 1));
		_dataArray.Add(new AiActionItem(16, EAiActionType.MemorySetString, LocalStringManager.GetConfig("AiAction_language", "Name_16"), LocalStringManager.GetConfig("AiAction_language", "Desc_16"), new List<int> { 4, 4 }, null, 0));
		_dataArray.Add(new AiActionItem(17, EAiActionType.MemorySetBoolean, LocalStringManager.GetConfig("AiAction_language", "Name_17"), LocalStringManager.GetConfig("AiAction_language", "Desc_17"), new List<int> { 4 }, new List<int> { 1 }, 0));
		_dataArray.Add(new AiActionItem(18, EAiActionType.MemorySet, LocalStringManager.GetConfig("AiAction_language", "Name_18"), LocalStringManager.GetConfig("AiAction_language", "Desc_18"), new List<int> { 4, 11 }, null, 0));
		_dataArray.Add(new AiActionItem(19, EAiActionType.UseTeammateCommand, LocalStringManager.GetConfig("AiAction_language", "Name_19"), LocalStringManager.GetConfig("AiAction_language", "Desc_19"), null, new List<int> { 6 }, 1));
		_dataArray.Add(new AiActionItem(20, EAiActionType.ChangeWeaponAuto, LocalStringManager.GetConfig("AiAction_language", "Name_20"), LocalStringManager.GetConfig("AiAction_language", "Desc_20"), null, new List<int> { 0, 0 }, 1));
		_dataArray.Add(new AiActionItem(21, EAiActionType.UseOtherAction, LocalStringManager.GetConfig("AiAction_language", "Name_21"), LocalStringManager.GetConfig("AiAction_language", "Desc_21"), null, new List<int> { 8 }, 1));
		_dataArray.Add(new AiActionItem(22, EAiActionType.UseItemHealInjury, LocalStringManager.GetConfig("AiAction_language", "Name_22"), LocalStringManager.GetConfig("AiAction_language", "Desc_22"), null, null, 1));
		_dataArray.Add(new AiActionItem(23, EAiActionType.UseItemHealPoison, LocalStringManager.GetConfig("AiAction_language", "Name_23"), LocalStringManager.GetConfig("AiAction_language", "Desc_23"), null, null, 1));
		_dataArray.Add(new AiActionItem(24, EAiActionType.UseItemHealQiDisorder, LocalStringManager.GetConfig("AiAction_language", "Name_24"), LocalStringManager.GetConfig("AiAction_language", "Desc_24"), null, null, 1));
		_dataArray.Add(new AiActionItem(25, EAiActionType.UseItemBuff, LocalStringManager.GetConfig("AiAction_language", "Name_25"), LocalStringManager.GetConfig("AiAction_language", "Desc_25"), null, null, 1));
		_dataArray.Add(new AiActionItem(26, EAiActionType.UseItemPoison, LocalStringManager.GetConfig("AiAction_language", "Name_26"), LocalStringManager.GetConfig("AiAction_language", "Desc_26"), null, null, 1));
		_dataArray.Add(new AiActionItem(27, EAiActionType.UseItemNeili, LocalStringManager.GetConfig("AiAction_language", "Name_27"), LocalStringManager.GetConfig("AiAction_language", "Desc_27"), null, null, 1));
		_dataArray.Add(new AiActionItem(28, EAiActionType.UseItemWine, LocalStringManager.GetConfig("AiAction_language", "Name_28"), LocalStringManager.GetConfig("AiAction_language", "Desc_28"), null, null, 1));
		_dataArray.Add(new AiActionItem(29, EAiActionType.UseItemRepairWeapon, LocalStringManager.GetConfig("AiAction_language", "Name_29"), LocalStringManager.GetConfig("AiAction_language", "Desc_29"), null, null, 1));
		_dataArray.Add(new AiActionItem(30, EAiActionType.UseItemRepairArmor, LocalStringManager.GetConfig("AiAction_language", "Name_30"), LocalStringManager.GetConfig("AiAction_language", "Desc_30"), null, null, 1));
		_dataArray.Add(new AiActionItem(31, EAiActionType.ChangeWeaponIndex, LocalStringManager.GetConfig("AiAction_language", "Name_31"), LocalStringManager.GetConfig("AiAction_language", "Desc_31"), null, new List<int> { 0 }, 1));
		_dataArray.Add(new AiActionItem(32, EAiActionType.ChangeWeaponSpecial, LocalStringManager.GetConfig("AiAction_language", "Name_32"), LocalStringManager.GetConfig("AiAction_language", "Desc_32"), null, new List<int> { 20 }, 1));
		_dataArray.Add(new AiActionItem(33, EAiActionType.ChangeWeaponType, LocalStringManager.GetConfig("AiAction_language", "Name_33"), LocalStringManager.GetConfig("AiAction_language", "Desc_33"), null, new List<int> { 21 }, 1));
		_dataArray.Add(new AiActionItem(34, EAiActionType.MemoryAdd, LocalStringManager.GetConfig("AiAction_language", "Name_34"), LocalStringManager.GetConfig("AiAction_language", "Desc_34"), new List<int> { 4, 11 }, null, 0));
		_dataArray.Add(new AiActionItem(35, EAiActionType.InterruptCasting, LocalStringManager.GetConfig("AiAction_language", "Name_35"), LocalStringManager.GetConfig("AiAction_language", "Desc_35"), null, null, 1));
		_dataArray.Add(new AiActionItem(36, EAiActionType.InterruptAffectingDefense, LocalStringManager.GetConfig("AiAction_language", "Name_36"), LocalStringManager.GetConfig("AiAction_language", "Desc_36"), null, null, 1));
		_dataArray.Add(new AiActionItem(37, EAiActionType.MemoryInternalSetString, LocalStringManager.GetConfig("AiAction_language", "Name_37"), LocalStringManager.GetConfig("AiAction_language", "Desc_37"), new List<int> { 4, 4 }, null, 0));
		_dataArray.Add(new AiActionItem(38, EAiActionType.MemoryInternalSetBoolean, LocalStringManager.GetConfig("AiAction_language", "Name_38"), LocalStringManager.GetConfig("AiAction_language", "Desc_38"), new List<int> { 4, 4 }, null, 0));
		_dataArray.Add(new AiActionItem(39, EAiActionType.MemoryInternalSet, LocalStringManager.GetConfig("AiAction_language", "Name_39"), LocalStringManager.GetConfig("AiAction_language", "Desc_39"), new List<int> { 4, 4 }, null, 0));
		_dataArray.Add(new AiActionItem(40, EAiActionType.MemorySetAllMarkCount, LocalStringManager.GetConfig("AiAction_language", "Name_40"), LocalStringManager.GetConfig("AiAction_language", "Desc_40"), new List<int> { 4 }, new List<int> { 3 }, 1));
		_dataArray.Add(new AiActionItem(41, EAiActionType.MemorySetInjuryMarkCount, LocalStringManager.GetConfig("AiAction_language", "Name_41"), LocalStringManager.GetConfig("AiAction_language", "Desc_41"), new List<int> { 4 }, new List<int> { 3 }, 1));
		_dataArray.Add(new AiActionItem(42, EAiActionType.MemorySetFlawMarkCount, LocalStringManager.GetConfig("AiAction_language", "Name_42"), LocalStringManager.GetConfig("AiAction_language", "Desc_42"), new List<int> { 4 }, new List<int> { 3 }, 1));
		_dataArray.Add(new AiActionItem(43, EAiActionType.MemorySetAcupointMarkCount, LocalStringManager.GetConfig("AiAction_language", "Name_43"), LocalStringManager.GetConfig("AiAction_language", "Desc_43"), new List<int> { 4 }, new List<int> { 3 }, 1));
		_dataArray.Add(new AiActionItem(44, EAiActionType.MemorySetPoisonMarkCount, LocalStringManager.GetConfig("AiAction_language", "Name_44"), LocalStringManager.GetConfig("AiAction_language", "Desc_44"), new List<int> { 4 }, new List<int> { 3 }, 1));
		_dataArray.Add(new AiActionItem(45, EAiActionType.MemorySetMindMarkCount, LocalStringManager.GetConfig("AiAction_language", "Name_45"), LocalStringManager.GetConfig("AiAction_language", "Desc_45"), new List<int> { 4 }, new List<int> { 3 }, 1));
		_dataArray.Add(new AiActionItem(46, EAiActionType.MemorySetFatalMarkCount, LocalStringManager.GetConfig("AiAction_language", "Name_46"), LocalStringManager.GetConfig("AiAction_language", "Desc_46"), new List<int> { 4 }, new List<int> { 3 }, 1));
		_dataArray.Add(new AiActionItem(47, EAiActionType.MemorySetChangeTrickCountByFlawCost, LocalStringManager.GetConfig("AiAction_language", "Name_47"), LocalStringManager.GetConfig("AiAction_language", "Desc_47"), new List<int> { 4 }, new List<int> { 3 }, 1));
		_dataArray.Add(new AiActionItem(48, EAiActionType.MemorySetSpecialCombatSkill, LocalStringManager.GetConfig("AiAction_language", "Name_48"), LocalStringManager.GetConfig("AiAction_language", "Desc_48"), new List<int> { 4 }, new List<int> { 2 }, 1));
		_dataArray.Add(new AiActionItem(49, EAiActionType.MoveToAttackRangeEdge, LocalStringManager.GetConfig("AiAction_language", "Name_49"), LocalStringManager.GetConfig("AiAction_language", "Desc_49"), null, new List<int> { 9, 0 }, 1));
		_dataArray.Add(new AiActionItem(50, EAiActionType.MemorySetLastPrepareCombatSkill, LocalStringManager.GetConfig("AiAction_language", "Name_50"), LocalStringManager.GetConfig("AiAction_language", "Desc_50"), new List<int> { 4 }, new List<int> { 3 }, 1));
		_dataArray.Add(new AiActionItem(51, EAiActionType.PrioritySetHigh, LocalStringManager.GetConfig("AiAction_language", "Name_51"), LocalStringManager.GetConfig("AiAction_language", "Desc_51"), new List<int> { 4 }, null, 1));
		_dataArray.Add(new AiActionItem(52, EAiActionType.PrioritySetLow, LocalStringManager.GetConfig("AiAction_language", "Name_52"), LocalStringManager.GetConfig("AiAction_language", "Desc_52"), new List<int> { 4 }, null, 1));
		_dataArray.Add(new AiActionItem(53, EAiActionType.PriorityReset, LocalStringManager.GetConfig("AiAction_language", "Name_53"), LocalStringManager.GetConfig("AiAction_language", "Desc_53"), new List<int> { 4 }, null, 1));
		_dataArray.Add(new AiActionItem(54, EAiActionType.MemorySetBestAttackCombatSkill, LocalStringManager.GetConfig("AiAction_language", "Name_54"), LocalStringManager.GetConfig("AiAction_language", "Desc_54"), new List<int> { 4 }, null, 1));
		_dataArray.Add(new AiActionItem(55, EAiActionType.CastSkillByMemory, LocalStringManager.GetConfig("AiAction_language", "Name_55"), LocalStringManager.GetConfig("AiAction_language", "Desc_55"), new List<int> { 4 }, null, 1));
		_dataArray.Add(new AiActionItem(56, EAiActionType.InterruptAffectingMove, LocalStringManager.GetConfig("AiAction_language", "Name_56"), LocalStringManager.GetConfig("AiAction_language", "Desc_56"), null, null, 1));
		_dataArray.Add(new AiActionItem(57, EAiActionType.UnlockAttackWeapon, LocalStringManager.GetConfig("AiAction_language", "Name_57"), LocalStringManager.GetConfig("AiAction_language", "Desc_57"), null, new List<int> { 20 }, 1));
		_dataArray.Add(new AiActionItem(58, EAiActionType.UnlockAttackWeaponType, LocalStringManager.GetConfig("AiAction_language", "Name_58"), LocalStringManager.GetConfig("AiAction_language", "Desc_58"), null, new List<int> { 21 }, 1));
		_dataArray.Add(new AiActionItem(59, EAiActionType.CostFirstUnavailableTrick, LocalStringManager.GetConfig("AiAction_language", "Name_59"), LocalStringManager.GetConfig("AiAction_language", "Desc_59"), null, null, 1));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new AiActionItem(60, EAiActionType.CostMemoryFirstTrick, LocalStringManager.GetConfig("AiAction_language", "Name_60"), LocalStringManager.GetConfig("AiAction_language", "Desc_60"), new List<int> { 4 }, null, 1));
		_dataArray.Add(new AiActionItem(61, EAiActionType.CostFirstAnyTrick, LocalStringManager.GetConfig("AiAction_language", "Name_61"), LocalStringManager.GetConfig("AiAction_language", "Desc_61"), null, null, 1));
		_dataArray.Add(new AiActionItem(62, EAiActionType.UseItemMisc, LocalStringManager.GetConfig("AiAction_language", "Name_62"), LocalStringManager.GetConfig("AiAction_language", "Desc_62"), null, new List<int> { 25 }, 1));
		_dataArray.Add(new AiActionItem(63, EAiActionType.MemorySetNeedUseSkill, LocalStringManager.GetConfig("AiAction_language", "Name_63"), LocalStringManager.GetConfig("AiAction_language", "Desc_63"), new List<int> { 4 }, null, 1));
		_dataArray.Add(new AiActionItem(64, EAiActionType.CastSkillAgileJumpPrepare, LocalStringManager.GetConfig("AiAction_language", "Name_64"), LocalStringManager.GetConfig("AiAction_language", "Desc_64"), null, new List<int> { 12 }, 1));
		_dataArray.Add(new AiActionItem(65, EAiActionType.CastSkillAttackRatio, LocalStringManager.GetConfig("AiAction_language", "Name_65"), LocalStringManager.GetConfig("AiAction_language", "Desc_65"), null, new List<int> { 0, 0 }, 1));
		_dataArray.Add(new AiActionItem(66, EAiActionType.CastSkillDefenceBounce, LocalStringManager.GetConfig("AiAction_language", "Name_66"), LocalStringManager.GetConfig("AiAction_language", "Desc_66"), null, new List<int> { 13 }, 1));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AiActionItem>(67);
		CreateItems0();
		CreateItems1();
	}
}
