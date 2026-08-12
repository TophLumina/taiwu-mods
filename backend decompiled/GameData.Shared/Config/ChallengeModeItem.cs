using System;
using Config.Common;

namespace Config;

[Serializable]
public class ChallengeModeItem : ConfigItem<ChallengeModeItem, int>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 类别
	/// </summary>
	public readonly EChallengeModeType Type;

	/// <summary>
	/// 实现
	/// - 此列由程序维护
	/// </summary>
	public readonly EChallengeModeImplement Implement;

	/// <summary>
	/// 点数
	/// </summary>
	public readonly int Point;

	/// <summary>
	/// 图标
	/// </summary>
	public readonly string Icon;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="type">类别</param>
	/// <param name="implement">实现 - 此列由程序维护</param>
	/// <param name="point">点数</param>
	/// <param name="icon">图标</param>
	/// <param name="name">名称</param>
	/// <param name="desc">描述</param>
	public ChallengeModeItem(int templateId, EChallengeModeType type, EChallengeModeImplement implement, int point, string icon, string name, string desc)
	{
		TemplateId = templateId;
		Type = type;
		Implement = implement;
		Point = point;
		Icon = icon;
		Name = name;
		Desc = desc;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public ChallengeModeItem()
	{
		TemplateId = 0;
		Type = EChallengeModeType.Required;
		Implement = EChallengeModeImplement.Invalid;
		Point = 0;
		Icon = null;
		Name = null;
		Desc = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public ChallengeModeItem(int templateId, ChallengeModeItem other)
	{
		TemplateId = templateId;
		Type = other.Type;
		Implement = other.Implement;
		Point = other.Point;
		Icon = other.Icon;
		Name = other.Name;
		Desc = other.Desc;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override ChallengeModeItem Duplicate(int templateId)
	{
		return new ChallengeModeItem(templateId, this);
	}
}
