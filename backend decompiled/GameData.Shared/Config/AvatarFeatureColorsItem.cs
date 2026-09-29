using System;
using Config.Common;

namespace Config;

[Serializable]
public class AvatarFeatureColorsItem : ConfigItem<AvatarFeatureColorsItem, byte>
{
	public readonly byte TemplateId;

	public readonly string ColorHex;

	public readonly byte ObbCn;

	public readonly byte ObbChn;

	public readonly byte ObbJp;

	public readonly byte ObbEn;

	public readonly string DisplayDesc;

	public AvatarFeatureColorsItem(byte templateId, string colorHex, byte obbCn, byte obbChn, byte obbJp, byte obbEn, string displayDesc)
	{
		TemplateId = templateId;
		ColorHex = colorHex;
		ObbCn = obbCn;
		ObbChn = obbChn;
		ObbJp = obbJp;
		ObbEn = obbEn;
		DisplayDesc = displayDesc;
	}

	public AvatarFeatureColorsItem()
	{
		TemplateId = 0;
		ColorHex = null;
		ObbCn = 0;
		ObbChn = 0;
		ObbJp = 0;
		ObbEn = 0;
		DisplayDesc = null;
	}

	public AvatarFeatureColorsItem(byte templateId, AvatarFeatureColorsItem other)
	{
		TemplateId = templateId;
		ColorHex = other.ColorHex;
		ObbCn = other.ObbCn;
		ObbChn = other.ObbChn;
		ObbJp = other.ObbJp;
		ObbEn = other.ObbEn;
		DisplayDesc = other.DisplayDesc;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override AvatarFeatureColorsItem Duplicate(int templateId)
	{
		return new AvatarFeatureColorsItem((byte)templateId, this);
	}
}
