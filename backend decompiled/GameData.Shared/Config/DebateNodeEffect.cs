using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Utilities;

namespace Config;

[Serializable]
public class DebateNodeEffect : ConfigData<DebateNodeEffectItem, short>
{
	public static class DefKey
	{
		public const short Just = 0;

		public const short Kind = 1;

		public const short Even = 2;

		public const short Rebel = 3;

		public const short Egoistic = 4;
	}

	public static class DefValue
	{
		public static DebateNodeEffectItem Just => Instance[(short)0];

		public static DebateNodeEffectItem Kind => Instance[(short)1];

		public static DebateNodeEffectItem Even => Instance[(short)2];

		public static DebateNodeEffectItem Rebel => Instance[(short)3];

		public static DebateNodeEffectItem Egoistic => Instance[(short)4];
	}

	public static DebateNodeEffect Instance = new DebateNodeEffect();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "Desc", "BubbleContent", "BehaviorType", "DebateRecord", "InstantEffectList", "TriggerEffectList", "SpecialEffectList", "RemoveType", "TemplateId",
		"LoopSound", "TriggerSound", "ExtraTriggerSound"
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
		_dataArray.Add(new DebateNodeEffectItem(0, LocalStringManager.GetConfig("DebateNodeEffect_language", "Name_0"), LocalStringManager.GetConfig("DebateNodeEffect_language", "Desc_0"), LocalStringManager.GetConfig("DebateNodeEffect_language", "BubbleContent_0"), 0, 7, new List<IntPair>
		{
			new IntPair(20, 1),
			new IntPair(32, 1)
		}, new List<IntPair>
		{
			new IntPair(20, 1),
			new IntPair(32, 1)
		}, new List<IntPair>
		{
			new IntPair(20, 1),
			new IntPair(32, 1),
			new IntPair(44, 1)
		}, 3, 3, new List<EDebateNodeEffectRemoveType> { EDebateNodeEffectRemoveType.Special }, "art_GridLoop_1", "art_GridSkill_1", null));
		_dataArray.Add(new DebateNodeEffectItem(1, LocalStringManager.GetConfig("DebateNodeEffect_language", "Name_1"), LocalStringManager.GetConfig("DebateNodeEffect_language", "Desc_1"), LocalStringManager.GetConfig("DebateNodeEffect_language", "BubbleContent_1"), 1, 9, new List<IntPair>
		{
			new IntPair(9, 20)
		}, new List<IntPair>
		{
			new IntPair(9, 20)
		}, new List<IntPair>
		{
			new IntPair(23, 1)
		}, 3, 3, new List<EDebateNodeEffectRemoveType>
		{
			EDebateNodeEffectRemoveType.Instant,
			EDebateNodeEffectRemoveType.Trigger
		}, "art_GridLoop_2", "art_GridSkill_2", "art_add"));
		_dataArray.Add(new DebateNodeEffectItem(2, LocalStringManager.GetConfig("DebateNodeEffect_language", "Name_2"), LocalStringManager.GetConfig("DebateNodeEffect_language", "Desc_2"), LocalStringManager.GetConfig("DebateNodeEffect_language", "BubbleContent_2"), 2, 10, new List<IntPair>(), new List<IntPair>(), new List<IntPair>
		{
			new IntPair(41, 1)
		}, 3, 3, new List<EDebateNodeEffectRemoveType> { EDebateNodeEffectRemoveType.Special }, "art_GridLoop_3", "art_GridSkill_3", null));
		_dataArray.Add(new DebateNodeEffectItem(3, LocalStringManager.GetConfig("DebateNodeEffect_language", "Name_3"), LocalStringManager.GetConfig("DebateNodeEffect_language", "Desc_3"), LocalStringManager.GetConfig("DebateNodeEffect_language", "BubbleContent_3"), 3, 11, new List<IntPair>
		{
			new IntPair(42, 1)
		}, new List<IntPair>
		{
			new IntPair(42, 1)
		}, new List<IntPair>(), 3, 3, new List<EDebateNodeEffectRemoveType>
		{
			EDebateNodeEffectRemoveType.Instant,
			EDebateNodeEffectRemoveType.Trigger
		}, "art_GridLoop_4", "art_GridSkill_4", null));
		_dataArray.Add(new DebateNodeEffectItem(4, LocalStringManager.GetConfig("DebateNodeEffect_language", "Name_4"), LocalStringManager.GetConfig("DebateNodeEffect_language", "Desc_4"), LocalStringManager.GetConfig("DebateNodeEffect_language", "BubbleContent_4"), 4, 12, new List<IntPair>(), new List<IntPair>
		{
			new IntPair(43, 1)
		}, new List<IntPair>(), 3, 3, new List<EDebateNodeEffectRemoveType> { EDebateNodeEffectRemoveType.Trigger }, "art_GridLoop_5", "art_GridSkill_5", "art_LightningHurt"));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<DebateNodeEffectItem>(5);
		CreateItems0();
	}
}
