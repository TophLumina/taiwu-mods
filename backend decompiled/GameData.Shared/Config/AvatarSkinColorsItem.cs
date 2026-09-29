using System;
using Config.Common;

namespace Config;

[Serializable]
public class AvatarSkinColorsItem : ConfigItem<AvatarSkinColorsItem, byte>
{
	public readonly byte TemplateId;

	public readonly string ColorHex;

	public readonly byte ObbCn;

	public readonly byte ObbChn;

	public readonly byte ObbJp;

	public readonly byte ObbEn;

	public readonly string DisplayDesc;

	public AvatarSkinColorsItem(byte templateId, string colorHex, byte obbCn, byte obbChn, byte obbJp, byte obbEn, string displayDesc)
	{
		TemplateId = templateId;
		ColorHex = colorHex;
		ObbCn = obbCn;
		ObbChn = obbChn;
		ObbJp = obbJp;
		ObbEn = obbEn;
		DisplayDesc = displayDesc;
	}

	public AvatarSkinColorsItem()
	{
		TemplateId = 0;
		ColorHex = null;
		ObbCn = 0;
		ObbChn = 0;
		ObbJp = 0;
		ObbEn = 0;
		DisplayDesc = null;
	}

	public AvatarSkinColorsItem(byte templateId, AvatarSkinColorsItem other)
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

	public override AvatarSkinColorsItem Duplicate(int templateId)
	{
		return new AvatarSkinColorsItem((byte)templateId, this);
	}
}
