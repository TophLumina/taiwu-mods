using System;
using Config.Common;

namespace Config;

[Serializable]
public class SortItemItem : ConfigItem<SortItemItem, short>
{
	public readonly short TemplateId;

	public readonly string[] Names;

	public SortItemItem(short templateId, string[] names)
	{
		TemplateId = templateId;
		Names = names;
	}

	public SortItemItem()
	{
		TemplateId = 0;
		Names = new string[2]
		{
			string.Empty,
			string.Empty
		};
	}

	public SortItemItem(short templateId, SortItemItem other)
	{
		TemplateId = templateId;
		Names = other.Names;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SortItemItem Duplicate(int templateId)
	{
		return new SortItemItem((short)templateId, this);
	}
}
