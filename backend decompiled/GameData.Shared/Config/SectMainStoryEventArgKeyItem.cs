using System;
using Config.Common;

namespace Config;

[Serializable]
public class SectMainStoryEventArgKeyItem : ConfigItem<SectMainStoryEventArgKeyItem, int>, IEventArgumentFormatter
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 门派
	/// </summary>
	public readonly sbyte Sect;

	/// <summary>
	/// 参数盒子Key
	/// </summary>
	public readonly string ArgBoxKey;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="sect">门派</param>
	/// <param name="argBoxKey">参数盒子Key</param>
	public SectMainStoryEventArgKeyItem(int templateId, sbyte sect, string argBoxKey)
	{
		TemplateId = templateId;
		Sect = sect;
		ArgBoxKey = argBoxKey;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SectMainStoryEventArgKeyItem()
	{
		TemplateId = 0;
		Sect = 0;
		ArgBoxKey = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public SectMainStoryEventArgKeyItem(int templateId, SectMainStoryEventArgKeyItem other)
	{
		TemplateId = templateId;
		Sect = other.Sect;
		ArgBoxKey = other.ArgBoxKey;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SectMainStoryEventArgKeyItem Duplicate(int templateId)
	{
		return new SectMainStoryEventArgKeyItem(templateId, this);
	}

	public static implicit operator string(SectMainStoryEventArgKeyItem item)
	{
		return item.ArgBoxKey;
	}

	string IEventArgumentFormatter.ToArgString()
	{
		return ArgBoxKey;
	}
}
