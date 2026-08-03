using System;
using Config.Common;

namespace Config;

[Serializable]
public class MapBlockCharCustomInfoItem : ConfigItem<MapBlockCharCustomInfoItem, short>
{
	/// <summary>
	/// 模板id
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// Name
	/// - 此条目显示的名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 分类
	/// - 信息可以是文本显示，也可以是图片
	/// </summary>
	public readonly EMapBlockCharCustomInfoDisplayType DisplayType;

	/// <summary>
	/// Tip格式
	/// - 简单信息呈现使用的tips，复杂情况可不使用此列
	/// </summary>
	public readonly string TipContent;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板id</param>
	/// <param name="name">Name - 此条目显示的名称</param>
	/// <param name="displayType">分类 - 信息可以是文本显示，也可以是图片</param>
	/// <param name="tipContent">Tip格式 - 简单信息呈现使用的tips，复杂情况可不使用此列</param>
	public MapBlockCharCustomInfoItem(short templateId, string name, EMapBlockCharCustomInfoDisplayType displayType, string tipContent)
	{
		TemplateId = templateId;
		Name = name;
		DisplayType = displayType;
		TipContent = tipContent;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public MapBlockCharCustomInfoItem()
	{
		TemplateId = 0;
		Name = null;
		DisplayType = EMapBlockCharCustomInfoDisplayType.Invalid;
		TipContent = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public MapBlockCharCustomInfoItem(short templateId, MapBlockCharCustomInfoItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		DisplayType = other.DisplayType;
		TipContent = other.TipContent;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override MapBlockCharCustomInfoItem Duplicate(int templateId)
	{
		return new MapBlockCharCustomInfoItem((short)templateId, this);
	}
}
