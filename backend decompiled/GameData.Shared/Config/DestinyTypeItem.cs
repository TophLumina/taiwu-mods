using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class DestinyTypeItem : ConfigItem<DestinyTypeItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 特性
	/// </summary>
	public readonly short Feature;

	/// <summary>
	/// 立场范围
	/// - [最小值,最大值]. 立场取值范围 [-500, 500]. 
	/// - [-500, -375]: 唯我, 
	/// - (-375, -125]: 叛逆, 
	/// - (-125, 125): 中庸, 
	/// - [125, 375): 仁善, 
	/// - [375, 500]: 刚正.
	/// </summary>
	public readonly short[] MoralityRange;

	/// <summary>
	/// 母亲经历
	/// </summary>
	public readonly short MotherLifeRecord;

	/// <summary>
	/// 门派限制
	/// </summary>
	public readonly List<sbyte> SectList;

	/// <summary>
	/// 组织阶级范围
	/// </summary>
	public readonly sbyte[] OrganizationGradeRange;

	/// <summary>
	/// 记录里的颜色
	/// </summary>
	public readonly string RecordColor;

	/// <summary>
	/// 解锁资源图标
	/// </summary>
	public readonly string UnlockResourceTypeIcon;

	/// <summary>
	/// 解锁消耗
	/// - 不可直接配置此列
	/// </summary>
	public readonly ushort[] UnlockCost;

	/// <summary>
	/// 未解锁图标
	/// </summary>
	public readonly string LockedIcon;

	/// <summary>
	/// 解锁了的图标
	/// </summary>
	public readonly string UnlockedIcon;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="desc">描述</param>
	/// <param name="feature">特性</param>
	/// <param name="moralityRange">立场范围 - [最小值,最大值]. 立场取值范围 [-500, 500].  [-500, -375]: 唯我,  (-375, -125]: 叛逆,  (-125, 125): 中庸,  [125, 375): 仁善,  [375, 500]: 刚正.</param>
	/// <param name="motherLifeRecord">母亲经历</param>
	/// <param name="sectList">门派限制</param>
	/// <param name="organizationGradeRange">组织阶级范围</param>
	/// <param name="recordColor">记录里的颜色</param>
	/// <param name="unlockResourceTypeIcon">解锁资源图标</param>
	/// <param name="unlockCost">解锁消耗 - 不可直接配置此列</param>
	/// <param name="lockedIcon">未解锁图标</param>
	/// <param name="unlockedIcon">解锁了的图标</param>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override DestinyTypeItem Duplicate(int templateId)
	{
		return new DestinyTypeItem((sbyte)templateId, this);
	}
}
