using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class LuohanItem : ConfigItem<LuohanItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly short Accessory;

	public readonly ELuohanBonusType BonusType;

	public readonly List<short> Medicine;

	public readonly short Material;

	public LuohanItem(sbyte templateId, string name, short accessory, ELuohanBonusType bonusType, List<short> medicine, short material)
	{
		TemplateId = templateId;
		Name = name;
		Accessory = accessory;
		BonusType = bonusType;
		Medicine = medicine;
		Material = material;
	}

	public LuohanItem()
	{
		TemplateId = 0;
		Name = null;
		Accessory = 0;
		BonusType = ELuohanBonusType.Invalid;
		Medicine = null;
		Material = 0;
	}

	public LuohanItem(sbyte templateId, LuohanItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Accessory = other.Accessory;
		BonusType = other.BonusType;
		Medicine = other.Medicine;
		Material = other.Material;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override LuohanItem Duplicate(int templateId)
	{
		return new LuohanItem((sbyte)templateId, this);
	}
}
