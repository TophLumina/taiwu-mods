using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class JiaoItem : ConfigItem<JiaoItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly int Length;

	public readonly int Weight;

	public readonly int Life;

	public readonly sbyte TravelTimeReduction;

	public readonly short MaxInventoryLoadBonus;

	public readonly short BaseMaxKidnapSlotAbilityBonus;

	public readonly short BaseDropRateBonus;

	public readonly short BaseCaptureRateBonus;

	public readonly short ExploreBonusRate;

	public readonly int BasePrice;

	public readonly int BaseValue;

	public readonly sbyte BaseHappinessChange;

	public readonly int BaseFavorabilityChange;

	public readonly sbyte GiftLevel;

	public readonly short AdvantageProperty;

	public readonly int AdvantagePropertyValue;

	public readonly int MonthlyEventCost;

	public readonly List<string> ColorList;

	public readonly short IndexOfCharacterTemplate;

	public readonly short IndexOfCarrierTemplate;

	public readonly sbyte IndexOfAnimalTemplate;

	public readonly short EggMaterial;

	public readonly short TeenagerMaterial;

	public readonly string ShadowImage;

	public readonly string BellowSound;

	public JiaoItem(short templateId, string name, int length, int weight, int life, sbyte travelTimeReduction, short maxInventoryLoadBonus, short baseMaxKidnapSlotAbilityBonus, short baseDropRateBonus, short baseCaptureRateBonus, short exploreBonusRate, int basePrice, int baseValue, sbyte baseHappinessChange, int baseFavorabilityChange, sbyte giftLevel, short advantageProperty, int advantagePropertyValue, int monthlyEventCost, List<string> colorList, short indexOfCharacterTemplate, short indexOfCarrierTemplate, sbyte indexOfAnimalTemplate, short eggMaterial, short teenagerMaterial, string shadowImage, string bellowSound)
	{
		TemplateId = templateId;
		Name = name;
		Length = length;
		Weight = weight;
		Life = life;
		TravelTimeReduction = travelTimeReduction;
		MaxInventoryLoadBonus = maxInventoryLoadBonus;
		BaseMaxKidnapSlotAbilityBonus = baseMaxKidnapSlotAbilityBonus;
		BaseDropRateBonus = baseDropRateBonus;
		BaseCaptureRateBonus = baseCaptureRateBonus;
		ExploreBonusRate = exploreBonusRate;
		BasePrice = basePrice;
		BaseValue = baseValue;
		BaseHappinessChange = baseHappinessChange;
		BaseFavorabilityChange = baseFavorabilityChange;
		GiftLevel = giftLevel;
		AdvantageProperty = advantageProperty;
		AdvantagePropertyValue = advantagePropertyValue;
		MonthlyEventCost = monthlyEventCost;
		ColorList = colorList;
		IndexOfCharacterTemplate = indexOfCharacterTemplate;
		IndexOfCarrierTemplate = indexOfCarrierTemplate;
		IndexOfAnimalTemplate = indexOfAnimalTemplate;
		EggMaterial = eggMaterial;
		TeenagerMaterial = teenagerMaterial;
		ShadowImage = shadowImage;
		BellowSound = bellowSound;
	}

	public JiaoItem()
	{
		TemplateId = 0;
		Name = null;
		Length = -1;
		Weight = -1;
		Life = -1;
		TravelTimeReduction = -1;
		MaxInventoryLoadBonus = -1;
		BaseMaxKidnapSlotAbilityBonus = 0;
		BaseDropRateBonus = -1;
		BaseCaptureRateBonus = -1;
		ExploreBonusRate = 0;
		BasePrice = 0;
		BaseValue = 0;
		BaseHappinessChange = 0;
		BaseFavorabilityChange = 0;
		GiftLevel = 8;
		AdvantageProperty = 0;
		AdvantagePropertyValue = 0;
		MonthlyEventCost = 0;
		ColorList = new List<string> { "" };
		IndexOfCharacterTemplate = 0;
		IndexOfCarrierTemplate = 0;
		IndexOfAnimalTemplate = 0;
		EggMaterial = 0;
		TeenagerMaterial = 0;
		ShadowImage = null;
		BellowSound = null;
	}

	public JiaoItem(short templateId, JiaoItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Length = other.Length;
		Weight = other.Weight;
		Life = other.Life;
		TravelTimeReduction = other.TravelTimeReduction;
		MaxInventoryLoadBonus = other.MaxInventoryLoadBonus;
		BaseMaxKidnapSlotAbilityBonus = other.BaseMaxKidnapSlotAbilityBonus;
		BaseDropRateBonus = other.BaseDropRateBonus;
		BaseCaptureRateBonus = other.BaseCaptureRateBonus;
		ExploreBonusRate = other.ExploreBonusRate;
		BasePrice = other.BasePrice;
		BaseValue = other.BaseValue;
		BaseHappinessChange = other.BaseHappinessChange;
		BaseFavorabilityChange = other.BaseFavorabilityChange;
		GiftLevel = other.GiftLevel;
		AdvantageProperty = other.AdvantageProperty;
		AdvantagePropertyValue = other.AdvantagePropertyValue;
		MonthlyEventCost = other.MonthlyEventCost;
		ColorList = other.ColorList;
		IndexOfCharacterTemplate = other.IndexOfCharacterTemplate;
		IndexOfCarrierTemplate = other.IndexOfCarrierTemplate;
		IndexOfAnimalTemplate = other.IndexOfAnimalTemplate;
		EggMaterial = other.EggMaterial;
		TeenagerMaterial = other.TeenagerMaterial;
		ShadowImage = other.ShadowImage;
		BellowSound = other.BellowSound;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override JiaoItem Duplicate(int templateId)
	{
		return new JiaoItem((short)templateId, this);
	}
}
