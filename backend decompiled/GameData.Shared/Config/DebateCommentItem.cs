using System;
using Config.Common;

namespace Config;

[Serializable]
public class DebateCommentItem : ConfigItem<DebateCommentItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly string ResultTip;

	public readonly string BubbleContent;

	public readonly sbyte BehaviorType;

	public readonly short[] Happiness;

	public readonly short Favor;

	public readonly bool IsPositive;

	public readonly short Negation;

	public readonly int CheckValue;

	public DebateCommentItem(short templateId, string name, string desc, string resultTip, string bubbleContent, sbyte behaviorType, short[] happiness, short favor, bool isPositive, short negation, int checkValue)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		ResultTip = resultTip;
		BubbleContent = bubbleContent;
		BehaviorType = behaviorType;
		Happiness = happiness;
		Favor = favor;
		IsPositive = isPositive;
		Negation = negation;
		CheckValue = checkValue;
	}

	public DebateCommentItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		ResultTip = null;
		BubbleContent = null;
		BehaviorType = 0;
		Happiness = new short[5];
		Favor = 0;
		IsPositive = false;
		Negation = 0;
		CheckValue = 0;
	}

	public DebateCommentItem(short templateId, DebateCommentItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		ResultTip = other.ResultTip;
		BubbleContent = other.BubbleContent;
		BehaviorType = other.BehaviorType;
		Happiness = other.Happiness;
		Favor = other.Favor;
		IsPositive = other.IsPositive;
		Negation = other.Negation;
		CheckValue = other.CheckValue;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override DebateCommentItem Duplicate(int templateId)
	{
		return new DebateCommentItem((short)templateId, this);
	}
}
