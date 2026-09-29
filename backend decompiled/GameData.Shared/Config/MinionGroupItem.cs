using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MinionGroupItem : ConfigItem<MinionGroupItem, short>
{
	public readonly short TemplateId;

	public readonly List<short> Minions;

	public MinionGroupItem(short templateId, List<short> minions)
	{
		TemplateId = templateId;
		Minions = minions;
	}

	public MinionGroupItem()
	{
		TemplateId = 0;
		Minions = new List<short>();
	}

	public MinionGroupItem(short templateId, MinionGroupItem other)
	{
		TemplateId = templateId;
		Minions = other.Minions;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override MinionGroupItem Duplicate(int templateId)
	{
		return new MinionGroupItem((short)templateId, this);
	}
}
