using System;
using Config.Common;

namespace Config;

[Serializable]
public class EventCgTextureItem : ConfigItem<EventCgTextureItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 资源名称格式
	/// </summary>
	public readonly string ResourceFormat;

	/// <summary>
	/// 贴图渐显/渐隐时长
	/// </summary>
	public readonly float AnimDuration;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="resourceFormat">资源名称格式</param>
	/// <param name="animDuration">贴图渐显/渐隐时长</param>
	public EventCgTextureItem(short templateId, string resourceFormat, float animDuration)
	{
		TemplateId = templateId;
		ResourceFormat = resourceFormat;
		AnimDuration = animDuration;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public EventCgTextureItem()
	{
		TemplateId = 0;
		ResourceFormat = null;
		AnimDuration = 1f;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public EventCgTextureItem(short templateId, EventCgTextureItem other)
	{
		TemplateId = templateId;
		ResourceFormat = other.ResourceFormat;
		AnimDuration = other.AnimDuration;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override EventCgTextureItem Duplicate(int templateId)
	{
		return new EventCgTextureItem((short)templateId, this);
	}
}
