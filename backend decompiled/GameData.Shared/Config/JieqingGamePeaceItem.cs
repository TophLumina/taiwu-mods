using System;
using Config.Common;

namespace Config;

[Serializable]
public class JieqingGamePeaceItem : ConfigItem<JieqingGamePeaceItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string Color;

	public readonly sbyte Width;

	public readonly sbyte Height;

	public readonly bool[] Shape;

	public readonly sbyte ArtResourceIndex;

	public JieqingGamePeaceItem(short templateId, string name, string color, sbyte width, sbyte height, bool[] shape, sbyte artResourceIndex)
	{
		TemplateId = templateId;
		Name = name;
		Color = color;
		Width = width;
		Height = height;
		Shape = shape;
		ArtResourceIndex = artResourceIndex;
	}

	public JieqingGamePeaceItem()
	{
		TemplateId = 0;
		Name = null;
		Color = null;
		Width = 0;
		Height = 0;
		Shape = null;
		ArtResourceIndex = 0;
	}

	public JieqingGamePeaceItem(short templateId, JieqingGamePeaceItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Color = other.Color;
		Width = other.Width;
		Height = other.Height;
		Shape = other.Shape;
		ArtResourceIndex = other.ArtResourceIndex;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override JieqingGamePeaceItem Duplicate(int templateId)
	{
		return new JieqingGamePeaceItem((short)templateId, this);
	}
}
