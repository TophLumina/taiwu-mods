using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class StatInfoItem : ConfigItem<StatInfoItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string SteamName;

	public readonly EStatInfoSaveType SaveType;

	public readonly List<short> AchievementTemplateId;

	public readonly EStatInfoType Type;

	public readonly EStatInfoSetType SetType;

	public readonly int MaxValue;

	public StatInfoItem(short templateId, string name, string steamName, EStatInfoSaveType saveType, List<short> achievementTemplateId, EStatInfoType type, EStatInfoSetType setType, int maxValue)
	{
		TemplateId = templateId;
		Name = name;
		SteamName = steamName;
		SaveType = saveType;
		AchievementTemplateId = achievementTemplateId;
		Type = type;
		SetType = setType;
		MaxValue = maxValue;
	}

	public StatInfoItem()
	{
		TemplateId = 0;
		Name = null;
		SteamName = null;
		SaveType = EStatInfoSaveType.Local;
		AchievementTemplateId = new List<short>();
		Type = EStatInfoType.Invalid;
		SetType = EStatInfoSetType.Replace;
		MaxValue = -1;
	}

	public StatInfoItem(short templateId, StatInfoItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		SteamName = other.SteamName;
		SaveType = other.SaveType;
		AchievementTemplateId = other.AchievementTemplateId;
		Type = other.Type;
		SetType = other.SetType;
		MaxValue = other.MaxValue;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override StatInfoItem Duplicate(int templateId)
	{
		return new StatInfoItem((short)templateId, this);
	}
}
