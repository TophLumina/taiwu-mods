using System;
using Config.Common;

namespace Config;

[Serializable]
public class SortItemItem : ConfigItem<SortItemItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string[] Names;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="names">名称</param>
	public SortItemItem(short templateId, string[] names)
	{
		TemplateId = templateId;
		Names = names;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SortItemItem()
	{
		TemplateId = 0;
		Names = new string[2]
		{
			string.Empty,
			string.Empty
		};
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public SortItemItem(short templateId, SortItemItem other)
	{
		TemplateId = templateId;
		Names = other.Names;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SortItemItem Duplicate(int templateId)
	{
		return new SortItemItem((short)templateId, this);
	}
}
