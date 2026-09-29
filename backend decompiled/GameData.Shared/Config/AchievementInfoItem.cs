using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AchievementInfoItem : ConfigItem<AchievementInfoItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly string Icon;

	public readonly string IconSmall;

	public readonly EAchievementInfoType Type;

	public readonly sbyte Level;

	public readonly List<EAchievementInfoRequirementType> RequirementTypes;

	public readonly List<int[]> RequirementStats;

	public readonly uint DlcId;

	public readonly bool IsHidden;

	public readonly string SteamName;

	public AchievementInfoItem(short templateId, string name, string desc, string icon, string iconSmall, EAchievementInfoType type, sbyte level, List<EAchievementInfoRequirementType> requirementTypes, List<int[]> requirementStats, uint dlcId, bool isHidden, string steamName)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Icon = icon;
		IconSmall = iconSmall;
		Type = type;
		Level = level;
		RequirementTypes = requirementTypes;
		RequirementStats = requirementStats;
		DlcId = dlcId;
		IsHidden = isHidden;
		SteamName = steamName;
	}

	public AchievementInfoItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Icon = null;
		IconSmall = null;
		Type = EAchievementInfoType.Taiwu;
		Level = 0;
		RequirementTypes = null;
		RequirementStats = null;
		DlcId = 0u;
		IsHidden = false;
		SteamName = null;
	}

	public AchievementInfoItem(short templateId, AchievementInfoItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Icon = other.Icon;
		IconSmall = other.IconSmall;
		Type = other.Type;
		Level = other.Level;
		RequirementTypes = other.RequirementTypes;
		RequirementStats = other.RequirementStats;
		DlcId = other.DlcId;
		IsHidden = other.IsHidden;
		SteamName = other.SteamName;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override AchievementInfoItem Duplicate(int templateId)
	{
		return new AchievementInfoItem((short)templateId, this);
	}
}
