using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class GuidingChapterTriggerItem : ConfigItem<GuidingChapterTriggerItem, short>
{
	public readonly short TemplateId;

	public readonly List<short> Chapters;

	public readonly int Int1;

	public GuidingChapterTriggerItem(short templateId, List<short> chapters, int int1)
	{
		TemplateId = templateId;
		Chapters = chapters;
		Int1 = int1;
	}

	public GuidingChapterTriggerItem()
	{
		TemplateId = 0;
		Chapters = new List<short>();
		Int1 = 0;
	}

	public GuidingChapterTriggerItem(short templateId, GuidingChapterTriggerItem other)
	{
		TemplateId = templateId;
		Chapters = other.Chapters;
		Int1 = other.Int1;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override GuidingChapterTriggerItem Duplicate(int templateId)
	{
		return new GuidingChapterTriggerItem((short)templateId, this);
	}
}
