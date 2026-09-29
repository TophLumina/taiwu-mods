using System;
using Config.Common;

namespace Config;

[Serializable]
public class BlockButtonItem : ConfigItem<BlockButtonItem, byte>
{
	public readonly byte TemplateId;

	public readonly string Name;

	public readonly string Summary;

	public readonly string Desc;

	public readonly short TimeConsume;

	public readonly string TimeConsumeDesc;

	public BlockButtonItem(byte templateId, string name, string summary, string desc, short timeConsume, string timeConsumeDesc)
	{
		TemplateId = templateId;
		Name = name;
		Summary = summary;
		Desc = desc;
		TimeConsume = timeConsume;
		TimeConsumeDesc = timeConsumeDesc;
	}

	public BlockButtonItem()
	{
		TemplateId = 0;
		Name = null;
		Summary = null;
		Desc = null;
		TimeConsume = -1;
		TimeConsumeDesc = null;
	}

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

	public override BlockButtonItem Duplicate(int templateId)
	{
		return new BlockButtonItem((byte)templateId, this);
	}
}
