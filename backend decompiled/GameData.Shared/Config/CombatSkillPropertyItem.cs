using System;
using Config.Common;

namespace Config;

[Serializable]
public class CombatSkillPropertyItem : ConfigItem<CombatSkillPropertyItem, sbyte>
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
	/// 是否百分比加成
	/// </summary>
	public readonly bool IsPercent;

	/// <summary>
	/// 正值颜色
	/// </summary>
	public readonly string PlusColor;

	/// <summary>
	/// 负值颜色
	/// </summary>
	public readonly string MinusColor;

	/// <summary>
	/// 用于Tips的小图标
	/// - 26*26的图标
	/// </summary>
	public readonly string TipsSmallIcon;

	/// <summary>
	/// 用于Tips的大图标
	/// - 40*40的图标
	/// </summary>
	public readonly string TipsIcon;

	/// <summary>
	/// 是否数值越大越不好
	/// - 0：+为正向，-为负向；1：+为负向，-为正向
	/// </summary>
	public readonly bool IsInverse;

	/// <summary>
	/// 显示修正值
	/// - 正数为乘算，负数为除算
	/// </summary>
	public readonly int DisplayFix;

	/// <summary>
	/// 是否特殊显示
	/// - 0为显示在Tips的运功属性和施展属性中，1为特殊处理
	/// </summary>
	public readonly bool IsDisplaySpecially;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="isPercent">是否百分比加成</param>
	/// <param name="plusColor">正值颜色</param>
	/// <param name="minusColor">负值颜色</param>
	/// <param name="tipsSmallIcon">用于Tips的小图标 - 26*26的图标</param>
	/// <param name="tipsIcon">用于Tips的大图标 - 40*40的图标</param>
	/// <param name="isInverse">是否数值越大越不好 - 0：+为正向，-为负向；1：+为负向，-为正向</param>
	/// <param name="displayFix">显示修正值 - 正数为乘算，负数为除算</param>
	/// <param name="isDisplaySpecially">是否特殊显示 - 0为显示在Tips的运功属性和施展属性中，1为特殊处理</param>
	public CombatSkillPropertyItem(sbyte templateId, string name, bool isPercent, string plusColor, string minusColor, string tipsSmallIcon, string tipsIcon, bool isInverse, int displayFix, bool isDisplaySpecially)
	{
		TemplateId = templateId;
		Name = name;
		IsPercent = isPercent;
		PlusColor = plusColor;
		MinusColor = minusColor;
		TipsSmallIcon = tipsSmallIcon;
		TipsIcon = tipsIcon;
		IsInverse = isInverse;
		DisplayFix = displayFix;
		IsDisplaySpecially = isDisplaySpecially;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public CombatSkillPropertyItem()
	{
		TemplateId = 0;
		Name = null;
		IsPercent = false;
		PlusColor = null;
		MinusColor = null;
		TipsSmallIcon = null;
		TipsIcon = null;
		IsInverse = false;
		DisplayFix = 0;
		IsDisplaySpecially = false;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public CombatSkillPropertyItem(sbyte templateId, CombatSkillPropertyItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		IsPercent = other.IsPercent;
		PlusColor = other.PlusColor;
		MinusColor = other.MinusColor;
		TipsSmallIcon = other.TipsSmallIcon;
		TipsIcon = other.TipsIcon;
		IsInverse = other.IsInverse;
		DisplayFix = other.DisplayFix;
		IsDisplaySpecially = other.IsDisplaySpecially;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override CombatSkillPropertyItem Duplicate(int templateId)
	{
		return new CombatSkillPropertyItem((sbyte)templateId, this);
	}
}
