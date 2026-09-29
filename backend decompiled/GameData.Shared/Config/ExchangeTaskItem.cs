using System;
using Config.Common;

namespace Config;

[Serializable]
public class ExchangeTaskItem : ConfigItem<ExchangeTaskItem, int>
{
	public readonly int TemplateId;

	public readonly string Desc;

	public readonly int Advantage;

	public readonly int Limit;

	public readonly bool ForTaiwuWillGainItem;

	public readonly bool ForTreasury;

	public readonly bool ForCharacter;

	public readonly bool IsTargetLoveItem;

	public readonly bool IsTargetHateItem;

	public readonly bool IsTaiwuItemGradeExceedTargetGrade;

	public readonly bool IsTargetEquip;

	public readonly bool IsTargetHasRelationToKidnapper;

	public readonly short ItemSubType;

	public readonly sbyte[] MeetBehaviourType;

	public readonly short[] MeetOrganization;

	public readonly sbyte[] MeetGrade;

	public readonly sbyte[] MeetFameLevel;

	public ExchangeTaskItem(int templateId, string desc, int advantage, int limit, bool forTaiwuWillGainItem, bool forTreasury, bool forCharacter, bool isTargetLoveItem, bool isTargetHateItem, bool isTaiwuItemGradeExceedTargetGrade, bool isTargetEquip, bool isTargetHasRelationToKidnapper, short itemSubType, sbyte[] meetBehaviourType, short[] meetOrganization, sbyte[] meetGrade, sbyte[] meetFameLevel)
	{
		TemplateId = templateId;
		Desc = desc;
		Advantage = advantage;
		Limit = limit;
		ForTaiwuWillGainItem = forTaiwuWillGainItem;
		ForTreasury = forTreasury;
		ForCharacter = forCharacter;
		IsTargetLoveItem = isTargetLoveItem;
		IsTargetHateItem = isTargetHateItem;
		IsTaiwuItemGradeExceedTargetGrade = isTaiwuItemGradeExceedTargetGrade;
		IsTargetEquip = isTargetEquip;
		IsTargetHasRelationToKidnapper = isTargetHasRelationToKidnapper;
		ItemSubType = itemSubType;
		MeetBehaviourType = meetBehaviourType;
		MeetOrganization = meetOrganization;
		MeetGrade = meetGrade;
		MeetFameLevel = meetFameLevel;
	}

	public ExchangeTaskItem()
	{
		TemplateId = 0;
		Desc = null;
		Advantage = 0;
		Limit = -1;
		ForTaiwuWillGainItem = false;
		ForTreasury = false;
		ForCharacter = false;
		IsTargetLoveItem = false;
		IsTargetHateItem = false;
		IsTaiwuItemGradeExceedTargetGrade = false;
		IsTargetEquip = false;
		IsTargetHasRelationToKidnapper = false;
		ItemSubType = 0;
		MeetBehaviourType = null;
		MeetOrganization = null;
		MeetGrade = null;
		MeetFameLevel = null;
	}

	public ExchangeTaskItem(int templateId, ExchangeTaskItem other)
	{
		TemplateId = templateId;
		Desc = other.Desc;
		Advantage = other.Advantage;
		Limit = other.Limit;
		ForTaiwuWillGainItem = other.ForTaiwuWillGainItem;
		ForTreasury = other.ForTreasury;
		ForCharacter = other.ForCharacter;
		IsTargetLoveItem = other.IsTargetLoveItem;
		IsTargetHateItem = other.IsTargetHateItem;
		IsTaiwuItemGradeExceedTargetGrade = other.IsTaiwuItemGradeExceedTargetGrade;
		IsTargetEquip = other.IsTargetEquip;
		IsTargetHasRelationToKidnapper = other.IsTargetHasRelationToKidnapper;
		ItemSubType = other.ItemSubType;
		MeetBehaviourType = other.MeetBehaviourType;
		MeetOrganization = other.MeetOrganization;
		MeetGrade = other.MeetGrade;
		MeetFameLevel = other.MeetFameLevel;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override ExchangeTaskItem Duplicate(int templateId)
	{
		return new ExchangeTaskItem(templateId, this);
	}
}
