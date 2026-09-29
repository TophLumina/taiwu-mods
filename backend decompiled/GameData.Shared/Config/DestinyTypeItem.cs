using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class DestinyTypeItem : ConfigItem<DestinyTypeItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly short Feature;

	public readonly short[] MoralityRange;

	public readonly short MotherLifeRecord;

	public readonly List<sbyte> SectList;

	public readonly sbyte[] OrganizationGradeRange;

	public readonly string RecordColor;

	public readonly string UnlockResourceTypeIcon;

	public readonly ushort[] UnlockCost;

	public readonly string LockedIcon;

	public readonly string UnlockedIcon;

	public DestinyTypeItem(sbyte templateId, string name, string desc, short feature, short[] moralityRange, short motherLifeRecord, List<sbyte> sectList, sbyte[] organizationGradeRange, string recordColor, string unlockResourceTypeIcon, ushort[] unlockCost, string lockedIcon, string unlockedIcon)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Feature = feature;
		MoralityRange = moralityRange;
		MotherLifeRecord = motherLifeRecord;
		SectList = sectList;
		OrganizationGradeRange = organizationGradeRange;
		RecordColor = recordColor;
		UnlockResourceTypeIcon = unlockResourceTypeIcon;
		UnlockCost = unlockCost;
		LockedIcon = lockedIcon;
		UnlockedIcon = unlockedIcon;
	}

	public DestinyTypeItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Feature = 0;
		MoralityRange = null;
		MotherLifeRecord = 0;
		SectList = null;
		OrganizationGradeRange = null;
		RecordColor = null;
		UnlockResourceTypeIcon = null;
		UnlockCost = null;
		LockedIcon = null;
		UnlockedIcon = null;
	}

	public DestinyTypeItem(sbyte templateId, DestinyTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Feature = other.Feature;
		MoralityRange = other.MoralityRange;
		MotherLifeRecord = other.MotherLifeRecord;
		SectList = other.SectList;
		OrganizationGradeRange = other.OrganizationGradeRange;
		RecordColor = other.RecordColor;
		UnlockResourceTypeIcon = other.UnlockResourceTypeIcon;
		UnlockCost = other.UnlockCost;
		LockedIcon = other.LockedIcon;
		UnlockedIcon = other.UnlockedIcon;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override DestinyTypeItem Duplicate(int templateId)
	{
		return new DestinyTypeItem((sbyte)templateId, this);
	}
}
