using System;
using Config.Common;

namespace Config;

[Serializable]
public class AdventureRemakeMapBlockItem : ConfigItem<AdventureRemakeMapBlockItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly int CircleCount;

	public readonly float[] CircleHeight;

	public readonly int FlatPercentage;

	public readonly float[] FlatHeight;

	public AdventureRemakeMapBlockItem(short templateId, string name, string desc, int circleCount, float[] circleHeight, int flatPercentage, float[] flatHeight)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		CircleCount = circleCount;
		CircleHeight = circleHeight;
		FlatPercentage = flatPercentage;
		FlatHeight = flatHeight;
	}

	public AdventureRemakeMapBlockItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		CircleCount = 0;
		CircleHeight = new float[10] { 0f, 0.1f, 0.1f, 0.2f, 0.3f, 0.4f, 0.4f, 0.6f, 0.4f, 0.6f };
		FlatPercentage = -1;
		FlatHeight = new float[2] { 0.5f, 0.5f };
	}

	public AdventureRemakeMapBlockItem(short templateId, AdventureRemakeMapBlockItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		CircleCount = other.CircleCount;
		CircleHeight = other.CircleHeight;
		FlatPercentage = other.FlatPercentage;
		FlatHeight = other.FlatHeight;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override AdventureRemakeMapBlockItem Duplicate(int templateId)
	{
		return new AdventureRemakeMapBlockItem((short)templateId, this);
	}
}
