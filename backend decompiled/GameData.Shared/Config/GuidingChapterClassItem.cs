using System;
using Config.Common;

namespace Config;

[Serializable]
public class GuidingChapterClassItem : ConfigItem<GuidingChapterClassItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public GuidingChapterClassItem(short templateId, string name)
	{
		TemplateId = templateId;
		Name = name;
	}

	public GuidingChapterClassItem()
	{
		TemplateId = 0;
		Name = null;
	}

	public GuidingChapterClassItem(short templateId, GuidingChapterClassItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override GuidingChapterClassItem Duplicate(int templateId)
	{
		return new GuidingChapterClassItem((short)templateId, this);
	}
}
