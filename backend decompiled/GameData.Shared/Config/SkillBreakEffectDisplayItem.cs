using System;
using Config.Common;

namespace Config;

[Serializable]
public class SkillBreakEffectDisplayItem : ConfigItem<SkillBreakEffectDisplayItem, sbyte>
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
	/// 简述
	/// </summary>
	public readonly string ShortName;

	/// <summary>
	/// 小图标
	/// - 26*26，用于Tips图文混排
	/// </summary>
	public readonly string Icon;

	/// <summary>
	/// 大图标
	/// - 40*40，界面特殊用途时的规格
	/// </summary>
	public readonly string BigIcon;

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
	/// 是否负向加成才好
	/// - FALSE：+为正向，-为负向；TRUE：+为负向，-为正向
	/// </summary>
	public readonly bool IsInverse;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="shortName">简述</param>
	/// <param name="icon">小图标 - 26*26，用于Tips图文混排</param>
	/// <param name="bigIcon">大图标 - 40*40，界面特殊用途时的规格</param>
	/// <param name="isPercent">是否百分比加成</param>
	/// <param name="plusColor">正值颜色</param>
	/// <param name="minusColor">负值颜色</param>
	/// <param name="isInverse">是否负向加成才好 - FALSE：+为正向，-为负向；TRUE：+为负向，-为正向</param>
	public SkillBreakEffectDisplayItem(sbyte templateId, string name, string shortName, string icon, string bigIcon, bool isPercent, string plusColor, string minusColor, bool isInverse)
	{
		TemplateId = templateId;
		Name = name;
		ShortName = shortName;
		Icon = icon;
		BigIcon = bigIcon;
		IsPercent = isPercent;
		PlusColor = plusColor;
		MinusColor = minusColor;
		IsInverse = isInverse;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SkillBreakEffectDisplayItem()
	{
		TemplateId = 0;
		Name = null;
		ShortName = null;
		Icon = null;
		BigIcon = null;
		IsPercent = false;
		PlusColor = "brightblue";
		MinusColor = "brightred";
		IsInverse = false;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public SkillBreakEffectDisplayItem(sbyte templateId, SkillBreakEffectDisplayItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		ShortName = other.ShortName;
		Icon = other.Icon;
		BigIcon = other.BigIcon;
		IsPercent = other.IsPercent;
		PlusColor = other.PlusColor;
		MinusColor = other.MinusColor;
		IsInverse = other.IsInverse;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SkillBreakEffectDisplayItem Duplicate(int templateId)
	{
		return new SkillBreakEffectDisplayItem((sbyte)templateId, this);
	}
}
