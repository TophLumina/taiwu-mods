using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AchievementInfoItem : ConfigItem<AchievementInfoItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 图标
	/// </summary>
	public readonly string Icon;

	/// <summary>
	/// 历代太吾数据界面图标
	/// - 显示在历代太吾数据界面的成就图标
	/// </summary>
	public readonly string IconSmall;

	/// <summary>
	/// 类型
	/// </summary>
	public readonly EAchievementInfoType Type;

	/// <summary>
	/// 等级
	/// </summary>
	public readonly sbyte Level;

	/// <summary>
	/// 判断方式
	/// - 为空时使用自定义判断，否则使用该列判断
	/// </summary>
	public readonly List<EAchievementInfoRequirementType> RequirementTypes;

	/// <summary>
	/// 判断统计
	/// - {{统计,值}}
	/// </summary>
	public readonly List<int[]> RequirementStats;

	/// <summary>
	/// DlcId
	/// </summary>
	public readonly uint DlcId;

	/// <summary>
	/// 是否隐藏
	/// </summary>
	public readonly bool IsHidden;

	/// <summary>
	/// SteamAPI名称
	/// - 为空时不上传Steam
	/// </summary>
	public readonly string SteamName;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="desc">描述</param>
	/// <param name="icon">图标</param>
	/// <param name="iconSmall">历代太吾数据界面图标 - 显示在历代太吾数据界面的成就图标</param>
	/// <param name="type">类型</param>
	/// <param name="level">等级</param>
	/// <param name="requirementTypes">判断方式 - 为空时使用自定义判断，否则使用该列判断</param>
	/// <param name="requirementStats">判断统计 - {{统计,值}}</param>
	/// <param name="dlcId">DlcId</param>
	/// <param name="isHidden">是否隐藏</param>
	/// <param name="steamName">SteamAPI名称 - 为空时不上传Steam</param>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override AchievementInfoItem Duplicate(int templateId)
	{
		return new AchievementInfoItem((short)templateId, this);
	}
}
