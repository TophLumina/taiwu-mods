using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class DemandInteraction : ConfigData<DemandInteractionItem, short>
{
	public static class DefKey
	{
		public const short RequestHealOuterInjuryByItem = 0;

		public const short RequestHealInnerInjuryByItem = 1;

		public const short RequestHealPoisonByItem = 2;

		public const short RequestHealth = 3;

		public const short RequestHealDisorderOfQi = 4;

		public const short RequestNeili = 5;

		public const short RequestKillWug = 6;

		public const short RequestFood = 7;

		public const short RequestTeaWine = 8;

		public const short RequestResource = 9;

		public const short RequestItem = 10;

		public const short RequestRepairItem = 11;

		public const short RequestAddPoisonToItem = 12;

		public const short RequestInstructionOnReadingLifeSkill = 13;

		public const short RequestInstructionOnReadingCombatSkill = 14;

		public const short RequestInstructionOnBreakout = 15;
	}

	public static class DefValue
	{
		public static DemandInteractionItem RequestHealOuterInjuryByItem => Instance[(short)0];

		public static DemandInteractionItem RequestHealInnerInjuryByItem => Instance[(short)1];

		public static DemandInteractionItem RequestHealPoisonByItem => Instance[(short)2];

		public static DemandInteractionItem RequestHealth => Instance[(short)3];

		public static DemandInteractionItem RequestHealDisorderOfQi => Instance[(short)4];

		public static DemandInteractionItem RequestNeili => Instance[(short)5];

		public static DemandInteractionItem RequestKillWug => Instance[(short)6];

		public static DemandInteractionItem RequestFood => Instance[(short)7];

		public static DemandInteractionItem RequestTeaWine => Instance[(short)8];

		public static DemandInteractionItem RequestResource => Instance[(short)9];

		public static DemandInteractionItem RequestItem => Instance[(short)10];

		public static DemandInteractionItem RequestRepairItem => Instance[(short)11];

		public static DemandInteractionItem RequestAddPoisonToItem => Instance[(short)12];

		public static DemandInteractionItem RequestInstructionOnReadingLifeSkill => Instance[(short)13];

		public static DemandInteractionItem RequestInstructionOnReadingCombatSkill => Instance[(short)14];

		public static DemandInteractionItem RequestInstructionOnBreakout => Instance[(short)15];
	}

	public static DemandInteraction Instance = new DemandInteraction();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "HeadEvent", "AgreeSelect", "AfterAgree", "TemplateId" };

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
		_dataArray.Add(new DemandInteractionItem(0, LocalStringManager.GetConfig("DemandInteraction_language", "Name_0"), LocalStringManager.GetConfig("DemandInteraction_language", "HeadEvent_0"), LocalStringManager.GetConfig("DemandInteraction_language", "AgreeSelect_0"), LocalStringManager.GetConfig("DemandInteraction_language", "AfterAgree_0")));
		_dataArray.Add(new DemandInteractionItem(1, LocalStringManager.GetConfig("DemandInteraction_language", "Name_1"), LocalStringManager.GetConfig("DemandInteraction_language", "HeadEvent_1"), LocalStringManager.GetConfig("DemandInteraction_language", "AgreeSelect_1"), LocalStringManager.GetConfig("DemandInteraction_language", "AfterAgree_1")));
		_dataArray.Add(new DemandInteractionItem(2, LocalStringManager.GetConfig("DemandInteraction_language", "Name_2"), LocalStringManager.GetConfig("DemandInteraction_language", "HeadEvent_2"), LocalStringManager.GetConfig("DemandInteraction_language", "AgreeSelect_2"), LocalStringManager.GetConfig("DemandInteraction_language", "AfterAgree_2")));
		_dataArray.Add(new DemandInteractionItem(3, LocalStringManager.GetConfig("DemandInteraction_language", "Name_3"), LocalStringManager.GetConfig("DemandInteraction_language", "HeadEvent_3"), LocalStringManager.GetConfig("DemandInteraction_language", "AgreeSelect_3"), LocalStringManager.GetConfig("DemandInteraction_language", "AfterAgree_3")));
		_dataArray.Add(new DemandInteractionItem(4, LocalStringManager.GetConfig("DemandInteraction_language", "Name_4"), LocalStringManager.GetConfig("DemandInteraction_language", "HeadEvent_4"), LocalStringManager.GetConfig("DemandInteraction_language", "AgreeSelect_4"), LocalStringManager.GetConfig("DemandInteraction_language", "AfterAgree_4")));
		_dataArray.Add(new DemandInteractionItem(5, LocalStringManager.GetConfig("DemandInteraction_language", "Name_5"), LocalStringManager.GetConfig("DemandInteraction_language", "HeadEvent_5"), LocalStringManager.GetConfig("DemandInteraction_language", "AgreeSelect_5"), LocalStringManager.GetConfig("DemandInteraction_language", "AfterAgree_5")));
		_dataArray.Add(new DemandInteractionItem(6, LocalStringManager.GetConfig("DemandInteraction_language", "Name_6"), LocalStringManager.GetConfig("DemandInteraction_language", "HeadEvent_6"), LocalStringManager.GetConfig("DemandInteraction_language", "AgreeSelect_6"), LocalStringManager.GetConfig("DemandInteraction_language", "AfterAgree_6")));
		_dataArray.Add(new DemandInteractionItem(7, LocalStringManager.GetConfig("DemandInteraction_language", "Name_7"), LocalStringManager.GetConfig("DemandInteraction_language", "HeadEvent_7"), LocalStringManager.GetConfig("DemandInteraction_language", "AgreeSelect_7"), LocalStringManager.GetConfig("DemandInteraction_language", "AfterAgree_7")));
		_dataArray.Add(new DemandInteractionItem(8, LocalStringManager.GetConfig("DemandInteraction_language", "Name_8"), LocalStringManager.GetConfig("DemandInteraction_language", "HeadEvent_8"), LocalStringManager.GetConfig("DemandInteraction_language", "AgreeSelect_8"), LocalStringManager.GetConfig("DemandInteraction_language", "AfterAgree_8")));
		_dataArray.Add(new DemandInteractionItem(9, LocalStringManager.GetConfig("DemandInteraction_language", "Name_9"), LocalStringManager.GetConfig("DemandInteraction_language", "HeadEvent_9"), LocalStringManager.GetConfig("DemandInteraction_language", "AgreeSelect_9"), LocalStringManager.GetConfig("DemandInteraction_language", "AfterAgree_9")));
		_dataArray.Add(new DemandInteractionItem(10, LocalStringManager.GetConfig("DemandInteraction_language", "Name_10"), LocalStringManager.GetConfig("DemandInteraction_language", "HeadEvent_10"), LocalStringManager.GetConfig("DemandInteraction_language", "AgreeSelect_10"), LocalStringManager.GetConfig("DemandInteraction_language", "AfterAgree_10")));
		_dataArray.Add(new DemandInteractionItem(11, LocalStringManager.GetConfig("DemandInteraction_language", "Name_11"), LocalStringManager.GetConfig("DemandInteraction_language", "HeadEvent_11"), LocalStringManager.GetConfig("DemandInteraction_language", "AgreeSelect_11"), LocalStringManager.GetConfig("DemandInteraction_language", "AfterAgree_11")));
		_dataArray.Add(new DemandInteractionItem(12, LocalStringManager.GetConfig("DemandInteraction_language", "Name_12"), LocalStringManager.GetConfig("DemandInteraction_language", "HeadEvent_12"), LocalStringManager.GetConfig("DemandInteraction_language", "AgreeSelect_12"), LocalStringManager.GetConfig("DemandInteraction_language", "AfterAgree_12")));
		_dataArray.Add(new DemandInteractionItem(13, LocalStringManager.GetConfig("DemandInteraction_language", "Name_13"), LocalStringManager.GetConfig("DemandInteraction_language", "HeadEvent_13"), LocalStringManager.GetConfig("DemandInteraction_language", "AgreeSelect_13"), LocalStringManager.GetConfig("DemandInteraction_language", "AfterAgree_13")));
		_dataArray.Add(new DemandInteractionItem(14, LocalStringManager.GetConfig("DemandInteraction_language", "Name_14"), LocalStringManager.GetConfig("DemandInteraction_language", "HeadEvent_14"), LocalStringManager.GetConfig("DemandInteraction_language", "AgreeSelect_14"), LocalStringManager.GetConfig("DemandInteraction_language", "AfterAgree_14")));
		_dataArray.Add(new DemandInteractionItem(15, LocalStringManager.GetConfig("DemandInteraction_language", "Name_15"), LocalStringManager.GetConfig("DemandInteraction_language", "HeadEvent_15"), LocalStringManager.GetConfig("DemandInteraction_language", "AgreeSelect_15"), LocalStringManager.GetConfig("DemandInteraction_language", "AfterAgree_15")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<DemandInteractionItem>(16);
		CreateItems0();
	}
}
