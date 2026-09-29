using System;
using Config.Common;

namespace Config;

[Serializable]
public class DebateStrategyTargetItem : ConfigItem<DebateStrategyTargetItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly EDebateStrategyTargetObjectType ObjectType;

	public DebateStrategyTargetItem(short templateId, string name, EDebateStrategyTargetObjectType objectType)
	{
		TemplateId = templateId;
		Name = name;
		ObjectType = objectType;
	}

	public DebateStrategyTargetItem()
	{
		TemplateId = 0;
		Name = null;
		ObjectType = EDebateStrategyTargetObjectType.Invalid;
	}

	public DebateStrategyTargetItem(short templateId, DebateStrategyTargetItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		ObjectType = other.ObjectType;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override DebateStrategyTargetItem Duplicate(int templateId)
	{
		return new DebateStrategyTargetItem((short)templateId, this);
	}
}
