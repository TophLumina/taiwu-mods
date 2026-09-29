using System;
using System.Collections.Generic;
using GameData.Utilities;

namespace GameData.Domains.LifeRecord.GeneralRecord;

public class RenderedArgumentCollection
{
	public readonly List<string> Characters;

	public readonly List<string> Locations;

	public readonly List<string> Items;

	public readonly List<string> CombatSkills;

	public readonly List<string> Resources;

	public readonly List<string> Settlements;

	public readonly List<string> OrgGrades;

	public readonly List<string> Buildings;

	public readonly List<string> SwordTombs;

	public readonly List<string> JuniorXiangshuList;

	public readonly List<string> Adventures;

	public readonly List<string> BehaviorTypes;

	public readonly List<string> FavorabilityTypes;

	public readonly List<string> Crickets;

	public readonly List<string> ItemSubTypes;

	public readonly List<string> Chickens;

	public readonly List<string> CharacterPropertyReferencedTypes;

	public readonly List<string> BodyPartTypes;

	public readonly List<string> InjuryTypes;

	public readonly List<string> PoisonTypes;

	public readonly List<string> CharacterTemplates;

	public readonly List<string> Features;

	public readonly List<string> Integers;

	public readonly List<string> LifeSkills;

	public readonly List<string> MerchantTypes;

	public readonly List<string> ItemKeys;

	public readonly List<string> CombatTypes;

	public readonly List<string> LifeSkillTypes;

	public readonly List<string> CombatSkillTypes;

	public readonly List<string> Informations;

	public readonly List<string> SecretInformationTemplates;

	public readonly List<string> PunishmentTypes;

	public readonly List<string> CharacterTitles;

	public readonly List<string> FloatValues;

	public readonly List<string> CharacterRealNames;

	public readonly List<string> Months;

	public readonly List<string> Professions;

	public readonly List<string> ProfessionSkills;

	public readonly List<string> ItemGrades;

	public readonly List<string> Texts;

	public readonly List<string> Musics;

	public readonly List<string> MapStates;

	public readonly List<string> JiaoLoongs;

	public readonly List<string> JiaoProperties;

	public readonly List<string> Destinys;

	public readonly List<string> SecretInformations;

	public readonly List<string> Merchants;

	public readonly List<string> Legacys;

	public readonly List<string> CharGrades;

	public readonly List<string> Feasts;

	public readonly List<string> AdventureElements;

	public readonly List<string> PersonalityTypes;

	public RenderedArgumentCollection()
	{
		Characters = new List<string>();
		Locations = new List<string>();
		Items = new List<string>();
		CombatSkills = new List<string>();
		Resources = new List<string>();
		Settlements = new List<string>();
		OrgGrades = new List<string>();
		Buildings = new List<string>();
		SwordTombs = new List<string>();
		JuniorXiangshuList = new List<string>();
		Adventures = new List<string>();
		BehaviorTypes = new List<string>();
		FavorabilityTypes = new List<string>();
		Crickets = new List<string>();
		ItemSubTypes = new List<string>();
		Chickens = new List<string>();
		CharacterPropertyReferencedTypes = new List<string>();
		BodyPartTypes = new List<string>();
		InjuryTypes = new List<string>();
		PoisonTypes = new List<string>();
		CharacterTemplates = new List<string>();
		Features = new List<string>();
		Integers = new List<string>();
		LifeSkills = new List<string>();
		MerchantTypes = new List<string>();
		ItemKeys = new List<string>();
		CombatTypes = new List<string>();
		LifeSkillTypes = new List<string>();
		CombatSkillTypes = new List<string>();
		Informations = new List<string>();
		SecretInformationTemplates = new List<string>();
		PunishmentTypes = new List<string>();
		CharacterTitles = new List<string>();
		FloatValues = new List<string>();
		CharacterRealNames = new List<string>();
		Months = new List<string>();
		Professions = new List<string>();
		ProfessionSkills = new List<string>();
		ItemGrades = new List<string>();
		Texts = new List<string>();
		Musics = new List<string>();
		MapStates = new List<string>();
		JiaoLoongs = new List<string>();
		JiaoProperties = new List<string>();
		Destinys = new List<string>();
		SecretInformations = new List<string>();
		Merchants = new List<string>();
		Legacys = new List<string>();
		CharGrades = new List<string>();
		Feasts = new List<string>();
		AdventureElements = new List<string>();
		PersonalityTypes = new List<string>();
	}

	public void Clear()
	{
		Characters.Clear();
		Locations.Clear();
		Items.Clear();
		CombatSkills.Clear();
		Resources.Clear();
		Settlements.Clear();
		OrgGrades.Clear();
		Buildings.Clear();
		SwordTombs.Clear();
		JuniorXiangshuList.Clear();
		Adventures.Clear();
		BehaviorTypes.Clear();
		FavorabilityTypes.Clear();
		Crickets.Clear();
		ItemSubTypes.Clear();
		Chickens.Clear();
		CharacterPropertyReferencedTypes.Clear();
		BodyPartTypes.Clear();
		InjuryTypes.Clear();
		PoisonTypes.Clear();
		CharacterTemplates.Clear();
		Features.Clear();
		Integers.Clear();
		LifeSkills.Clear();
		MerchantTypes.Clear();
		ItemKeys.Clear();
		CombatTypes.Clear();
		LifeSkillTypes.Clear();
		CombatSkillTypes.Clear();
		Informations.Clear();
		SecretInformationTemplates.Clear();
		PunishmentTypes.Clear();
		CharacterTitles.Clear();
		FloatValues.Clear();
		CharacterRealNames.Clear();
		Months.Clear();
		Professions.Clear();
		ProfessionSkills.Clear();
		ItemGrades.Clear();
		Texts.Clear();
		Musics.Clear();
		MapStates.Clear();
		JiaoLoongs.Clear();
		JiaoProperties.Clear();
		Destinys.Clear();
		SecretInformations.Clear();
		Merchants.Clear();
		Legacys.Clear();
		CharGrades.Clear();
		Feasts.Clear();
		AdventureElements.Clear();
		PersonalityTypes.Clear();
	}

	public string Get(sbyte paramType, int index)
	{
		if (TryGet(paramType, index, out var text))
		{
			return text;
		}
		AdaptableLog.Error($"index {index} is out of range for paramType {paramType}.");
		return string.Empty;
	}

	public bool TryGet(sbyte paramType, int index, out string text)
	{
		List<string> list = GetList(paramType);
		if (list.Count <= index)
		{
			text = string.Empty;
			return false;
		}
		text = list[index];
		return true;
	}

	private List<string> GetList(sbyte paramType)
	{
		return paramType switch
		{
			0 => Characters, 
			1 => Locations, 
			2 => Items, 
			3 => CombatSkills, 
			4 => Resources, 
			5 => Settlements, 
			6 => OrgGrades, 
			7 => Buildings, 
			8 => SwordTombs, 
			9 => JuniorXiangshuList, 
			10 => Adventures, 
			11 => BehaviorTypes, 
			12 => FavorabilityTypes, 
			13 => Crickets, 
			14 => ItemSubTypes, 
			15 => Chickens, 
			16 => CharacterPropertyReferencedTypes, 
			17 => BodyPartTypes, 
			18 => InjuryTypes, 
			19 => PoisonTypes, 
			20 => CharacterTemplates, 
			21 => Features, 
			22 => Integers, 
			23 => LifeSkills, 
			24 => MerchantTypes, 
			25 => ItemKeys, 
			26 => CombatTypes, 
			27 => LifeSkillTypes, 
			28 => CombatSkillTypes, 
			29 => Informations, 
			30 => SecretInformationTemplates, 
			31 => PunishmentTypes, 
			32 => CharacterTitles, 
			33 => FloatValues, 
			34 => CharacterRealNames, 
			35 => Months, 
			36 => Professions, 
			37 => ProfessionSkills, 
			38 => ItemGrades, 
			39 => Texts, 
			40 => Musics, 
			41 => MapStates, 
			42 => JiaoLoongs, 
			43 => JiaoProperties, 
			44 => Destinys, 
			45 => SecretInformations, 
			46 => Merchants, 
			47 => Legacys, 
			48 => CharGrades, 
			49 => Feasts, 
			50 => AdventureElements, 
			51 => PersonalityTypes, 
			_ => throw new Exception($"Unsupported ParameterType: {paramType}"), 
		};
	}
}
