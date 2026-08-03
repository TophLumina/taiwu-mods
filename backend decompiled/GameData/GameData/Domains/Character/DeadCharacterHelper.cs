using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Domains.Character.AvatarSystem;
using Redzen.Random;

namespace GameData.Domains.Character;

public static class DeadCharacterHelper
{
	public static DeadCharacter CreateDeadCharacter(Character character, int deathDate)
	{
		List<short> titles = new List<short>();
		character.GetTitles(titles);
		return new DeadCharacter
		{
			TemplateId = character.GetTemplateId(),
			FullName = character.GetFullName(),
			MonasticTitle = character.GetMonasticTitle(),
			TitleIds = titles,
			Gender = character.GetGender(),
			FameType = character.GetFameType(),
			Happiness = character.GetHappiness(),
			Morality = character.GetMorality(),
			OrganizationInfo = character.GetOrganizationInfo(),
			Avatar = new AvatarData(character.GetAvatar()),
			ClothingDisplayId = character.GetClothingDisplayId(),
			Attraction = character.GetAttraction(),
			BirthDate = character.GetBirthDate(),
			CurrAge = character.GetCurrAge(),
			DeathDate = deathDate,
			MonkType = character.GetMonkType(),
			FeatureIds = (from templateId in character.GetFeatureIds()
				where CharacterFeature.Instance[templateId]?.CanRecordWhenDead ?? false
				select templateId).ToList(),
			BaseMainAttributes = character.GetBaseMainAttributes(),
			BaseLifeSkillQualifications = character.GetBaseLifeSkillQualifications(),
			BaseCombatSkillQualifications = character.GetBaseCombatSkillQualifications(),
			PreexistenceCharIds = character.GetPreexistenceCharIds()
		};
	}

	public static DeadCharacter CreateDeadNonIntelligentCharacter(IRandomSource randomSource, short charTemplateId, int deathDate)
	{
		CharacterItem template = Config.Character.Instance[charTemplateId];
		sbyte gender = ((template.Gender >= 0) ? template.Gender : Gender.GetRandom(randomSource));
		short actualAge = (short)((template.ActualAge >= 0) ? template.ActualAge : randomSource.Next(0, 101));
		return new DeadCharacter
		{
			TemplateId = charTemplateId,
			TitleIds = new List<short>(),
			Gender = gender,
			FameType = FameType.GetFameType(template.PresetFame),
			Happiness = template.Happiness,
			Morality = template.BaseMorality,
			OrganizationInfo = template.OrganizationInfo,
			Avatar = AvatarManager.Instance.GetRandomAvatar(randomSource, gender, template.Transgender, template.PresetBodyType, template.BaseAttraction),
			Attraction = template.BaseAttraction,
			BirthDate = CharacterDomain.CalcBirthDate(actualAge, template.BirthMonth),
			CurrAge = ((template.InitCurrAge >= 0) ? template.InitCurrAge : actualAge),
			DeathDate = deathDate,
			MonkType = template.MonkType,
			FeatureIds = new List<short>(template.FeatureIds),
			BaseMainAttributes = template.BaseMainAttributes,
			BaseLifeSkillQualifications = template.BaseLifeSkillQualifications,
			BaseCombatSkillQualifications = template.BaseCombatSkillQualifications
		};
	}
}
