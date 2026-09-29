using System;
using Config.Common;

namespace Config;

[Serializable]
public class DebateStrategyEffectItem : ConfigItem<DebateStrategyEffectItem, short>
{
	public readonly short TemplateId;

	public DebateStrategyEffectItem(short templateId)
	{
		TemplateId = templateId;
	}

	public DebateStrategyEffectItem()
	{
		TemplateId = 0;
	}

	public DebateStrategyEffectItem(short templateId, DebateStrategyEffectItem other)
	{
		TemplateId = templateId;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override DebateStrategyEffectItem Duplicate(int templateId)
	{
		return new DebateStrategyEffectItem((short)templateId, this);
	}
}
