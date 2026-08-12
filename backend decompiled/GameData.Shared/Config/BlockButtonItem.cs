using System;
using Config.Common;

namespace Config;

[Serializable]
public class BlockButtonItem : ConfigItem<BlockButtonItem, byte>
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
	/// 精力消耗
	/// - 仅显示，实际消耗在其他代码中控制
	/// </summary>
	public readonly short TimeConsume;

	/// <summary>
	/// 精力消耗提示
	/// </summary>
	public readonly string TimeConsumeDesc;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">按钮名称</param>
	/// <param name="summary">简单描述</param>
	/// <param name="desc">详细描述</param>
	/// <param name="timeConsume">精力消耗 - 仅显示，实际消耗在其他代码中控制</param>
	/// <param name="timeConsumeDesc">精力消耗提示</param>
	public BlockButtonItem(byte templateId, string name, string summary, string desc, short timeConsume, string timeConsumeDesc)
	{
		TemplateId = templateId;
		Name = name;
		Summary = summary;
		Desc = desc;
		TimeConsume = timeConsume;
		TimeConsumeDesc = timeConsumeDesc;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public BlockButtonItem()
	{
		TemplateId = 0;
		Name = null;
		Summary = null;
		Desc = null;
		TimeConsume = -1;
		TimeConsumeDesc = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public BlockButtonItem(byte templateId, BlockButtonItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Summary = other.Summary;
		Desc = other.Desc;
		TimeConsume = other.TimeConsume;
		TimeConsumeDesc = other.TimeConsumeDesc;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override BlockButtonItem Duplicate(int templateId)
	{
		return new BlockButtonItem((byte)templateId, this);
	}
}
