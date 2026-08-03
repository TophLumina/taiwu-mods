using System;

namespace GameData.Domains.Character;

/// <summary>
/// 机关人升级类型
/// </summary>
public static class GearMateUpgradeType
{
	/// <summary>
	/// 膂力
	/// </summary>
	public const sbyte Strength = 0;

	/// <summary>
	/// 灵敏
	/// </summary>
	public const sbyte Dexterity = 1;

	/// <summary>
	/// 定力
	/// </summary>
	public const sbyte Concentration = 2;

	/// <summary>
	/// 体质
	/// </summary>
	public const sbyte Vitality = 3;

	/// <summary>
	/// 根骨
	/// </summary>
	public const sbyte Energy = 4;

	/// <summary>
	/// 悟性
	/// </summary>
	public const sbyte Intelligence = 5;

	/// <summary>
	/// 精纯
	/// </summary>
	public const sbyte ConsummateLevel = 6;

	/// <summary>
	/// 特性
	/// </summary>
	public const sbyte Feature = 7;

	/// <summary>
	/// 功法
	/// </summary>
	public const sbyte CombatSkill = 8;

	/// <summary>
	/// 技艺
	/// </summary>
	public const sbyte LifeSkill = 9;

	/// <summary>
	/// 突破
	/// </summary>
	public const sbyte CombatSkillBreak = 10;

	/// <summary>
	/// 内力
	/// </summary>
	public const sbyte Neili = 11;

	/// <summary>
	/// 内力武行
	/// </summary>
	public const sbyte NeiliType = 12;

	/// <summary>
	/// 周天真气 - 摧破
	/// </summary>
	public const sbyte Attack = 13;

	/// <summary>
	/// 周天真气 - 轻灵
	/// </summary>
	public const sbyte Agility = 14;

	/// <summary>
	/// 周天真气 - 护体
	/// </summary>
	public const sbyte Defense = 15;

	/// <summary>
	/// 周天真气 - 奇窍
	/// </summary>
	public const sbyte Assistance = 16;

	/// <summary>
	/// 总个数
	/// </summary>
	public const int Count = 17;

	/// <summary>
	/// 根据资源类型获取主属性成长类型
	/// </summary>
	/// <param name="resourceType"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 获取主属性的名称
	/// </summary>
	/// <param name="type"></param>
	/// <returns></returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
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
