using System;
using Config.Common;

namespace Config;

[Serializable]
public class AvatarHairColorsItem : ConfigItem<AvatarHairColorsItem, byte>
{
	public readonly byte TemplateId;

	public readonly string ColorHex;

	public readonly byte ObbCn;

	public readonly byte ObbChn;

	public readonly byte ObbJp;

	public readonly byte ObbEn;

	public readonly string DisplayDesc;

	public AvatarHairColorsItem(byte templateId, string colorHex, byte obbCn, byte obbChn, byte obbJp, byte obbEn, string displayDesc)
	{
		TemplateId = templateId;
		ColorHex = colorHex;
		ObbCn = obbCn;
		ObbChn = obbChn;
		ObbJp = obbJp;
		ObbEn = obbEn;
		DisplayDesc = displayDesc;
	}

	public AvatarHairColorsItem()
	{
		TemplateId = 0;
		ColorHex = null;
		ObbCn = 0;
		ObbChn = 0;
		ObbJp = 0;
		ObbEn = 0;
		DisplayDesc = null;
	}

	public AvatarHairColorsItem(byte templateId, AvatarHairColorsItem other)
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

	public override AvatarHairColorsItem Duplicate(int templateId)
	{
		return new AvatarHairColorsItem((byte)templateId, this);
	}
}
