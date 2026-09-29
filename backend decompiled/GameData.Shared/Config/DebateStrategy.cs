using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Utilities;

namespace Config;

[Serializable]
public class DebateStrategy : ConfigData<DebateStrategyItem, short>
{
	public static DebateStrategy Instance = new DebateStrategy();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "LifeSkillType", "Desc", "StyleDesc", "PawnEffectDesc", "NoTargetTip", "DebateRecord", "EffectList", "TargetList", "TargetRestrict",
		"EarlyLimits", "MidLimits", "LateLimits", "TemplateId", "Level", "Image", "UsedCost", "EarlyLimitParams", "MidLimitParams", "LateLimitParams"
	};

	internal override int ToInt(short value)
	{
		return value;
	}

	internal override short ToTemplateId(int value)
	{
		return (short)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new DebateStrategyItem(0, LocalStringManager.GetConfig("DebateStrategy_language", "Name_0"), 1, 0, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_0"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_0"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_0"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_0"), "LifeSkillCombatCard_Chahua_0", EDebateStrategyMarkType.Attach, 1, isOneTime: false, 20, EDebateStrategyTriggerType.Invalid, new List<IntPair>
		{
			new IntPair(0, -30)
		}, new List<short[]> { new short[3] { 3, 1, 1 } }, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, null, null, null, null, null, null));
		_dataArray.Add(new DebateStrategyItem(1, LocalStringManager.GetConfig("DebateStrategy_language", "Name_1"), 2, 0, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_1"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_1"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_1"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_1"), "LifeSkillCombatCard_Chahua_0", EDebateStrategyMarkType.Attach, 2, isOneTime: false, 21, EDebateStrategyTriggerType.Invalid, new List<IntPair>
		{
			new IntPair(0, -25)
		}, new List<short[]> { new short[3] { 3, 1, 3 } }, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.TargetCountGreater }, new List<int> { 2 }, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.TargetCountGreater }, new List<int> { 1 }, null, null));
		_dataArray.Add(new DebateStrategyItem(2, LocalStringManager.GetConfig("DebateStrategy_language", "Name_2"), 3, 0, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_2"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_2"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_2"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_2"), "LifeSkillCombatCard_Chahua_0", EDebateStrategyMarkType.Attach, 3, isOneTime: false, 22, EDebateStrategyTriggerType.Invalid, new List<IntPair>
		{
			new IntPair(0, -20)
		}, new List<short[]> { new short[3] { 2, 1, 6 } }, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.TargetCountGreater }, new List<int> { 5 }, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.TargetCountGreater }, new List<int> { 2 }, null, null));
		_dataArray.Add(new DebateStrategyItem(3, LocalStringManager.GetConfig("DebateStrategy_language", "Name_3"), 1, 1, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_3"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_3"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_3"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_3"), "LifeSkillCombatCard_Chahua_1", EDebateStrategyMarkType.Other, 2, isOneTime: false, 23, EDebateStrategyTriggerType.Instant, new List<IntPair>
		{
			new IntPair(1, 1)
		}, new List<short[]>
		{
			new short[3] { 8, 1, 1 },
			new short[3] { 9, 1, 1 }
		}, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.SelfBasesGreater }, new List<int> { 15 }, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.SelfBasesGreater }, new List<int> { 10 }, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.SelfBasesGreater }, new List<int> { 5 }));
		_dataArray.Add(new DebateStrategyItem(4, LocalStringManager.GetConfig("DebateStrategy_language", "Name_4"), 2, 1, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_4"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_4"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_4"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_4"), "LifeSkillCombatCard_Chahua_1", EDebateStrategyMarkType.Affect, 1, isOneTime: false, 24, EDebateStrategyTriggerType.Instant, new List<IntPair>
		{
			new IntPair(2, 1)
		}, new List<short[]>
		{
			new short[3] { 1, 1, 1 },
			new short[3] { 1, 1, 1 }
		}, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, null, null, null, null, null, null));
		_dataArray.Add(new DebateStrategyItem(5, LocalStringManager.GetConfig("DebateStrategy_language", "Name_5"), 3, 1, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_5"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_5"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_5"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_5"), "LifeSkillCombatCard_Chahua_1", EDebateStrategyMarkType.Affect, 3, isOneTime: false, 25, EDebateStrategyTriggerType.Instant, new List<IntPair>
		{
			new IntPair(3, 1)
		}, new List<short[]>
		{
			new short[3] { 1, 1, 1 },
			new short[3] { 6, 1, 1 }
		}, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, null, null, null, null, null, null));
		_dataArray.Add(new DebateStrategyItem(6, LocalStringManager.GetConfig("DebateStrategy_language", "Name_6"), 1, 2, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_6"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_6"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_6"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_6"), "LifeSkillCombatCard_Chahua_2", EDebateStrategyMarkType.Attach, 1, isOneTime: false, 26, EDebateStrategyTriggerType.PawnDamage, new List<IntPair>
		{
			new IntPair(4, 1)
		}, new List<short[]> { new short[3] { 1, 1, 1 } }, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, null, null, null, null, null, null));
		_dataArray.Add(new DebateStrategyItem(7, LocalStringManager.GetConfig("DebateStrategy_language", "Name_7"), 2, 2, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_7"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_7"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_7"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_7"), "LifeSkillCombatCard_Chahua_2", EDebateStrategyMarkType.Attach, 2, isOneTime: false, 27, EDebateStrategyTriggerType.ConflictWin, new List<IntPair>
		{
			new IntPair(5, 1)
		}, new List<short[]> { new short[3] { 1, 1, 2 } }, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.TargetCountGreater }, new List<int> { 1 }, null, null, null, null));
		_dataArray.Add(new DebateStrategyItem(8, LocalStringManager.GetConfig("DebateStrategy_language", "Name_8"), 3, 2, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_8"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_8"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_8"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_8"), "LifeSkillCombatCard_Chahua_2", EDebateStrategyMarkType.Attach, 3, isOneTime: false, 19, EDebateStrategyTriggerType.Invalid, new List<IntPair>
		{
			new IntPair(6, 50)
		}, new List<short[]> { new short[3] { 1, 1, 3 } }, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.TargetCountGreater }, new List<int> { 2 }, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.TargetCountGreater }, new List<int> { 1 }, null, null));
		_dataArray.Add(new DebateStrategyItem(9, LocalStringManager.GetConfig("DebateStrategy_language", "Name_9"), 1, 3, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_9"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_9"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_9"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_9"), "LifeSkillCombatCard_Chahua_3", EDebateStrategyMarkType.Attach, 1, isOneTime: false, 29, EDebateStrategyTriggerType.Invalid, new List<IntPair>
		{
			new IntPair(0, 30)
		}, new List<short[]> { new short[3] { 1, 1, 1 } }, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, null, null, null, null, null, null));
		_dataArray.Add(new DebateStrategyItem(10, LocalStringManager.GetConfig("DebateStrategy_language", "Name_10"), 2, 3, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_10"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_10"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_10"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_10"), "LifeSkillCombatCard_Chahua_3", EDebateStrategyMarkType.Attach, 2, isOneTime: false, 30, EDebateStrategyTriggerType.Invalid, new List<IntPair>
		{
			new IntPair(0, 25)
		}, new List<short[]> { new short[3] { 1, 1, 3 } }, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.TargetCountGreater }, new List<int> { 2 }, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.TargetCountGreater }, new List<int> { 1 }, null, null));
		_dataArray.Add(new DebateStrategyItem(11, LocalStringManager.GetConfig("DebateStrategy_language", "Name_11"), 3, 3, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_11"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_11"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_11"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_11"), "LifeSkillCombatCard_Chahua_3", EDebateStrategyMarkType.Attach, 3, isOneTime: false, 31, EDebateStrategyTriggerType.Invalid, new List<IntPair>
		{
			new IntPair(0, 20)
		}, new List<short[]> { new short[3] { 0, 1, 6 } }, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.TargetCountGreater }, new List<int> { 5 }, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.TargetCountGreater }, new List<int> { 2 }, null, null));
		_dataArray.Add(new DebateStrategyItem(12, LocalStringManager.GetConfig("DebateStrategy_language", "Name_12"), 1, 4, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_12"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_12"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_12"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_12"), "LifeSkillCombatCard_Chahua_4", EDebateStrategyMarkType.Other, 1, isOneTime: false, 32, EDebateStrategyTriggerType.Instant, new List<IntPair>
		{
			new IntPair(7, 1)
		}, new List<short[]>(), 15, 1, useBeforeMakeMove: true, avoidCheckMate: false, new List<EDebateStrategyAiCheckType>
		{
			EDebateStrategyAiCheckType.OpponentOwnedCardCountGreater,
			EDebateStrategyAiCheckType.SelfCanUseCardCountGreater
		}, new List<int> { 0, 3 }, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.OpponentOwnedCardCountGreater }, new List<int> { 0 }, null, null));
		_dataArray.Add(new DebateStrategyItem(13, LocalStringManager.GetConfig("DebateStrategy_language", "Name_13"), 2, 4, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_13"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_13"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_13"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_13"), "LifeSkillCombatCard_Chahua_4", EDebateStrategyMarkType.Attach, 2, isOneTime: false, 33, EDebateStrategyTriggerType.Invalid, new List<IntPair>
		{
			new IntPair(8, 1)
		}, new List<short[]> { new short[3] { 5, 1, 3 } }, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, null, null, null, null, null, null));
		_dataArray.Add(new DebateStrategyItem(14, LocalStringManager.GetConfig("DebateStrategy_language", "Name_14"), 3, 4, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_14"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_14"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_14"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_14"), "LifeSkillCombatCard_Chahua_4", EDebateStrategyMarkType.Affect, 3, isOneTime: false, 34, EDebateStrategyTriggerType.Instant, new List<IntPair>
		{
			new IntPair(3, 1)
		}, new List<short[]>
		{
			new short[3] { 3, 1, 1 },
			new short[3] { 7, 1, 1 }
		}, -1, 1, useBeforeMakeMove: false, avoidCheckMate: true, null, null, null, null, null, null));
		_dataArray.Add(new DebateStrategyItem(15, LocalStringManager.GetConfig("DebateStrategy_language", "Name_15"), 1, 5, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_15"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_15"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_15"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_15"), "LifeSkillCombatCard_Chahua_5", EDebateStrategyMarkType.Attach, 0, isOneTime: false, 35, EDebateStrategyTriggerType.RoundStart, new List<IntPair>
		{
			new IntPair(12, -10)
		}, new List<short[]> { new short[3] { 3, 1, 1 } }, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, null, null, null, null, null, null));
		_dataArray.Add(new DebateStrategyItem(16, LocalStringManager.GetConfig("DebateStrategy_language", "Name_16"), 2, 5, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_16"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_16"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_16"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_16"), "LifeSkillCombatCard_Chahua_5", EDebateStrategyMarkType.Attach, 0, isOneTime: false, 36, EDebateStrategyTriggerType.RoundStart, new List<IntPair>
		{
			new IntPair(13, -1)
		}, new List<short[]> { new short[3] { 3, 1, 1 } }, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, null, null, null, null, null, null));
		_dataArray.Add(new DebateStrategyItem(17, LocalStringManager.GetConfig("DebateStrategy_language", "Name_17"), 3, 5, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_17"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_17"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_17"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_17"), "LifeSkillCombatCard_Chahua_5", EDebateStrategyMarkType.Attach, 3, isOneTime: false, 37, EDebateStrategyTriggerType.PawnDamage, new List<IntPair>
		{
			new IntPair(16, 1)
		}, new List<short[]> { new short[3] { 1, 1, 2 } }, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.TargetCountGreater }, new List<int> { 1 }, null, null, null, null));
		_dataArray.Add(new DebateStrategyItem(18, LocalStringManager.GetConfig("DebateStrategy_language", "Name_18"), 1, 6, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_18"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_18"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_18"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_18"), "LifeSkillCombatCard_Chahua_6", EDebateStrategyMarkType.Attach, 1, isOneTime: true, 38, EDebateStrategyTriggerType.ConflictWin, new List<IntPair>
		{
			new IntPair(17, 1)
		}, new List<short[]> { new short[3] { 1, 1, 1 } }, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, null, null, null, null, null, null));
		_dataArray.Add(new DebateStrategyItem(19, LocalStringManager.GetConfig("DebateStrategy_language", "Name_19"), 2, 6, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_19"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_19"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_19"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_19"), "LifeSkillCombatCard_Chahua_6", EDebateStrategyMarkType.Attach, 1, isOneTime: true, 39, EDebateStrategyTriggerType.ConflictLose, new List<IntPair>
		{
			new IntPair(18, 1)
		}, new List<short[]> { new short[3] { 1, 1, 1 } }, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, null, null, null, null, null, null));
		_dataArray.Add(new DebateStrategyItem(20, LocalStringManager.GetConfig("DebateStrategy_language", "Name_20"), 3, 6, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_20"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_20"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_20"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_20"), "LifeSkillCombatCard_Chahua_6", EDebateStrategyMarkType.Attach, 3, isOneTime: false, 40, EDebateStrategyTriggerType.PawnForward, new List<IntPair>
		{
			new IntPair(19, 20)
		}, new List<short[]> { new short[3] { 1, 1, 3 } }, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.TargetCountGreater }, new List<int> { 2 }, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.TargetCountGreater }, new List<int> { 1 }, null, null));
		_dataArray.Add(new DebateStrategyItem(21, LocalStringManager.GetConfig("DebateStrategy_language", "Name_21"), 1, 7, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_21"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_21"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_21"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_21"), "LifeSkillCombatCard_Chahua_7", EDebateStrategyMarkType.Attach, 0, isOneTime: false, 41, EDebateStrategyTriggerType.RoundStart, new List<IntPair>
		{
			new IntPair(9, 10)
		}, new List<short[]> { new short[3] { 1, 1, 1 } }, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, null, null, null, null, null, null));
		_dataArray.Add(new DebateStrategyItem(22, LocalStringManager.GetConfig("DebateStrategy_language", "Name_22"), 2, 7, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_22"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_22"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_22"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_22"), "LifeSkillCombatCard_Chahua_7", EDebateStrategyMarkType.Attach, 0, isOneTime: false, 42, EDebateStrategyTriggerType.RoundStart, new List<IntPair>
		{
			new IntPair(10, 1)
		}, new List<short[]> { new short[3] { 1, 1, 1 } }, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, null, null, null, null, null, null));
		_dataArray.Add(new DebateStrategyItem(23, LocalStringManager.GetConfig("DebateStrategy_language", "Name_23"), 3, 7, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_23"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_23"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_23"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_23"), "LifeSkillCombatCard_Chahua_7", EDebateStrategyMarkType.Affect, 2, isOneTime: false, 43, EDebateStrategyTriggerType.Instant, new List<IntPair>
		{
			new IntPair(5, 1)
		}, new List<short[]> { new short[3] { 1, 1, 3 } }, 11, 1, useBeforeMakeMove: false, avoidCheckMate: false, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.TargetCountGreater }, new List<int> { 2 }, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.TargetCountGreater }, new List<int> { 1 }, null, null));
		_dataArray.Add(new DebateStrategyItem(24, LocalStringManager.GetConfig("DebateStrategy_language", "Name_24"), 1, 8, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_24"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_24"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_24"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_24"), "LifeSkillCombatCard_Chahua_8", EDebateStrategyMarkType.Affect, 1, isOneTime: false, 44, EDebateStrategyTriggerType.Instant, new List<IntPair>
		{
			new IntPair(20, 1)
		}, new List<short[]> { new short[3] { 3, 1, 3 } }, 12, 1, useBeforeMakeMove: true, avoidCheckMate: false, null, null, null, null, null, null));
		_dataArray.Add(new DebateStrategyItem(25, LocalStringManager.GetConfig("DebateStrategy_language", "Name_25"), 2, 8, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_25"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_25"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_25"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_25"), "LifeSkillCombatCard_Chahua_8", EDebateStrategyMarkType.Affect, 3, isOneTime: false, 45, EDebateStrategyTriggerType.Instant, new List<IntPair>
		{
			new IntPair(21, 1),
			new IntPair(15, 1)
		}, new List<short[]> { new short[3] { 5, 1, 2 } }, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, new List<EDebateStrategyAiCheckType>
		{
			EDebateStrategyAiCheckType.OpponentGamePointGreater,
			EDebateStrategyAiCheckType.SelfNotCheckMate
		}, new List<int> { 0, 0 }, new List<EDebateStrategyAiCheckType>
		{
			EDebateStrategyAiCheckType.OpponentGamePointGreater,
			EDebateStrategyAiCheckType.SelfNotCheckMate
		}, new List<int> { 0, 0 }, new List<EDebateStrategyAiCheckType>
		{
			EDebateStrategyAiCheckType.OpponentGamePointGreater,
			EDebateStrategyAiCheckType.SelfNotCheckMate
		}, new List<int> { 0, 0 }));
		_dataArray.Add(new DebateStrategyItem(26, LocalStringManager.GetConfig("DebateStrategy_language", "Name_26"), 3, 8, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_26"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_26"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_26"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_26"), "LifeSkillCombatCard_Chahua_8", EDebateStrategyMarkType.Attach, 3, isOneTime: false, 47, EDebateStrategyTriggerType.PawnDamage, new List<IntPair>
		{
			new IntPair(11, 1)
		}, new List<short[]> { new short[3] { 1, 1, 3 } }, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, new List<EDebateStrategyAiCheckType>
		{
			EDebateStrategyAiCheckType.SelfGamePointSmaller,
			EDebateStrategyAiCheckType.TargetCountGreater
		}, new List<int> { 6, 2 }, new List<EDebateStrategyAiCheckType>
		{
			EDebateStrategyAiCheckType.SelfGamePointSmaller,
			EDebateStrategyAiCheckType.TargetCountGreater
		}, new List<int> { 6, 1 }, null, null));
		_dataArray.Add(new DebateStrategyItem(27, LocalStringManager.GetConfig("DebateStrategy_language", "Name_27"), 1, 9, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_27"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_27"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_27"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_27"), "LifeSkillCombatCard_Chahua_9", EDebateStrategyMarkType.Attach, 1, isOneTime: false, -1, EDebateStrategyTriggerType.Invalid, new List<IntPair>
		{
			new IntPair(23, 1)
		}, new List<short[]> { new short[3] { 3, 1, 1 } }, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, null, null, null, null, null, null));
		_dataArray.Add(new DebateStrategyItem(28, LocalStringManager.GetConfig("DebateStrategy_language", "Name_28"), 2, 9, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_28"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_28"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_28"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_28"), "LifeSkillCombatCard_Chahua_9", EDebateStrategyMarkType.Attach, 2, isOneTime: false, 48, EDebateStrategyTriggerType.PawnDead, new List<IntPair>
		{
			new IntPair(22, 1)
		}, new List<short[]>
		{
			new short[3] { 5, 1, 1 },
			new short[3] { 5, 1, 1 }
		}, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, null, null, null, null, null, null));
		_dataArray.Add(new DebateStrategyItem(29, LocalStringManager.GetConfig("DebateStrategy_language", "Name_29"), 3, 9, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_29"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_29"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_29"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_29"), "LifeSkillCombatCard_Chahua_9", EDebateStrategyMarkType.Attach, 3, isOneTime: false, 49, EDebateStrategyTriggerType.PawnDamage, new List<IntPair>
		{
			new IntPair(11, -1)
		}, new List<short[]> { new short[3] { 3, 1, 3 } }, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, null, null, null, null, null, null));
		_dataArray.Add(new DebateStrategyItem(30, LocalStringManager.GetConfig("DebateStrategy_language", "Name_30"), 1, 10, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_30"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_30"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_30"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_30"), "LifeSkillCombatCard_Chahua_10", EDebateStrategyMarkType.Attach, 2, isOneTime: false, 50, EDebateStrategyTriggerType.Invalid, new List<IntPair>
		{
			new IntPair(24, 20)
		}, new List<short[]> { new short[3] { 1, 1, 1 } }, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.TargetCountGreater }, new List<int> { 2 }, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.TargetCountGreater }, new List<int> { 1 }, null, null));
		_dataArray.Add(new DebateStrategyItem(31, LocalStringManager.GetConfig("DebateStrategy_language", "Name_31"), 2, 10, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_31"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_31"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_31"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_31"), "LifeSkillCombatCard_Chahua_10", EDebateStrategyMarkType.Attach, 2, isOneTime: false, 51, EDebateStrategyTriggerType.ConflictWin, new List<IntPair>
		{
			new IntPair(25, 1)
		}, new List<short[]> { new short[3] { 1, 1, 1 } }, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, null, null, null, null, null, null));
		_dataArray.Add(new DebateStrategyItem(32, LocalStringManager.GetConfig("DebateStrategy_language", "Name_32"), 3, 10, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_32"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_32"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_32"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_32"), "LifeSkillCombatCard_Chahua_10", EDebateStrategyMarkType.Attach, 3, isOneTime: false, 52, EDebateStrategyTriggerType.Invalid, new List<IntPair>
		{
			new IntPair(26, 1)
		}, new List<short[]> { new short[3] { 1, 1, 3 } }, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.TargetCountGreater }, new List<int> { 2 }, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.TargetCountGreater }, new List<int> { 1 }, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.TargetCountGreater }, new List<int> { 1 }));
		_dataArray.Add(new DebateStrategyItem(33, LocalStringManager.GetConfig("DebateStrategy_language", "Name_33"), 1, 11, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_33"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_33"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_33"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_33"), "LifeSkillCombatCard_Chahua_11", EDebateStrategyMarkType.Affect, 1, isOneTime: false, 53, EDebateStrategyTriggerType.Instant, new List<IntPair>
		{
			new IntPair(27, 1)
		}, new List<short[]> { new short[3] { 5, 1, 1 } }, -1, 1, useBeforeMakeMove: false, avoidCheckMate: true, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.OpponentTargetCountGreater }, new List<int> { 0 }, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.OpponentTargetCountGreater }, new List<int> { 0 }, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.OpponentTargetCountGreater }, new List<int> { 0 }));
		_dataArray.Add(new DebateStrategyItem(34, LocalStringManager.GetConfig("DebateStrategy_language", "Name_34"), 2, 11, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_34"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_34"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_34"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_34"), "LifeSkillCombatCard_Chahua_11", EDebateStrategyMarkType.Attach, 1, isOneTime: false, 19, EDebateStrategyTriggerType.Invalid, new List<IntPair>
		{
			new IntPair(28, 1)
		}, new List<short[]> { new short[3] { 4, 1, 3 } }, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.TargetCountGreater }, new List<int> { 2 }, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.TargetCountGreater }, new List<int> { 1 }, null, null));
		_dataArray.Add(new DebateStrategyItem(35, LocalStringManager.GetConfig("DebateStrategy_language", "Name_35"), 3, 11, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_35"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_35"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_35"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_35"), "LifeSkillCombatCard_Chahua_11", EDebateStrategyMarkType.Attach, 3, isOneTime: false, 56, EDebateStrategyTriggerType.PawnDamage, new List<IntPair>
		{
			new IntPair(14, 3)
		}, new List<short[]> { new short[3] { 5, 1, 1 } }, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, new List<EDebateStrategyAiCheckType>
		{
			EDebateStrategyAiCheckType.OpponentGamePointNotGreaterThanSelf,
			EDebateStrategyAiCheckType.SelfGamePointGreater
		}, new List<int> { 0, 3 }, new List<EDebateStrategyAiCheckType>
		{
			EDebateStrategyAiCheckType.OpponentGamePointNotGreaterThanSelf,
			EDebateStrategyAiCheckType.SelfGamePointGreater
		}, new List<int> { 0, 3 }, new List<EDebateStrategyAiCheckType>
		{
			EDebateStrategyAiCheckType.OpponentGamePointNotGreaterThanSelf,
			EDebateStrategyAiCheckType.SelfGamePointGreater
		}, new List<int> { 0, 3 }));
		_dataArray.Add(new DebateStrategyItem(36, LocalStringManager.GetConfig("DebateStrategy_language", "Name_36"), 1, 12, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_36"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_36"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_36"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_36"), "LifeSkillCombatCard_Chahua_12", EDebateStrategyMarkType.Affect, 1, isOneTime: false, 57, EDebateStrategyTriggerType.Instant, new List<IntPair>
		{
			new IntPair(29, 3)
		}, new List<short[]> { new short[3] { 5, 1, 1 } }, 11, -3, useBeforeMakeMove: false, avoidCheckMate: true, null, null, null, null, null, null));
		_dataArray.Add(new DebateStrategyItem(37, LocalStringManager.GetConfig("DebateStrategy_language", "Name_37"), 2, 12, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_37"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_37"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_37"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_37"), "LifeSkillCombatCard_Chahua_12", EDebateStrategyMarkType.Other, 0, isOneTime: false, 58, EDebateStrategyTriggerType.Instant, new List<IntPair>
		{
			new IntPair(30, 1)
		}, new List<short[]> { new short[3] { 10, 1, 3 } }, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.SelfStrategyPointSmaller }, new List<int> { 3 }, null, null, null, null));
		_dataArray.Add(new DebateStrategyItem(38, LocalStringManager.GetConfig("DebateStrategy_language", "Name_38"), 3, 12, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_38"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_38"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_38"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_38"), "LifeSkillCombatCard_Chahua_12", EDebateStrategyMarkType.Other, 2, isOneTime: false, 59, EDebateStrategyTriggerType.Instant, new List<IntPair>
		{
			new IntPair(31, 3)
		}, new List<short[]>(), 16, 1, useBeforeMakeMove: true, avoidCheckMate: false, new List<EDebateStrategyAiCheckType>
		{
			EDebateStrategyAiCheckType.OpponentUsedCardCountGreater,
			EDebateStrategyAiCheckType.SelfCanUseCardCountGreater
		}, new List<int> { 2, 1 }, new List<EDebateStrategyAiCheckType>
		{
			EDebateStrategyAiCheckType.OpponentUsedCardCountGreater,
			EDebateStrategyAiCheckType.SelfCanUseCardCountGreater
		}, new List<int> { 1, 3 }, null, null));
		_dataArray.Add(new DebateStrategyItem(39, LocalStringManager.GetConfig("DebateStrategy_language", "Name_39"), 1, 13, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_39"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_39"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_39"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_39"), "LifeSkillCombatCard_Chahua_13", EDebateStrategyMarkType.Affect, 1, isOneTime: false, 60, EDebateStrategyTriggerType.Instant, new List<IntPair>
		{
			new IntPair(32, 1)
		}, new List<short[]> { new short[3] { 5, 1, 3 } }, 13, 1, useBeforeMakeMove: true, avoidCheckMate: false, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.TargetCountGreater }, new List<int> { 2 }, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.TargetCountGreater }, new List<int> { 1 }, null, null));
		_dataArray.Add(new DebateStrategyItem(40, LocalStringManager.GetConfig("DebateStrategy_language", "Name_40"), 2, 13, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_40"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_40"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_40"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_40"), "LifeSkillCombatCard_Chahua_13", EDebateStrategyMarkType.Attach, 3, isOneTime: false, 61, EDebateStrategyTriggerType.ConflictStart, new List<IntPair>
		{
			new IntPair(33, 1)
		}, new List<short[]> { new short[3] { 5, 1, 1 } }, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, null, null, null, null, null, null));
		_dataArray.Add(new DebateStrategyItem(41, LocalStringManager.GetConfig("DebateStrategy_language", "Name_41"), 3, 13, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_41"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_41"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_41"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_41"), "LifeSkillCombatCard_Chahua_13", EDebateStrategyMarkType.Attach, 3, isOneTime: false, -1, EDebateStrategyTriggerType.PawnActing, new List<IntPair>
		{
			new IntPair(34, 1)
		}, new List<short[]> { new short[3] { 3, 1, 3 } }, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.TargetCountGreater }, new List<int> { 2 }, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.TargetCountGreater }, new List<int> { 1 }, null, null));
		_dataArray.Add(new DebateStrategyItem(42, LocalStringManager.GetConfig("DebateStrategy_language", "Name_42"), 1, 14, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_42"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_42"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_42"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_42"), "LifeSkillCombatCard_Chahua_14", EDebateStrategyMarkType.Attach, 1, isOneTime: false, 63, EDebateStrategyTriggerType.Invalid, new List<IntPair>
		{
			new IntPair(35, 1)
		}, new List<short[]> { new short[3] { 4, 1, 3 } }, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, null, null, null, null, null, null));
		_dataArray.Add(new DebateStrategyItem(43, LocalStringManager.GetConfig("DebateStrategy_language", "Name_43"), 2, 14, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_43"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_43"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_43"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_43"), "LifeSkillCombatCard_Chahua_14", EDebateStrategyMarkType.Affect, 3, isOneTime: false, 64, EDebateStrategyTriggerType.Instant, new List<IntPair>
		{
			new IntPair(36, 1)
		}, new List<short[]>
		{
			new short[3] { 5, 1, 1 },
			new short[3] { 5, 1, 1 }
		}, -1, 1, useBeforeMakeMove: false, avoidCheckMate: true, null, null, null, null, null, null));
		_dataArray.Add(new DebateStrategyItem(44, LocalStringManager.GetConfig("DebateStrategy_language", "Name_44"), 3, 14, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_44"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_44"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_44"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_44"), "LifeSkillCombatCard_Chahua_14", EDebateStrategyMarkType.Affect, 3, isOneTime: false, 65, EDebateStrategyTriggerType.Instant, new List<IntPair>
		{
			new IntPair(37, 3)
		}, new List<short[]> { new short[3] { 5, 1, 1 } }, 11, 0, useBeforeMakeMove: false, avoidCheckMate: true, null, null, null, null, null, null));
		_dataArray.Add(new DebateStrategyItem(45, LocalStringManager.GetConfig("DebateStrategy_language", "Name_45"), 1, 15, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_45"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_45"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_45"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_45"), "LifeSkillCombatCard_Chahua_15", EDebateStrategyMarkType.Affect, 2, isOneTime: false, 66, EDebateStrategyTriggerType.Instant, new List<IntPair>
		{
			new IntPair(38, 1)
		}, new List<short[]> { new short[3] { 5, 1, 1 } }, 14, 1, useBeforeMakeMove: false, avoidCheckMate: false, null, null, null, null, null, null));
		_dataArray.Add(new DebateStrategyItem(46, LocalStringManager.GetConfig("DebateStrategy_language", "Name_46"), 2, 15, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_46"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_46"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_46"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_46"), "LifeSkillCombatCard_Chahua_15", EDebateStrategyMarkType.Affect, 3, isOneTime: false, 67, EDebateStrategyTriggerType.Instant, new List<IntPair>
		{
			new IntPair(39, 1)
		}, new List<short[]>
		{
			new short[3] { 5, 1, 1 },
			new short[3] { 5, 1, 1 }
		}, -1, 1, useBeforeMakeMove: false, avoidCheckMate: false, null, null, null, null, null, null));
		_dataArray.Add(new DebateStrategyItem(47, LocalStringManager.GetConfig("DebateStrategy_language", "Name_47"), 3, 15, LocalStringManager.GetConfig("DebateStrategy_language", "Desc_47"), LocalStringManager.GetConfig("DebateStrategy_language", "StyleDesc_47"), LocalStringManager.GetConfig("DebateStrategy_language", "PawnEffectDesc_47"), LocalStringManager.GetConfig("DebateStrategy_language", "NoTargetTip_47"), "LifeSkillCombatCard_Chahua_15", EDebateStrategyMarkType.Other, 1, isOneTime: false, 68, EDebateStrategyTriggerType.Instant, new List<IntPair>
		{
			new IntPair(40, 1)
		}, new List<short[]>(), 17, 1, useBeforeMakeMove: false, avoidCheckMate: false, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.SelfCanUseCardCountSmaller }, new List<int> { 2 }, new List<EDebateStrategyAiCheckType> { EDebateStrategyAiCheckType.SelfCanUseCardCountSmaller }, new List<int> { 2 }, null, null));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<DebateStrategyItem>(48);
		CreateItems0();
	}
}
