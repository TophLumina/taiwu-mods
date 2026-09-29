using System;

namespace GameData.Domains.Character;

public static class GearMateUpgradeType
{
	public const sbyte Strength = 0;

	public const sbyte Dexterity = 1;

	public const sbyte Concentration = 2;

	public const sbyte Vitality = 3;

	public const sbyte Energy = 4;

	public const sbyte Intelligence = 5;

	public const sbyte ConsummateLevel = 6;

	public const sbyte Feature = 7;

	public const sbyte CombatSkill = 8;

	public const sbyte LifeSkill = 9;

	public const sbyte CombatSkillBreak = 10;

	public const sbyte Neili = 11;

	public const sbyte NeiliType = 12;

	public const sbyte Attack = 13;

	public const sbyte Agility = 14;

	public const sbyte Defense = 15;

	public const sbyte Assistance = 16;

	public const int Count = 17;

	public static sbyte GetMainAttributeUpgradeTypeByResourceType(sbyte resourceType)
	{
		return resourceType switch
		{
			0 => 3, 
			1 => 4, 
			2 => 0, 
			3 => 5, 
			4 => 1, 
			5 => 2, 
			_ => -1, 
		};
	}

	public static string GetMainAttributeUpgradeTypeName(sbyte type)
	{
		return LocalStringManager.Get(type switch
		{
			3 => LanguageKey.LK_Main_Attribute_Vitality, 
			4 => LanguageKey.LK_Main_Attribute_Energy, 
			0 => LanguageKey.LK_Main_Attribute_Strength, 
			5 => LanguageKey.LK_Main_Attribute_Intelligence, 
			1 => LanguageKey.LK_Main_Attribute_Dexterity, 
			2 => LanguageKey.LK_Main_Attribute_Concentration, 
			_ => throw new ArgumentOutOfRangeException("type", type, null), 
		});
	}
}
