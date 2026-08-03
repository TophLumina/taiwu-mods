using System;
using Config.Common;

namespace Config;

[Serializable]
public class MainMenuButtonItem : ConfigItem<MainMenuButtonItem, byte>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly byte TemplateId;

	/// <summary>
	/// 按钮名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 简单描述
	/// </summary>
	public readonly string Summary;

	/// <summary>
	/// 详细描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 允许演武使用
	/// </summary>
	public readonly bool AllowInGuiding;

	/// <summary>
	/// 关联世界功能
	/// - 为-1代表功能永远开启
	/// </summary>
	public readonly sbyte WorldFunction;

	/// <summary>
	/// 图标
	/// </summary>
	public readonly string IconPrefix;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">按钮名称</param>
	/// <param name="summary">简单描述</param>
	/// <param name="desc">详细描述</param>
	/// <param name="allowInGuiding">允许演武使用</param>
	/// <param name="worldFunction">关联世界功能 - 为-1代表功能永远开启</param>
	/// <param name="iconPrefix">图标</param>
	public MainMenuButtonItem(byte templateId, string name, string summary, string desc, bool allowInGuiding, sbyte worldFunction, string iconPrefix)
	{
		TemplateId = templateId;
		Name = name;
		Summary = summary;
		Desc = desc;
		AllowInGuiding = allowInGuiding;
		WorldFunction = worldFunction;
		IconPrefix = iconPrefix;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public MainMenuButtonItem()
	{
		TemplateId = 0;
		Name = null;
		Summary = null;
		Desc = null;
		AllowInGuiding = false;
		WorldFunction = 0;
		IconPrefix = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public MainMenuButtonItem(byte templateId, MainMenuButtonItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Summary = other.Summary;
		Desc = other.Desc;
		AllowInGuiding = other.AllowInGuiding;
		WorldFunction = other.WorldFunction;
		IconPrefix = other.IconPrefix;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override MainMenuButtonItem Duplicate(int templateId)
	{
		return new MainMenuButtonItem((byte)templateId, this);
	}
}
