using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class StatInfoItem : ConfigItem<StatInfoItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 统计名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// SteamAPI名称
	/// </summary>
	public readonly string SteamName;

	/// <summary>
	/// 储存类型
	/// </summary>
	public readonly EStatInfoSaveType SaveType;

	/// <summary>
	/// 与之关联的成就
	/// </summary>
	public readonly List<short> AchievementTemplateId;

	/// <summary>
	/// 本地存储类型
	/// </summary>
	public readonly EStatInfoType Type;

	/// <summary>
	/// 本地存储默认修改类型
	/// </summary>
	public readonly EStatInfoSetType SetType;

	/// <summary>
	/// 最大值
	/// </summary>
	public readonly int MaxValue;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">统计名称</param>
	/// <param name="steamName">SteamAPI名称</param>
	/// <param name="saveType">储存类型</param>
	/// <param name="achievementTemplateId">与之关联的成就</param>
	/// <param name="type">本地存储类型</param>
	/// <param name="setType">本地存储默认修改类型</param>
	/// <param name="maxValue">最大值</param>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override StatInfoItem Duplicate(int templateId)
	{
		return new StatInfoItem((short)templateId, this);
	}
}
