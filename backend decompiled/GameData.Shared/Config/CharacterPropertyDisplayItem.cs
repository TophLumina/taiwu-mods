using System;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterPropertyDisplayItem : ConfigItem<CharacterPropertyDisplayItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 显示类型
	/// </summary>
	public readonly ECharacterPropertyDisplayType Type;

	/// <summary>
	/// 属性名
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 简短属性名
	/// </summary>
	public readonly string ShortName;

	/// <summary>
	/// 属性描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 通用图标
	/// - 60*60的图标
	/// </summary>
	public readonly string Icon;

	/// <summary>
	/// 用于Tips的大图标
	/// - 40*40的图标
	/// </summary>
	public readonly string TipsBigIcon;

	/// <summary>
	/// 用于Tips的小图标
	/// - 26*26的图标
	/// </summary>
	public readonly string TipsIcon;

	/// <summary>
	/// 是否百分比
	/// </summary>
	public readonly bool IsPercent;

	/// <summary>
	/// 正值颜色
	/// - 参见 GameColors.PresetColors 表
	/// </summary>
	public readonly string PositiveColor;

	/// <summary>
	/// 负值颜色
	/// - 参见 GameColors.PresetColors 表
	/// </summary>
	public readonly string NegativeColor;

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
	/// <param name="templateId">模板 ID</param>
	/// <param name="type">显示类型</param>
	/// <param name="name">属性名</param>
	/// <param name="shortName">简短属性名</param>
	/// <param name="desc">属性描述</param>
	/// <param name="icon">通用图标 - 60*60的图标</param>
	/// <param name="tipsBigIcon">用于Tips的大图标 - 40*40的图标</param>
	/// <param name="tipsIcon">用于Tips的小图标 - 26*26的图标</param>
	/// <param name="isPercent">是否百分比</param>
	/// <param name="positiveColor">正值颜色 - 参见 GameColors.PresetColors 表</param>
	/// <param name="negativeColor">负值颜色 - 参见 GameColors.PresetColors 表</param>
	/// <param name="isInverse">是否数值越大越不好 - 0：+为正向，-为负向；1：+为负向，-为正向</param>
	/// <param name="displayFix">显示修正值 - 正数为乘算，负数为除算</param>
	/// <param name="isDisplaySpecially">是否特殊显示 - 0为显示在Tips的运功属性和施展属性中，1为特殊处理</param>
	public CharacterPropertyDisplayItem(short templateId, ECharacterPropertyDisplayType type, string name, string shortName, string desc, string icon, string tipsBigIcon, string tipsIcon, bool isPercent, string positiveColor, string negativeColor, bool isInverse, int displayFix, bool isDisplaySpecially)
	{
		TemplateId = templateId;
		Type = type;
		Name = name;
		ShortName = shortName;
		Desc = desc;
		Icon = icon;
		TipsBigIcon = tipsBigIcon;
		TipsIcon = tipsIcon;
		IsPercent = isPercent;
		PositiveColor = positiveColor;
		NegativeColor = negativeColor;
		IsInverse = isInverse;
		DisplayFix = displayFix;
		IsDisplaySpecially = isDisplaySpecially;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public CharacterPropertyDisplayItem()
	{
		TemplateId = 0;
		Type = ECharacterPropertyDisplayType.Strength;
		Name = null;
		ShortName = null;
		Desc = null;
		Icon = null;
		TipsBigIcon = null;
		TipsIcon = null;
		IsPercent = false;
		PositiveColor = null;
		NegativeColor = null;
		IsInverse = false;
		DisplayFix = 0;
		IsDisplaySpecially = false;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public CharacterPropertyDisplayItem(short templateId, CharacterPropertyDisplayItem other)
	{
		TemplateId = templateId;
		Type = other.Type;
		Name = other.Name;
		ShortName = other.ShortName;
		Desc = other.Desc;
		Icon = other.Icon;
		TipsBigIcon = other.TipsBigIcon;
		TipsIcon = other.TipsIcon;
		IsPercent = other.IsPercent;
		PositiveColor = other.PositiveColor;
		NegativeColor = other.NegativeColor;
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
	public override CharacterPropertyDisplayItem Duplicate(int templateId)
	{
		return new CharacterPropertyDisplayItem((short)templateId, this);
	}
}
