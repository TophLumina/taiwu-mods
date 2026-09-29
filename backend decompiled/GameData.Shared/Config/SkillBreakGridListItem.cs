using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SkillBreakGridListItem : ConfigItem<SkillBreakGridListItem, short>
{
	public readonly short TemplateId;

	public readonly List<BreakGrid> BreakGridListJust;

	public readonly List<BreakGrid> BreakGridListKind;

	public readonly List<BreakGrid> BreakGridListEven;

	public readonly List<BreakGrid> BreakGridListRebel;

	public readonly List<BreakGrid> BreakGridListEgoistic;

	public SkillBreakGridListItem(short templateId, List<BreakGrid> breakGridListJust, List<BreakGrid> breakGridListKind, List<BreakGrid> breakGridListEven, List<BreakGrid> breakGridListRebel, List<BreakGrid> breakGridListEgoistic)
	{
		TemplateId = templateId;
		BreakGridListJust = breakGridListJust;
		BreakGridListKind = breakGridListKind;
		BreakGridListEven = breakGridListEven;
		BreakGridListRebel = breakGridListRebel;
		BreakGridListEgoistic = breakGridListEgoistic;
	}

	public SkillBreakGridListItem()
	{
		TemplateId = 0;
		BreakGridListJust = new List<BreakGrid>();
		BreakGridListKind = new List<BreakGrid>();
		BreakGridListEven = new List<BreakGrid>();
		BreakGridListRebel = new List<BreakGrid>();
		BreakGridListEgoistic = new List<BreakGrid>();
	}

	public SkillBreakGridListItem(short templateId, SkillBreakGridListItem other)
	{
		TemplateId = templateId;
		BreakGridListJust = other.BreakGridListJust;
		BreakGridListKind = other.BreakGridListKind;
		BreakGridListEven = other.BreakGridListEven;
		BreakGridListRebel = other.BreakGridListRebel;
		BreakGridListEgoistic = other.BreakGridListEgoistic;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SkillBreakGridListItem Duplicate(int templateId)
	{
		return new SkillBreakGridListItem((short)templateId, this);
	}
}
