using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SkillBreakGridType : ConfigData<SkillBreakGridTypeItem, sbyte>
{
	public static class DefKey
	{
		public const sbyte StartPoint = 0;

		public const sbyte EndPoint = 1;

		public const sbyte Bonus = 2;

		public const sbyte Normal = 3;

		public const sbyte Portal = 21;

		public const sbyte PrevGood = 22;

		public const sbyte PrevBad = 23;
	}

	public static class DefValue
	{
		public static SkillBreakGridTypeItem StartPoint => Instance[(sbyte)0];

		public static SkillBreakGridTypeItem EndPoint => Instance[(sbyte)1];

		public static SkillBreakGridTypeItem Bonus => Instance[(sbyte)2];

		public static SkillBreakGridTypeItem Normal => Instance[(sbyte)3];

		public static SkillBreakGridTypeItem Portal => Instance[(sbyte)21];

		public static SkillBreakGridTypeItem PrevGood => Instance[(sbyte)22];

		public static SkillBreakGridTypeItem PrevBad => Instance[(sbyte)23];
	}

	public static SkillBreakGridType Instance = new SkillBreakGridType();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "TemplateId", "Type", "FontColor" };

	internal override int ToInt(sbyte value)
	{
		return value;
	}

	internal override sbyte ToTemplateId(int value)
	{
		return (sbyte)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new SkillBreakGridTypeItem(0, LocalStringManager.GetConfig("SkillBreakGridType_language", "Name_0"), ESkillBreakGridTypeType.StartPoint, LocalStringManager.GetConfig("SkillBreakGridType_language", "Desc_0"), "darkbrown", 0, 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 1, nextStepCanJumpToSame: false, neighborFailedToCanSelect: false, randomNeighborNormalConvertToSameGrid: false, allNeighborNormalConvertToSpecialGrid: false, allNeighborSpecialConvertToNormalGrid: false, clearNeighborMaxPower: false, ignoreEffectAddMaxPower: true, 0, 0, 0, 0, 0, 0));
		_dataArray.Add(new SkillBreakGridTypeItem(1, LocalStringManager.GetConfig("SkillBreakGridType_language", "Name_1"), ESkillBreakGridTypeType.EndPoint, LocalStringManager.GetConfig("SkillBreakGridType_language", "Desc_1"), "darkbrown", 0, 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 1, nextStepCanJumpToSame: false, neighborFailedToCanSelect: false, randomNeighborNormalConvertToSameGrid: false, allNeighborNormalConvertToSpecialGrid: false, allNeighborSpecialConvertToNormalGrid: false, clearNeighborMaxPower: false, ignoreEffectAddMaxPower: true, 0, 0, 0, 0, 0, 0));
		_dataArray.Add(new SkillBreakGridTypeItem(2, LocalStringManager.GetConfig("SkillBreakGridType_language", "Name_2"), ESkillBreakGridTypeType.Bonus, LocalStringManager.GetConfig("SkillBreakGridType_language", "Desc_2"), "yellow", 0, 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 1, nextStepCanJumpToSame: false, neighborFailedToCanSelect: false, randomNeighborNormalConvertToSameGrid: false, allNeighborNormalConvertToSpecialGrid: false, allNeighborSpecialConvertToNormalGrid: false, clearNeighborMaxPower: false, ignoreEffectAddMaxPower: true, 0, 0, 0, 0, 0, 0));
		_dataArray.Add(new SkillBreakGridTypeItem(3, LocalStringManager.GetConfig("SkillBreakGridType_language", "Name_3"), ESkillBreakGridTypeType.Normal, LocalStringManager.GetConfig("SkillBreakGridType_language", "Desc_3"), "lightgrey", 0, 1, 0, -1, 0, 0, 0, 0, 0, 0, 0, 1, nextStepCanJumpToSame: false, neighborFailedToCanSelect: false, randomNeighborNormalConvertToSameGrid: false, allNeighborNormalConvertToSpecialGrid: false, allNeighborSpecialConvertToNormalGrid: false, clearNeighborMaxPower: false, ignoreEffectAddMaxPower: false, 0, 0, 0, 0, 0, 0));
		_dataArray.Add(new SkillBreakGridTypeItem(4, LocalStringManager.GetConfig("SkillBreakGridType_language", "Name_4"), ESkillBreakGridTypeType.Special, LocalStringManager.GetConfig("SkillBreakGridType_language", "Desc_4"), "darkpurple", 0, 1, 0, -1, 0, 0, 30, 0, 0, 0, 0, 1, nextStepCanJumpToSame: false, neighborFailedToCanSelect: false, randomNeighborNormalConvertToSameGrid: false, allNeighborNormalConvertToSpecialGrid: false, allNeighborSpecialConvertToNormalGrid: false, clearNeighborMaxPower: false, ignoreEffectAddMaxPower: false, 0, 0, 0, 0, 1, 15));
		_dataArray.Add(new SkillBreakGridTypeItem(5, LocalStringManager.GetConfig("SkillBreakGridType_language", "Name_5"), ESkillBreakGridTypeType.Special, LocalStringManager.GetConfig("SkillBreakGridType_language", "Desc_5"), "darkpurple", 0, 1, 0, -1, 0, 0, 0, 0, 0, 0, 0, 2, nextStepCanJumpToSame: false, neighborFailedToCanSelect: false, randomNeighborNormalConvertToSameGrid: false, allNeighborNormalConvertToSpecialGrid: false, allNeighborSpecialConvertToNormalGrid: false, clearNeighborMaxPower: false, ignoreEffectAddMaxPower: false, 0, 0, 0, 0, 1, 3));
		_dataArray.Add(new SkillBreakGridTypeItem(6, LocalStringManager.GetConfig("SkillBreakGridType_language", "Name_6"), ESkillBreakGridTypeType.Special, LocalStringManager.GetConfig("SkillBreakGridType_language", "Desc_6"), "darkpurple", 0, 1, 0, -1, 0, 0, 0, 0, 0, 0, 0, 1, nextStepCanJumpToSame: false, neighborFailedToCanSelect: false, randomNeighborNormalConvertToSameGrid: false, allNeighborNormalConvertToSpecialGrid: true, allNeighborSpecialConvertToNormalGrid: false, clearNeighborMaxPower: false, ignoreEffectAddMaxPower: false, 0, 0, 0, 0, 1, 3));
		_dataArray.Add(new SkillBreakGridTypeItem(7, LocalStringManager.GetConfig("SkillBreakGridType_language", "Name_7"), ESkillBreakGridTypeType.Special, LocalStringManager.GetConfig("SkillBreakGridType_language", "Desc_7"), "darkpurple", 0, 1, 0, -1, -100, 60, 0, 0, 0, 0, 0, 1, nextStepCanJumpToSame: false, neighborFailedToCanSelect: false, randomNeighborNormalConvertToSameGrid: false, allNeighborNormalConvertToSpecialGrid: false, allNeighborSpecialConvertToNormalGrid: false, clearNeighborMaxPower: false, ignoreEffectAddMaxPower: false, 0, 0, 0, 0, 1, 15));
		_dataArray.Add(new SkillBreakGridTypeItem(8, LocalStringManager.GetConfig("SkillBreakGridType_language", "Name_8"), ESkillBreakGridTypeType.Special, LocalStringManager.GetConfig("SkillBreakGridType_language", "Desc_8"), "darkpurple", 0, 1, 0, -1, 0, 0, 0, 0, 0, 0, 100, 1, nextStepCanJumpToSame: false, neighborFailedToCanSelect: false, randomNeighborNormalConvertToSameGrid: false, allNeighborNormalConvertToSpecialGrid: false, allNeighborSpecialConvertToNormalGrid: false, clearNeighborMaxPower: false, ignoreEffectAddMaxPower: false, 0, 0, 0, 0, 1, 3));
		_dataArray.Add(new SkillBreakGridTypeItem(9, LocalStringManager.GetConfig("SkillBreakGridType_language", "Name_9"), ESkillBreakGridTypeType.Special, LocalStringManager.GetConfig("SkillBreakGridType_language", "Desc_9"), "darkpurple", 0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 1, nextStepCanJumpToSame: false, neighborFailedToCanSelect: false, randomNeighborNormalConvertToSameGrid: false, allNeighborNormalConvertToSpecialGrid: false, allNeighborSpecialConvertToNormalGrid: false, clearNeighborMaxPower: false, ignoreEffectAddMaxPower: false, 0, 0, 0, 0, 1, 3));
		_dataArray.Add(new SkillBreakGridTypeItem(10, LocalStringManager.GetConfig("SkillBreakGridType_language", "Name_10"), ESkillBreakGridTypeType.Special, LocalStringManager.GetConfig("SkillBreakGridType_language", "Desc_10"), "darkpurple", 0, 0, 0, -1, -30, 0, 0, 0, 0, 0, 0, 1, nextStepCanJumpToSame: false, neighborFailedToCanSelect: false, randomNeighborNormalConvertToSameGrid: true, allNeighborNormalConvertToSpecialGrid: false, allNeighborSpecialConvertToNormalGrid: false, clearNeighborMaxPower: false, ignoreEffectAddMaxPower: false, 0, 0, 0, 0, 1, 3));
		_dataArray.Add(new SkillBreakGridTypeItem(11, LocalStringManager.GetConfig("SkillBreakGridType_language", "Name_11"), ESkillBreakGridTypeType.Special, LocalStringManager.GetConfig("SkillBreakGridType_language", "Desc_11"), "darkpurple", 0, 1, 3, -1, -60, 0, 0, 0, 0, 0, 0, 1, nextStepCanJumpToSame: false, neighborFailedToCanSelect: false, randomNeighborNormalConvertToSameGrid: false, allNeighborNormalConvertToSpecialGrid: false, allNeighborSpecialConvertToNormalGrid: false, clearNeighborMaxPower: false, ignoreEffectAddMaxPower: false, 0, 0, 0, 0, 1, 3));
		_dataArray.Add(new SkillBreakGridTypeItem(12, LocalStringManager.GetConfig("SkillBreakGridType_language", "Name_12"), ESkillBreakGridTypeType.Special, LocalStringManager.GetConfig("SkillBreakGridType_language", "Desc_12"), "darkpurple", 0, 1, 0, -1, -60, 0, 0, 20, 0, 0, 0, 1, nextStepCanJumpToSame: false, neighborFailedToCanSelect: false, randomNeighborNormalConvertToSameGrid: false, allNeighborNormalConvertToSpecialGrid: false, allNeighborSpecialConvertToNormalGrid: false, clearNeighborMaxPower: false, ignoreEffectAddMaxPower: false, 0, 1, 0, 0, 1, 15));
		_dataArray.Add(new SkillBreakGridTypeItem(13, LocalStringManager.GetConfig("SkillBreakGridType_language", "Name_13"), ESkillBreakGridTypeType.Special, LocalStringManager.GetConfig("SkillBreakGridType_language", "Desc_13"), "darkpurple", 0, 1, 0, -1, 0, 0, -50, 0, 0, 0, 0, 1, nextStepCanJumpToSame: false, neighborFailedToCanSelect: true, randomNeighborNormalConvertToSameGrid: false, allNeighborNormalConvertToSpecialGrid: false, allNeighborSpecialConvertToNormalGrid: false, clearNeighborMaxPower: false, ignoreEffectAddMaxPower: false, 2, 0, 0, 0, 1, 15));
		_dataArray.Add(new SkillBreakGridTypeItem(14, LocalStringManager.GetConfig("SkillBreakGridType_language", "Name_14"), ESkillBreakGridTypeType.Special, LocalStringManager.GetConfig("SkillBreakGridType_language", "Desc_14"), "darkpurple", 10, 1, 0, -1, 0, 0, 0, 0, 0, 0, 0, 1, nextStepCanJumpToSame: false, neighborFailedToCanSelect: false, randomNeighborNormalConvertToSameGrid: false, allNeighborNormalConvertToSpecialGrid: false, allNeighborSpecialConvertToNormalGrid: false, clearNeighborMaxPower: false, ignoreEffectAddMaxPower: false, 0, 0, 0, 0, 1, 3));
		_dataArray.Add(new SkillBreakGridTypeItem(15, LocalStringManager.GetConfig("SkillBreakGridType_language", "Name_15"), ESkillBreakGridTypeType.Special, LocalStringManager.GetConfig("SkillBreakGridType_language", "Desc_15"), "darkpurple", 0, 1, 0, -1, 0, 0, 0, 0, 0, 0, 0, 1, nextStepCanJumpToSame: false, neighborFailedToCanSelect: false, randomNeighborNormalConvertToSameGrid: false, allNeighborNormalConvertToSpecialGrid: false, allNeighborSpecialConvertToNormalGrid: false, clearNeighborMaxPower: false, ignoreEffectAddMaxPower: false, 0, 0, 3, 0, 1, 3));
		_dataArray.Add(new SkillBreakGridTypeItem(16, LocalStringManager.GetConfig("SkillBreakGridType_language", "Name_16"), ESkillBreakGridTypeType.Special, LocalStringManager.GetConfig("SkillBreakGridType_language", "Desc_16"), "darkpurple", 0, 1, 0, -1, 30, 0, 0, 0, 0, 0, 0, 1, nextStepCanJumpToSame: false, neighborFailedToCanSelect: false, randomNeighborNormalConvertToSameGrid: false, allNeighborNormalConvertToSpecialGrid: false, allNeighborSpecialConvertToNormalGrid: true, clearNeighborMaxPower: false, ignoreEffectAddMaxPower: false, 0, 0, 0, 0, 1, 3));
		_dataArray.Add(new SkillBreakGridTypeItem(17, LocalStringManager.GetConfig("SkillBreakGridType_language", "Name_17"), ESkillBreakGridTypeType.Special, LocalStringManager.GetConfig("SkillBreakGridType_language", "Desc_17"), "darkpurple", 0, 1, 0, -1, 0, 0, 0, 0, 0, 0, 0, 1, nextStepCanJumpToSame: false, neighborFailedToCanSelect: false, randomNeighborNormalConvertToSameGrid: false, allNeighborNormalConvertToSpecialGrid: false, allNeighborSpecialConvertToNormalGrid: false, clearNeighborMaxPower: false, ignoreEffectAddMaxPower: false, 1, 0, 0, 0, 1, 15));
		_dataArray.Add(new SkillBreakGridTypeItem(18, LocalStringManager.GetConfig("SkillBreakGridType_language", "Name_18"), ESkillBreakGridTypeType.Special, LocalStringManager.GetConfig("SkillBreakGridType_language", "Desc_18"), "darkpurple", 0, 1, 3, -1, 0, 0, 0, 0, 0, 0, 0, 1, nextStepCanJumpToSame: false, neighborFailedToCanSelect: false, randomNeighborNormalConvertToSameGrid: false, allNeighborNormalConvertToSpecialGrid: false, allNeighborSpecialConvertToNormalGrid: false, clearNeighborMaxPower: true, ignoreEffectAddMaxPower: false, 0, 0, 0, 0, 1, 15));
		_dataArray.Add(new SkillBreakGridTypeItem(19, LocalStringManager.GetConfig("SkillBreakGridType_language", "Name_19"), ESkillBreakGridTypeType.Special, LocalStringManager.GetConfig("SkillBreakGridType_language", "Desc_19"), "darkpurple", 0, 1, 0, -1, 0, 0, 0, 0, 5, 0, 0, 1, nextStepCanJumpToSame: false, neighborFailedToCanSelect: false, randomNeighborNormalConvertToSameGrid: false, allNeighborNormalConvertToSpecialGrid: false, allNeighborSpecialConvertToNormalGrid: false, clearNeighborMaxPower: false, ignoreEffectAddMaxPower: false, 0, 0, 0, 0, 1, 15));
		_dataArray.Add(new SkillBreakGridTypeItem(20, LocalStringManager.GetConfig("SkillBreakGridType_language", "Name_20"), ESkillBreakGridTypeType.Special, LocalStringManager.GetConfig("SkillBreakGridType_language", "Desc_20"), "darkpurple", 0, 1, 0, -1, 0, 0, 0, 0, 0, 5, 0, 1, nextStepCanJumpToSame: false, neighborFailedToCanSelect: false, randomNeighborNormalConvertToSameGrid: false, allNeighborNormalConvertToSpecialGrid: false, allNeighborSpecialConvertToNormalGrid: false, clearNeighborMaxPower: false, ignoreEffectAddMaxPower: false, 0, 0, 0, 0, 1, 15));
		_dataArray.Add(new SkillBreakGridTypeItem(21, LocalStringManager.GetConfig("SkillBreakGridType_language", "Name_21"), ESkillBreakGridTypeType.Special, LocalStringManager.GetConfig("SkillBreakGridType_language", "Desc_21"), "darkpurple", 0, 1, 0, -1, 0, 0, 0, 0, 0, 0, 0, 1, nextStepCanJumpToSame: true, neighborFailedToCanSelect: false, randomNeighborNormalConvertToSameGrid: false, allNeighborNormalConvertToSpecialGrid: false, allNeighborSpecialConvertToNormalGrid: false, clearNeighborMaxPower: false, ignoreEffectAddMaxPower: false, 0, 0, 0, 0, 2, 3));
		_dataArray.Add(new SkillBreakGridTypeItem(22, LocalStringManager.GetConfig("SkillBreakGridType_language", "Name_22"), ESkillBreakGridTypeType.Normal, LocalStringManager.GetConfig("SkillBreakGridType_language", "Desc_22"), "brightblue", 0, 1, 0, 100, 0, 0, 0, 0, 0, 0, 0, 1, nextStepCanJumpToSame: false, neighborFailedToCanSelect: false, randomNeighborNormalConvertToSameGrid: false, allNeighborNormalConvertToSpecialGrid: false, allNeighborSpecialConvertToNormalGrid: false, clearNeighborMaxPower: false, ignoreEffectAddMaxPower: false, 0, 0, 0, 0, 0, 0));
		_dataArray.Add(new SkillBreakGridTypeItem(23, LocalStringManager.GetConfig("SkillBreakGridType_language", "Name_23"), ESkillBreakGridTypeType.Normal, LocalStringManager.GetConfig("SkillBreakGridType_language", "Desc_23"), "brightred", 0, 1, 0, -1, 100, 0, 0, 0, 0, 0, 0, 1, nextStepCanJumpToSame: false, neighborFailedToCanSelect: false, randomNeighborNormalConvertToSameGrid: false, allNeighborNormalConvertToSpecialGrid: false, allNeighborSpecialConvertToNormalGrid: false, clearNeighborMaxPower: false, ignoreEffectAddMaxPower: false, 0, 0, 0, 6, 0, 0));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SkillBreakGridTypeItem>(24);
		CreateItems0();
	}
}
