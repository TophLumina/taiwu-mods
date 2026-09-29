using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class ExchangeTask : ConfigData<ExchangeTaskItem, int>
{
	public static ExchangeTask Instance = new ExchangeTask();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Desc", "ItemSubType", "MeetBehaviourType", "MeetOrganization", "TemplateId", "MeetGrade", "MeetFameLevel" };

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
		_dataArray.Add(new ExchangeTaskItem(0, LocalStringManager.GetConfig("ExchangeTask_language", "Desc_0"), 20, 5, forTaiwuWillGainItem: false, forTreasury: false, forCharacter: true, isTargetLoveItem: true, isTargetHateItem: false, isTaiwuItemGradeExceedTargetGrade: true, isTargetEquip: false, isTargetHasRelationToKidnapper: false, -1, new sbyte[4] { 0, 1, 2, 4 }, null, null, null));
		_dataArray.Add(new ExchangeTaskItem(1, LocalStringManager.GetConfig("ExchangeTask_language", "Desc_1"), -20, 5, forTaiwuWillGainItem: false, forTreasury: false, forCharacter: true, isTargetLoveItem: true, isTargetHateItem: false, isTaiwuItemGradeExceedTargetGrade: false, isTargetEquip: false, isTargetHasRelationToKidnapper: false, -1, new sbyte[1] { 3 }, null, null, null));
		_dataArray.Add(new ExchangeTaskItem(2, LocalStringManager.GetConfig("ExchangeTask_language", "Desc_2"), -20, 5, forTaiwuWillGainItem: false, forTreasury: false, forCharacter: true, isTargetLoveItem: false, isTargetHateItem: true, isTaiwuItemGradeExceedTargetGrade: false, isTargetEquip: false, isTargetHasRelationToKidnapper: false, -1, new sbyte[4] { 0, 1, 2, 4 }, null, null, null));
		_dataArray.Add(new ExchangeTaskItem(3, LocalStringManager.GetConfig("ExchangeTask_language", "Desc_3"), 20, 5, forTaiwuWillGainItem: false, forTreasury: false, forCharacter: true, isTargetLoveItem: false, isTargetHateItem: true, isTaiwuItemGradeExceedTargetGrade: true, isTargetEquip: false, isTargetHasRelationToKidnapper: false, -1, new sbyte[1] { 3 }, null, null, null));
		_dataArray.Add(new ExchangeTaskItem(4, LocalStringManager.GetConfig("ExchangeTask_language", "Desc_4"), -50, 1, forTaiwuWillGainItem: false, forTreasury: true, forCharacter: true, isTargetLoveItem: false, isTargetHateItem: false, isTaiwuItemGradeExceedTargetGrade: false, isTargetEquip: false, isTargetHasRelationToKidnapper: false, 801, null, new short[6] { 1, 4, 5, 6, 9, 14 }, null, null));
		_dataArray.Add(new ExchangeTaskItem(5, LocalStringManager.GetConfig("ExchangeTask_language", "Desc_5"), -50, 1, forTaiwuWillGainItem: false, forTreasury: true, forCharacter: true, isTargetLoveItem: false, isTargetHateItem: false, isTaiwuItemGradeExceedTargetGrade: false, isTargetEquip: false, isTargetHasRelationToKidnapper: false, 701, null, new short[4] { 1, 5, 7, 13 }, null, null));
		_dataArray.Add(new ExchangeTaskItem(6, LocalStringManager.GetConfig("ExchangeTask_language", "Desc_6"), -50, 1, forTaiwuWillGainItem: false, forTreasury: true, forCharacter: true, isTargetLoveItem: false, isTargetHateItem: false, isTaiwuItemGradeExceedTargetGrade: false, isTargetEquip: false, isTargetHasRelationToKidnapper: false, 901, null, new short[2] { 1, 10 }, null, null));
		_dataArray.Add(new ExchangeTaskItem(7, LocalStringManager.GetConfig("ExchangeTask_language", "Desc_7"), 100, -1, forTaiwuWillGainItem: false, forTreasury: false, forCharacter: true, isTargetLoveItem: false, isTargetHateItem: false, isTaiwuItemGradeExceedTargetGrade: false, isTargetEquip: false, isTargetHasRelationToKidnapper: true, -1, new sbyte[3] { 0, 1, 2 }, null, null, null));
		_dataArray.Add(new ExchangeTaskItem(8, LocalStringManager.GetConfig("ExchangeTask_language", "Desc_8"), -50, 1, forTaiwuWillGainItem: true, forTreasury: false, forCharacter: true, isTargetLoveItem: false, isTargetHateItem: false, isTaiwuItemGradeExceedTargetGrade: false, isTargetEquip: true, isTargetHasRelationToKidnapper: false, -1, null, null, null, null));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<ExchangeTaskItem>(9);
		CreateItems0();
	}
}
