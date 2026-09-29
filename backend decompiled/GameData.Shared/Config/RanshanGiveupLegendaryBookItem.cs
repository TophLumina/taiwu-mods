using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class RanshanGiveupLegendaryBookItem : ConfigItem<RanshanGiveupLegendaryBookItem, byte>
{
	public readonly byte TemplateId;

	public readonly sbyte ResourceType;

	public readonly int ExpCost;

	public readonly int ResourceCost;

	public readonly int FollowDuration;

	public readonly int ResponseCycle;

	public readonly int MoodChange;

	public readonly List<sbyte> JudgeAttribute;

	public RanshanGiveupLegendaryBookItem(byte templateId, sbyte resourceType, int expCost, int resourceCost, int followDuration, int responseCycle, int moodChange, List<sbyte> judgeAttribute)
	{
		TemplateId = templateId;
		ResourceType = resourceType;
		ExpCost = expCost;
		ResourceCost = resourceCost;
		FollowDuration = followDuration;
		ResponseCycle = responseCycle;
		MoodChange = moodChange;
		JudgeAttribute = judgeAttribute;
	}

	public RanshanGiveupLegendaryBookItem()
	{
		TemplateId = 0;
		ResourceType = 0;
		ExpCost = 0;
		ResourceCost = 0;
		FollowDuration = 0;
		ResponseCycle = 0;
		MoodChange = 0;
		JudgeAttribute = null;
	}

	public RanshanGiveupLegendaryBookItem(byte templateId, RanshanGiveupLegendaryBookItem other)
	{
		TemplateId = templateId;
		ResourceType = other.ResourceType;
		ExpCost = other.ExpCost;
		ResourceCost = other.ResourceCost;
		FollowDuration = other.FollowDuration;
		ResponseCycle = other.ResponseCycle;
		MoodChange = other.MoodChange;
		JudgeAttribute = other.JudgeAttribute;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override RanshanGiveupLegendaryBookItem Duplicate(int templateId)
	{
		return new RanshanGiveupLegendaryBookItem((byte)templateId, this);
	}
}
