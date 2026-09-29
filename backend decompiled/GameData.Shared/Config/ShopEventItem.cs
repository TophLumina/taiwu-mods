using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells.Character;

namespace Config;

[Serializable]
public class ShopEventItem : ConfigItem<ShopEventItem, short>
{
	public readonly short TemplateId;

	public readonly string Desc;

	public readonly string[] Parameters;

	public readonly sbyte SkillGrowOdds;

	public readonly List<sbyte> ResourceList;

	public readonly sbyte ResourceGoods;

	public readonly List<PresetInventoryItem> ItemList;

	public readonly short BuildingCore;

	public readonly List<sbyte> ItemGradeProbList;

	public readonly sbyte LearnLifeSkillProb;

	public readonly sbyte LearnCombatSkillProb;

	public readonly sbyte ExchangeResourceGoods;

	public readonly List<sbyte> RecruitPeopleProb;

	public readonly List<sbyte> RecruitPeopleProbAdd;

	public readonly List<sbyte> AttainmentFix;

	public readonly short CharacterPropertyFix;

	public readonly List<short> CharacterPropertyFixNum;

	public readonly sbyte ShopEventType;

	public readonly sbyte Priority;

	public ShopEventItem(short templateId, string desc, string[] parameters, sbyte skillGrowOdds, List<sbyte> resourceList, sbyte resourceGoods, List<PresetInventoryItem> itemList, short buildingCore, List<sbyte> itemGradeProbList, sbyte learnLifeSkillProb, sbyte learnCombatSkillProb, sbyte exchangeResourceGoods, List<sbyte> recruitPeopleProb, List<sbyte> recruitPeopleProbAdd, List<sbyte> attainmentFix, short characterPropertyFix, List<short> characterPropertyFixNum, sbyte shopEventType, sbyte priority)
	{
		TemplateId = templateId;
		Desc = desc;
		Parameters = parameters;
		SkillGrowOdds = skillGrowOdds;
		ResourceList = resourceList;
		ResourceGoods = resourceGoods;
		ItemList = itemList;
		BuildingCore = buildingCore;
		ItemGradeProbList = itemGradeProbList;
		LearnLifeSkillProb = learnLifeSkillProb;
		LearnCombatSkillProb = learnCombatSkillProb;
		ExchangeResourceGoods = exchangeResourceGoods;
		RecruitPeopleProb = recruitPeopleProb;
		RecruitPeopleProbAdd = recruitPeopleProbAdd;
		AttainmentFix = attainmentFix;
		CharacterPropertyFix = characterPropertyFix;
		CharacterPropertyFixNum = characterPropertyFixNum;
		ShopEventType = shopEventType;
		Priority = priority;
	}

	public ShopEventItem()
	{
		TemplateId = 0;
		Desc = null;
		Parameters = new string[6] { "", "", "", "", "", "" };
		SkillGrowOdds = 0;
		ResourceList = new List<sbyte>();
		ResourceGoods = 0;
		ItemList = new List<PresetInventoryItem>();
		BuildingCore = 0;
		ItemGradeProbList = new List<sbyte>();
		LearnLifeSkillProb = 0;
		LearnCombatSkillProb = 0;
		ExchangeResourceGoods = 0;
		RecruitPeopleProb = new List<sbyte>();
		RecruitPeopleProbAdd = new List<sbyte>();
		AttainmentFix = new List<sbyte>();
		CharacterPropertyFix = 0;
		CharacterPropertyFixNum = new List<short>();
		ShopEventType = 0;
		Priority = 0;
	}

	public ShopEventItem(short templateId, ShopEventItem other)
	{
		TemplateId = templateId;
		Desc = other.Desc;
		Parameters = other.Parameters;
		SkillGrowOdds = other.SkillGrowOdds;
		ResourceList = other.ResourceList;
		ResourceGoods = other.ResourceGoods;
		ItemList = other.ItemList;
		BuildingCore = other.BuildingCore;
		ItemGradeProbList = other.ItemGradeProbList;
		LearnLifeSkillProb = other.LearnLifeSkillProb;
		LearnCombatSkillProb = other.LearnCombatSkillProb;
		ExchangeResourceGoods = other.ExchangeResourceGoods;
		RecruitPeopleProb = other.RecruitPeopleProb;
		RecruitPeopleProbAdd = other.RecruitPeopleProbAdd;
		AttainmentFix = other.AttainmentFix;
		CharacterPropertyFix = other.CharacterPropertyFix;
		CharacterPropertyFixNum = other.CharacterPropertyFixNum;
		ShopEventType = other.ShopEventType;
		Priority = other.Priority;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override ShopEventItem Duplicate(int templateId)
	{
		return new ShopEventItem((short)templateId, this);
	}
}
