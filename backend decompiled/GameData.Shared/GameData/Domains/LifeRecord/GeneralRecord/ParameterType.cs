using System;

namespace GameData.Domains.LifeRecord.GeneralRecord;

public static class ParameterType
{
	public const sbyte Character = 0;

	public const sbyte Location = 1;

	public const sbyte Item = 2;

	public const sbyte CombatSkill = 3;

	public const sbyte Resource = 4;

	public const sbyte Settlement = 5;

	public const sbyte OrgGrade = 6;

	public const sbyte Building = 7;

	public const sbyte SwordTomb = 8;

	public const sbyte JuniorXiangshu = 9;

	public const sbyte Adventure = 10;

	public const sbyte BehaviorType = 11;

	public const sbyte FavorabilityType = 12;

	public const sbyte Cricket = 13;

	public const sbyte ItemSubType = 14;

	public const sbyte Chicken = 15;

	public const sbyte CharacterPropertyReferencedType = 16;

	public const sbyte BodyPartType = 17;

	public const sbyte InjuryType = 18;

	public const sbyte PoisonType = 19;

	public const sbyte CharacterTemplate = 20;

	public const sbyte Feature = 21;

	public const sbyte Integer = 22;

	public const sbyte LifeSkill = 23;

	public const sbyte MerchantType = 24;

	public const sbyte ItemKey = 25;

	public const sbyte CombatType = 26;

	public const sbyte LifeSkillType = 27;

	public const sbyte CombatSkillType = 28;

	public const sbyte Information = 29;

	public const sbyte SecretInformationTemplate = 30;

	public const sbyte PunishmentType = 31;

	public const sbyte CharacterTitle = 32;

	public const sbyte Float = 33;

	public const sbyte CharacterRealName = 34;

	public const sbyte Month = 35;

	public const sbyte Profession = 36;

	public const sbyte ProfessionSkill = 37;

	public const sbyte ItemGrade = 38;

	public const sbyte Text = 39;

	public const sbyte Music = 40;

	public const sbyte MapState = 41;

	public const sbyte JiaoLoong = 42;

	public const sbyte JiaoProperty = 43;

	public const sbyte DestinyType = 44;

	public const sbyte SecretInformation = 45;

	public const sbyte Merchant = 46;

	public const sbyte Legacy = 47;

	public const sbyte CharGrade = 48;

	public const sbyte Feast = 49;

	public const sbyte AdventureElement = 50;

	public const sbyte PersonalityType = 51;

	public const int Count = 51;

	public static sbyte Parse(string name)
	{
		return name switch
		{
			"Character" => 0, 
			"Location" => 1, 
			"Item" => 2, 
			"CombatSkill" => 3, 
			"Resource" => 4, 
			"Settlement" => 5, 
			"OrgGrade" => 6, 
			"Building" => 7, 
			"SwordTomb" => 8, 
			"JuniorXiangshu" => 9, 
			"Adventure" => 10, 
			"BehaviorType" => 11, 
			"FavorabilityType" => 12, 
			"Cricket" => 13, 
			"ItemSubType" => 14, 
			"Chicken" => 15, 
			"CharacterPropertyReferencedType" => 16, 
			"BodyPartType" => 17, 
			"InjuryType" => 18, 
			"PoisonType" => 19, 
			"CharacterTemplate" => 20, 
			"Feature" => 21, 
			"Integer" => 22, 
			"LifeSkill" => 23, 
			"MerchantType" => 24, 
			"ItemKey" => 25, 
			"CombatType" => 26, 
			"LifeSkillType" => 27, 
			"CombatSkillType" => 28, 
			"Information" => 29, 
			"SecretInformationTemplate" => 30, 
			"PunishmentType" => 31, 
			"CharacterTitle" => 32, 
			"Float" => 33, 
			"CharacterRealName" => 34, 
			"Month" => 35, 
			"Profession" => 36, 
			"ProfessionSkill" => 37, 
			"ItemGrade" => 38, 
			"Text" => 39, 
			"Music" => 40, 
			"MapState" => 41, 
			"JiaoLoong" => 42, 
			"JiaoProperty" => 43, 
			"DestinyType" => 44, 
			"SecretInformation" => 45, 
			"Merchant" => 46, 
			"Legacy" => 47, 
			"CharGrade" => 48, 
			"Feast" => 49, 
			"AdventureElement" => 50, 
			"PersonalityType" => 51, 
			_ => throw new Exception("Unsupported ParameterType: " + name), 
		};
	}
}
