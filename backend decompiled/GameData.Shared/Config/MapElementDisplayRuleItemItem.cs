using System;
using Config.Common;

namespace Config;

[Serializable]
public class MapElementDisplayRuleItemItem : ConfigItem<MapElementDisplayRuleItemItem, short>
{
	public readonly short TemplateId;

	public readonly short Group;

	public readonly string Name;

	public readonly string Color;

	public readonly int Order;

	public readonly sbyte MerchantType;

	public readonly string Icon;

	public readonly string BlockInfoIcon;

	public readonly EMapElementDisplayRuleItemPoisionType PoisionType;

	public readonly EMapElementDisplayRuleItemCharacterCountGroup CharacterCountGroup;

	public readonly EMapElementDisplayRuleItemCharacterCountGroupDisplay CharacterCountGroupDisplay;

	public MapElementDisplayRuleItemItem(short templateId, short group, string name, string color, int order, sbyte merchantType, string icon, string blockInfoIcon, EMapElementDisplayRuleItemPoisionType poisionType, EMapElementDisplayRuleItemCharacterCountGroup characterCountGroup, EMapElementDisplayRuleItemCharacterCountGroupDisplay characterCountGroupDisplay)
	{
		TemplateId = templateId;
		Group = group;
		Name = name;
		Color = color;
		Order = order;
		MerchantType = merchantType;
		Icon = icon;
		BlockInfoIcon = blockInfoIcon;
		PoisionType = poisionType;
		CharacterCountGroup = characterCountGroup;
		CharacterCountGroupDisplay = characterCountGroupDisplay;
	}

	public MapElementDisplayRuleItemItem()
	{
		TemplateId = 0;
		Group = 0;
		Name = null;
		Color = "pinkyellow";
		Order = 0;
		MerchantType = 0;
		Icon = null;
		BlockInfoIcon = null;
		PoisionType = EMapElementDisplayRuleItemPoisionType.Right;
		CharacterCountGroup = EMapElementDisplayRuleItemCharacterCountGroup.Invalid;
		CharacterCountGroupDisplay = EMapElementDisplayRuleItemCharacterCountGroupDisplay.Invalid;
	}

	public MapElementDisplayRuleItemItem(short templateId, MapElementDisplayRuleItemItem other)
	{
		TemplateId = templateId;
		Group = other.Group;
		Name = other.Name;
		Color = other.Color;
		Order = other.Order;
		MerchantType = other.MerchantType;
		Icon = other.Icon;
		BlockInfoIcon = other.BlockInfoIcon;
		PoisionType = other.PoisionType;
		CharacterCountGroup = other.CharacterCountGroup;
		CharacterCountGroupDisplay = other.CharacterCountGroupDisplay;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override MapElementDisplayRuleItemItem Duplicate(int templateId)
	{
		return new MapElementDisplayRuleItemItem((short)templateId, this);
	}
}
