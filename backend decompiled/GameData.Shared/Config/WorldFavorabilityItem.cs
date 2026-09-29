using System;
using Config.Common;

namespace Config;

[Serializable]
public class WorldFavorabilityItem : ConfigItem<WorldFavorabilityItem, short>
{
	public readonly short TemplateId;

	public readonly short[] InfluenceFactors;

	public readonly bool NegativeUsingReciprocal;

	public WorldFavorabilityItem(short templateId, short[] influenceFactors, bool negativeUsingReciprocal)
	{
		TemplateId = templateId;
		InfluenceFactors = influenceFactors;
		NegativeUsingReciprocal = negativeUsingReciprocal;
	}

	public WorldFavorabilityItem()
	{
		TemplateId = 0;
		InfluenceFactors = new short[0];
		NegativeUsingReciprocal = true;
	}

	public WorldFavorabilityItem(short templateId, WorldFavorabilityItem other)
	{
		TemplateId = templateId;
		InfluenceFactors = other.InfluenceFactors;
		NegativeUsingReciprocal = other.NegativeUsingReciprocal;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override WorldFavorabilityItem Duplicate(int templateId)
	{
		return new WorldFavorabilityItem((short)templateId, this);
	}
}
