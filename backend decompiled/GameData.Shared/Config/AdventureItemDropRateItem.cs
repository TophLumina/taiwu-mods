using System;
using Config.Common;

namespace Config;

[Serializable]
public class AdventureItemDropRateItem : ConfigItem<AdventureItemDropRateItem, byte>
{
	public readonly byte TemplateId;

	public readonly short[] ItemGradeDropRate;

	public AdventureItemDropRateItem(byte templateId, short[] itemGradeDropRate)
	{
		TemplateId = templateId;
		ItemGradeDropRate = itemGradeDropRate;
	}

	public AdventureItemDropRateItem()
	{
		TemplateId = 0;
		ItemGradeDropRate = null;
	}

	public AdventureItemDropRateItem(byte templateId, AdventureItemDropRateItem other)
	{
		TemplateId = templateId;
		ItemGradeDropRate = other.ItemGradeDropRate;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override AdventureItemDropRateItem Duplicate(int templateId)
	{
		return new AdventureItemDropRateItem((byte)templateId, this);
	}
}
