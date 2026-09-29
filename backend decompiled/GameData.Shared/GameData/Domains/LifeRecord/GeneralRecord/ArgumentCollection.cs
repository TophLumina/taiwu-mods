using System.Collections.Generic;
using GameData.Domains.Map;

namespace GameData.Domains.LifeRecord.GeneralRecord;

public class ArgumentCollection
{
	public readonly List<int> Characters;

	public readonly List<Location> Locations;

	public readonly List<(sbyte itemType, short itemTemplateId)> Items;

	public readonly List<short> CombatSkills;

	public readonly List<sbyte> Resources;

	public readonly List<short> Settlements;

	public readonly List<(sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender)> OrgGrades;

	public readonly List<short> Buildings;

	public readonly List<sbyte> SwordTombs;

	public readonly List<sbyte> JuniorXiangshuList;

	public readonly List<int> Adventures;

	public readonly List<sbyte> BehaviorTypes;

	public readonly List<sbyte> FavorabilityTypes;

	public readonly List<(short colorId, short partId, int nameId)> Crickets;

	public readonly List<short> ItemSubTypes;

	public readonly List<short> Chickens;

	public readonly List<short> CharacterPropertyReferencedTypes;

	public readonly List<sbyte> BodyPartTypes;

	public readonly List<sbyte> InjuryTypes;

	public readonly List<sbyte> PoisonTypes;

	public readonly List<short> CharacterTemplates;

	public readonly List<short> Features;

	public readonly List<int> Integers;

	public readonly List<short> LifeSkills;

	public readonly List<sbyte> MerchantTypes;

	public readonly List<ulong> ItemKeys;

	public readonly List<sbyte> CombatTypes;

	public readonly List<sbyte> LifeSkillTypes;

	public readonly List<sbyte> CombatSkillTypes;

	public readonly List<short> Informations;

	public readonly List<short> SecretInformationTemplates;

	public readonly List<short> PunishmentTypes;

	public readonly List<short> CharacterTitles;

	public readonly List<float> FloatValues;

	public readonly List<int> CharacterRealNames;

	public readonly List<sbyte> Months;

	public readonly List<int> Professions;

	public readonly List<int> ProfessionSkills;

	public readonly List<sbyte> ItemGrades;

	public readonly List<string> Texts;

	public readonly List<short> Musics;

	public readonly List<sbyte> MapStates;

	public readonly List<int> JiaoLoongs;

	public readonly List<short> JiaoProperties;

	public readonly List<sbyte> DestinyTypes;

	public readonly List<(short templateId, int id)> SecretInformations;

	public readonly List<sbyte> Merchants;

	public readonly List<short> Legacys;

	public readonly List<sbyte> CharGrades;

	public readonly List<short> Feasts;

	public readonly List<int> AdventureElements;

	public readonly List<sbyte> PersonalityTypes;

	public ArgumentCollection()
	{
		Characters = new List<int>();
		Locations = new List<Location>();
		Items = new List<(sbyte, short)>();
		CombatSkills = new List<short>();
		Resources = new List<sbyte>();
		Settlements = new List<short>();
		OrgGrades = new List<(sbyte, sbyte, bool, sbyte)>();
		Buildings = new List<short>();
		SwordTombs = new List<sbyte>();
		JuniorXiangshuList = new List<sbyte>();
		Adventures = new List<int>();
		BehaviorTypes = new List<sbyte>();
		FavorabilityTypes = new List<sbyte>();
		Crickets = new List<(short, short, int)>();
		ItemSubTypes = new List<short>();
		Chickens = new List<short>();
		CharacterPropertyReferencedTypes = new List<short>();
		BodyPartTypes = new List<sbyte>();
		InjuryTypes = new List<sbyte>();
		PoisonTypes = new List<sbyte>();
		CharacterTemplates = new List<short>();
		Features = new List<short>();
		Integers = new List<int>();
		LifeSkills = new List<short>();
		MerchantTypes = new List<sbyte>();
		ItemKeys = new List<ulong>();
		CombatTypes = new List<sbyte>();
		LifeSkillTypes = new List<sbyte>();
		CombatSkillTypes = new List<sbyte>();
		Informations = new List<short>();
		SecretInformationTemplates = new List<short>();
		PunishmentTypes = new List<short>();
		CharacterTitles = new List<short>();
		FloatValues = new List<float>();
		CharacterRealNames = new List<int>();
		Months = new List<sbyte>();
		Professions = new List<int>();
		ProfessionSkills = new List<int>();
		ItemGrades = new List<sbyte>();
		Texts = new List<string>();
		Musics = new List<short>();
		MapStates = new List<sbyte>();
		JiaoLoongs = new List<int>();
		JiaoProperties = new List<short>();
		DestinyTypes = new List<sbyte>();
		SecretInformations = new List<(short, int)>();
		Merchants = new List<sbyte>();
		Legacys = new List<short>();
		CharGrades = new List<sbyte>();
		Feasts = new List<short>();
		AdventureElements = new List<int>();
		PersonalityTypes = new List<sbyte>();
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
		DestinyTypes.Clear();
		SecretInformations.Clear();
		Merchants.Clear();
		Legacys.Clear();
		CharGrades.Clear();
		Feasts.Clear();
		AdventureElements.Clear();
		PersonalityTypes.Clear();
	}

	public int AddCharacter(int charId)
	{
		int count = Characters.Count;
		Characters.Add(charId);
		return count;
	}

	public int AddLocation(Location location)
	{
		int count = Locations.Count;
		Locations.Add(location);
		return count;
	}

	public int AddItem(sbyte itemType, short itemTemplateId)
	{
		int count = Items.Count;
		Items.Add((itemType, itemTemplateId));
		return count;
	}

	public int AddCombatSkill(short combatSkillId)
	{
		int count = CombatSkills.Count;
		CombatSkills.Add(combatSkillId);
		return count;
	}

	public int AddResource(sbyte resourceType)
	{
		int count = Resources.Count;
		Resources.Add(resourceType);
		return count;
	}

	public int AddSettlement(short settlementId)
	{
		int count = Settlements.Count;
		Settlements.Add(settlementId);
		return count;
	}

	public int AddOrgGrade(sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender)
	{
		int count = OrgGrades.Count;
		OrgGrades.Add((orgTemplateId, orgGrade, orgPrincipal, gender));
		return count;
	}

	public int AddBuilding(short buildingTemplateId)
	{
		int count = Buildings.Count;
		Buildings.Add(buildingTemplateId);
		return count;
	}

	public int AddSwordTomb(sbyte xiangshuAvatarId)
	{
		int count = SwordTombs.Count;
		SwordTombs.Add(xiangshuAvatarId);
		return count;
	}

	public int AddJuniorXiangshu(sbyte xiangshuAvatarId)
	{
		int count = JuniorXiangshuList.Count;
		JuniorXiangshuList.Add(xiangshuAvatarId);
		return count;
	}

	public int AddAdventure(int adventureCoreId)
	{
		int count = Adventures.Count;
		Adventures.Add(adventureCoreId);
		return count;
	}

	public int AddBehaviorType(sbyte behaviorType)
	{
		int count = BehaviorTypes.Count;
		BehaviorTypes.Add(behaviorType);
		return count;
	}

	public int AddFavorabilityType(sbyte favorabilityType)
	{
		int count = FavorabilityTypes.Count;
		FavorabilityTypes.Add(favorabilityType);
		return count;
	}

	public int AddCricket(short colorId, short partId, int nameId)
	{
		int count = Crickets.Count;
		Crickets.Add((colorId, partId, nameId));
		return count;
	}

	public int AddItemSubType(short itemSubType)
	{
		int count = ItemSubTypes.Count;
		ItemSubTypes.Add(itemSubType);
		return count;
	}

	public int AddChicken(short chickenId)
	{
		int count = Chickens.Count;
		Chickens.Add(chickenId);
		return count;
	}

	public int AddCharacterPropertyReferencedType(short characterPropertyReferencedType)
	{
		int count = CharacterPropertyReferencedTypes.Count;
		CharacterPropertyReferencedTypes.Add(characterPropertyReferencedType);
		return count;
	}

	public int AddBodyPartType(sbyte bodyPartType)
	{
		int count = BodyPartTypes.Count;
		BodyPartTypes.Add(bodyPartType);
		return count;
	}

	public int AddInjuryType(sbyte injuryType)
	{
		int count = InjuryTypes.Count;
		InjuryTypes.Add(injuryType);
		return count;
	}

	public int AddPoisonType(sbyte poisonType)
	{
		int count = PoisonTypes.Count;
		PoisonTypes.Add(poisonType);
		return count;
	}

	public int AddCharacterTemplate(short templateId)
	{
		int count = CharacterTemplates.Count;
		CharacterTemplates.Add(templateId);
		return count;
	}

	public int AddFeature(short featureId)
	{
		int count = Features.Count;
		Features.Add(featureId);
		return count;
	}

	public int AddInteger(int value)
	{
		int count = Integers.Count;
		Integers.Add(value);
		return count;
	}

	public int AddLifeSkill(short lifeSkillTemplateId)
	{
		int count = LifeSkills.Count;
		LifeSkills.Add(lifeSkillTemplateId);
		return count;
	}

	public int AddMerchantType(sbyte merchantType)
	{
		int count = MerchantTypes.Count;
		MerchantTypes.Add(merchantType);
		return count;
	}

	public int AddItemKey(ulong itemKey)
	{
		int count = ItemKeys.Count;
		ItemKeys.Add(itemKey);
		return count;
	}

	public int AddCombatType(sbyte combatType)
	{
		int count = CombatTypes.Count;
		CombatTypes.Add(combatType);
		return count;
	}

	public int AddLifeSkillType(sbyte lifeSkillType)
	{
		int count = LifeSkillTypes.Count;
		LifeSkillTypes.Add(lifeSkillType);
		return count;
	}

	public int AddCombatSkillType(sbyte combatSkillType)
	{
		int count = CombatSkillTypes.Count;
		CombatSkillTypes.Add(combatSkillType);
		return count;
	}

	public int AddInformation(short infoTemplateId)
	{
		int count = Informations.Count;
		Informations.Add(infoTemplateId);
		return count;
	}

	public int AddSecretInformationTemplate(short secretInfoTemplateId)
	{
		int count = SecretInformationTemplates.Count;
		SecretInformationTemplates.Add(secretInfoTemplateId);
		return count;
	}

	public int AddPunishmentType(short punishmentType)
	{
		int count = PunishmentTypes.Count;
		PunishmentTypes.Add(punishmentType);
		return count;
	}

	public int AddCharacterTitle(short titleTemplateId)
	{
		int count = CharacterTitles.Count;
		CharacterTitles.Add(titleTemplateId);
		return count;
	}

	public int AddFloat(float floatValue)
	{
		int count = FloatValues.Count;
		FloatValues.Add(floatValue);
		return count;
	}

	public int AddCharacterRealName(int charId)
	{
		int count = CharacterRealNames.Count;
		CharacterRealNames.Add(charId);
		return count;
	}

	public int AddMonth(sbyte month)
	{
		int count = Months.Count;
		Months.Add(month);
		return count;
	}

	public int AddProfession(int professionTemplateId)
	{
		int count = Professions.Count;
		Professions.Add(professionTemplateId);
		return count;
	}

	public int AddProfessionSkill(int skillTemplateId)
	{
		int count = ProfessionSkills.Count;
		ProfessionSkills.Add(skillTemplateId);
		return count;
	}

	public int AddItemGrade(sbyte grade)
	{
		int count = ItemGrades.Count;
		ItemGrades.Add(grade);
		return count;
	}

	public int AddText(string text)
	{
		int count = Texts.Count;
		Texts.Add(text);
		return count;
	}

	public int AddMusic(short musicTemplateId)
	{
		int count = Musics.Count;
		Musics.Add(musicTemplateId);
		return count;
	}

	public int AddMapState(sbyte stateTemplateId)
	{
		int count = MapStates.Count;
		MapStates.Add(stateTemplateId);
		return count;
	}

	public int AddJiaoLoong(int jiaoLoongId)
	{
		int count = JiaoLoongs.Count;
		JiaoLoongs.Add(jiaoLoongId);
		return count;
	}

	public int AddJiaoProperty(short jiaoPropertyId)
	{
		int count = JiaoProperties.Count;
		JiaoProperties.Add(jiaoPropertyId);
		return count;
	}

	public int AddDestinyType(sbyte destinyType)
	{
		int count = DestinyTypes.Count;
		DestinyTypes.Add(destinyType);
		return count;
	}

	public int AddSecretInformation(short templateId, int id)
	{
		int count = SecretInformations.Count;
		SecretInformations.Add((templateId, id));
		return count;
	}

	public int AddMerchant(sbyte templateId)
	{
		int count = Merchants.Count;
		Merchants.Add(templateId);
		return count;
	}

	public int AddLegacy(short templateId)
	{
		int count = Legacys.Count;
		Legacys.Add(templateId);
		return count;
	}

	public int AddCharGrade(sbyte grade)
	{
		int count = CharGrades.Count;
		CharGrades.Add(grade);
		return count;
	}

	public int AddFeast(short feast)
	{
		int count = Feasts.Count;
		Feasts.Add(feast);
		return count;
	}

	public int AddAdventureElement(int elementCoreId)
	{
		int count = AdventureElements.Count;
		AdventureElements.Add(elementCoreId);
		return count;
	}

	public int AddPersonalityType(sbyte personalityType)
	{
		int count = PersonalityTypes.Count;
		PersonalityTypes.Add(personalityType);
		return count;
	}
}
