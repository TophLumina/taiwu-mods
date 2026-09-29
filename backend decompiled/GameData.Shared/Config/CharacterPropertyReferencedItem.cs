using System;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterPropertyReferencedItem : ConfigItem<CharacterPropertyReferencedItem, short>
{
	public readonly short TemplateId;

	public readonly ECharacterPropertyReferencedType Type;

	public readonly short DisplayType;

	public readonly bool BoostedByPower;

	public readonly bool FeatureStandardIsAdd;

	public readonly bool LegendaryBookIsAdd;

	public readonly bool IsMonthly;

	public CharacterPropertyReferencedItem(short templateId, ECharacterPropertyReferencedType type, short displayType, bool boostedByPower, bool featureStandardIsAdd, bool legendaryBookIsAdd, bool isMonthly)
	{
		TemplateId = templateId;
		Type = type;
		DisplayType = displayType;
		BoostedByPower = boostedByPower;
		FeatureStandardIsAdd = featureStandardIsAdd;
		LegendaryBookIsAdd = legendaryBookIsAdd;
		IsMonthly = isMonthly;
	}

	public CharacterPropertyReferencedItem()
	{
		TemplateId = 0;
		Type = ECharacterPropertyReferencedType.Strength;
		DisplayType = 0;
		BoostedByPower = false;
		FeatureStandardIsAdd = true;
		LegendaryBookIsAdd = true;
		IsMonthly = false;
	}

	public CharacterPropertyReferencedItem(short templateId, CharacterPropertyReferencedItem other)
	{
		TemplateId = templateId;
		Type = other.Type;
		DisplayType = other.DisplayType;
		BoostedByPower = other.BoostedByPower;
		FeatureStandardIsAdd = other.FeatureStandardIsAdd;
		LegendaryBookIsAdd = other.LegendaryBookIsAdd;
		IsMonthly = other.IsMonthly;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override CharacterPropertyReferencedItem Duplicate(int templateId)
	{
		return new CharacterPropertyReferencedItem((short)templateId, this);
	}
}
