using System;

namespace GameData.Domains.LifeRecord.GeneralRecord;

/// <summary>
/// 通用记录参数类型
/// </summary>
public static class ParameterType
{
	/// <summary>
	/// 角色
	/// </summary>
	public const sbyte Character = 0;

	/// <summary>
	/// 地点
	/// </summary>
	public const sbyte Location = 1;

	/// <summary>
	/// 物品
	/// </summary>
	public const sbyte Item = 2;

	/// <summary>
	/// 功法
	/// </summary>
	public const sbyte CombatSkill = 3;

	/// <summary>
	/// 资源
	/// </summary>
	public const sbyte Resource = 4;

	/// <summary>
	/// 定居点
	/// </summary>
	public const sbyte Settlement = 5;

	/// <summary>
	/// 团体级别
	/// </summary>
	public const sbyte OrgGrade = 6;

	/// <summary>
	/// 产业建筑
	/// </summary>
	public const sbyte Building = 7;

	/// <summary>
	/// 剑冢
	/// </summary>
	public const sbyte SwordTomb = 8;

	/// <summary>
	/// 紫竹化身
	/// </summary>
	public const sbyte JuniorXiangshu = 9;

	/// <summary>
	/// 奇遇
	/// </summary>
	public const sbyte Adventure = 10;

	/// <summary>
	/// 角色立场
	/// </summary>
	public const sbyte BehaviorType = 11;

	/// <summary>
	/// 好感类型
	/// </summary>
	public const sbyte FavorabilityType = 12;

	/// <summary>
	/// 促织
	/// </summary>
	public const sbyte Cricket = 13;

	/// <summary>
	/// 物品子类
	/// </summary>
	public const sbyte ItemSubType = 14;

	/// <summary>
	/// 鸡
	/// </summary>
	public const sbyte Chicken = 15;

	/// <summary>
	/// 角色属性引用类型
	/// </summary>
	public const sbyte CharacterPropertyReferencedType = 16;

	/// <summary>
	/// 身体部位类型
	/// </summary>
	public const sbyte BodyPartType = 17;

	/// <summary>
	/// 伤势类型
	/// </summary>
	public const sbyte InjuryType = 18;

	/// <summary>
	/// 毒素类型
	/// </summary>
	public const sbyte PoisonType = 19;

	/// <summary>
	/// 角色模板
	/// </summary>
	public const sbyte CharacterTemplate = 20;

	/// <summary>
	/// 角色特性
	/// </summary>
	public const sbyte Feature = 21;

	/// <summary>
	/// 整型数值
	/// </summary>
	public const sbyte Integer = 22;

	/// <summary>
	/// 技艺数据
	/// </summary>
	public const sbyte LifeSkill = 23;

	/// <summary>
	/// 商会类型
	/// </summary>
	public const sbyte MerchantType = 24;

	/// <summary>
	/// 物品实例的Key
	/// </summary>
	public const sbyte ItemKey = 25;

	/// <summary>
	/// 战斗类型
	/// </summary>
	public const sbyte CombatType = 26;

	/// <summary>
	/// 技艺类型
	/// </summary>
	public const sbyte LifeSkillType = 27;

	/// <summary>
	/// 功法类型
	/// </summary>
	public const sbyte CombatSkillType = 28;

	/// <summary>
	/// 见闻
	/// </summary>
	public const sbyte Information = 29;

	/// <summary>
	/// 秘闻模板
	/// </summary>
	public const sbyte SecretInformationTemplate = 30;

	/// <summary>
	/// 惩罚类型
	/// </summary>
	public const sbyte PunishmentType = 31;

	/// <summary>
	/// 角色称号
	/// </summary>
	public const sbyte CharacterTitle = 32;

	/// <summary>
	/// 浮点数
	/// </summary>
	public const sbyte Float = 33;

	/// <summary>
	/// 角色本名
	/// </summary>
	public const sbyte CharacterRealName = 34;

	/// <summary>
	/// 月份
	/// </summary>
	public const sbyte Month = 35;

	/// <summary>
	/// 志向
	/// </summary>
	public const sbyte Profession = 36;

	/// <summary>
	/// 志向技能
	/// </summary>
	public const sbyte ProfessionSkill = 37;

	/// <summary>
	/// 物品品阶
	/// </summary>
	public const sbyte ItemGrade = 38;

	/// <summary>
	/// Text
	/// </summary>
	public const sbyte Text = 39;

	/// <summary>
	/// 音乐
	/// </summary>
	public const sbyte Music = 40;

	/// <summary>
	/// 州域
	/// </summary>
	public const sbyte MapState = 41;

	/// <summary>
	/// 蛟龙
	/// </summary>
	public const sbyte JiaoLoong = 42;

	/// <summary>
	/// 蛟龙的属性
	/// </summary>
	public const sbyte JiaoProperty = 43;

	/// <summary>
	/// 轮回类型
	/// </summary>
	public const sbyte DestinyType = 44;

	/// <summary>
	/// 秘闻实例 Key
	/// </summary>
	public const sbyte SecretInformation = 45;

	/// <summary>
	/// 商店名称
	/// </summary>
	public const sbyte Merchant = 46;

	/// <summary>
	/// 遗惠名称
	/// </summary>
	public const sbyte Legacy = 47;

	/// <summary>
	/// 人物品级
	/// </summary>
	public const sbyte CharGrade = 48;

	/// <summary>
	/// 宴席
	/// </summary>
	public const sbyte Feast = 49;

	/// <summary>
	/// 奇遇元素
	/// </summary>
	public const sbyte AdventureElement = 50;

	/// <summary>
	/// 七元
	/// </summary>
	public const sbyte PersonalityType = 51;

	/// <summary>
	/// 记录参数类型的个数
	/// </summary>
	public const int Count = 51;

	/// <summary>
	/// 把字串转为记录参数类型
	/// </summary>
	/// <param name="name"></param>
	/// <returns></returns>
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
