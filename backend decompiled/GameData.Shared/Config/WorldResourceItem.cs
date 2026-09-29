using System;
using Config.Common;

namespace Config;

[Serializable]
public class WorldResourceItem : ConfigItem<WorldResourceItem, byte>
{
	public readonly byte TemplateId;

	public readonly short[] InfluenceFactors;

	public WorldResourceItem(byte templateId, short[] influenceFactors)
	{
		TemplateId = templateId;
		InfluenceFactors = influenceFactors;
	}

	public WorldResourceItem()
	{
		TemplateId = 0;
		InfluenceFactors = new short[0];
	}

	public WorldResourceItem(byte templateId, WorldResourceItem other)
	{
		TemplateId = templateId;
		InfluenceFactors = other.InfluenceFactors;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override WorldResourceItem Duplicate(int templateId)
	{
		return new WorldResourceItem((byte)templateId, this);
	}
}
