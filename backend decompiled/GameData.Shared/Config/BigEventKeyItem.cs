using System;
using Config.Common;

namespace Config;

[Serializable]
public class BigEventKeyItem : ConfigItem<BigEventKeyItem, short>
{
	public readonly short TemplateId;

	public BigEventKeyItem(short templateId)
	{
		TemplateId = templateId;
	}

	public BigEventKeyItem()
	{
		TemplateId = 0;
	}

	public BigEventKeyItem(short templateId, BigEventKeyItem other)
	{
		TemplateId = templateId;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override BigEventKeyItem Duplicate(int templateId)
	{
		return new BigEventKeyItem((short)templateId, this);
	}
}
