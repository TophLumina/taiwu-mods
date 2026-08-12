using System;
using System.Collections.Generic;
using GameData.Utilities;

namespace GameData.Domains.LifeRecord.GeneralRecord;

/// <summary>
/// 已经渲染过的通用记录的实参的集合 (仅供前端使用).
/// 前端需要把 <see cref="T:GameData.Domains.LifeRecord.GeneralRecord.ArgumentCollection" /> 中的实参转为真正要显示的文本, 并放入此集合.
/// </summary>
public class RenderedArgumentCollection
{
	/// <summary>
	/// 角色数据集合
	/// </summary>
	public readonly List<string> Characters;

	/// <summary>
	/// 地点数据集合
	/// </summary>
	public readonly List<string> Locations;

	/// <summary>
	/// 物品数据集合
	/// </summary>
	public readonly List<string> Items;

	/// <summary>
	/// 功法数据集合
	/// </summary>
	public readonly List<string> CombatSkills;

	/// <summary>
	/// 资源数据集合
	/// </summary>
	public readonly List<string> Resources;

	/// <summary>
	/// 定居点数据集合
	/// </summary>
	public readonly List<string> Settlements;

	/// <summary>
	/// 团体级别数据集合
	/// </summary>
	public readonly List<string> OrgGrades;

	/// <summary>
	/// 产业建筑数据集合
	/// </summary>
	public readonly List<string> Buildings;

	/// <summary>
	/// 剑冢数据集合
	/// </summary>
	public readonly List<string> SwordTombs;

	/// <summary>
	/// 紫竹化身数据集合
	/// </summary>
	public readonly List<string> JuniorXiangshuList;

	/// <summary>
	/// 奇遇数据集合
	/// </summary>
	public readonly List<string> Adventures;

	/// <summary>
	/// 角色立场数据集合
	/// </summary>
	public readonly List<string> BehaviorTypes;

	/// <summary>
	/// 好感类型数据集合
	/// </summary>
	public readonly List<string> FavorabilityTypes;

	/// <summary>
	/// 促织数据集合
	/// </summary>
	public readonly List<string> Crickets;

	/// <summary>
	/// 物品子类数据集合
	/// </summary>
	public readonly List<string> ItemSubTypes;

	/// <summary>
	/// 鸡数据集合
	/// </summary>
	public readonly List<string> Chickens;

	/// <summary>
	/// 角色属性引用类型数据集合
	/// </summary>
	public readonly List<string> CharacterPropertyReferencedTypes;

	/// <summary>
	/// 身体部位类型数据集合
	/// </summary>
	public readonly List<string> BodyPartTypes;

	/// <summary>
	/// 伤势类型数据集合
	/// </summary>
	public readonly List<string> InjuryTypes;

	/// <summary>
	/// 毒素类型数据集合
	/// </summary>
	public readonly List<string> PoisonTypes;

	/// <summary>
	/// 角色模板数据的集合
	/// </summary>
	public readonly List<string> CharacterTemplates;

	/// <summary>
	/// 角色特性数据的集合
	/// </summary>
	public readonly List<string> Features;

	/// <summary>
	/// 整型数据集合
	/// </summary>
	public readonly List<string> Integers;

	/// <summary>
	/// 技艺数据集合
	/// </summary>
	public readonly List<string> LifeSkills;

	/// <summary>
	/// 商会类型集合
	/// </summary>
	public readonly List<string> MerchantTypes;

	/// <summary>
	/// 物品实例的Key
	/// </summary>
	public readonly List<string> ItemKeys;

	/// <summary>
	/// 战斗类型
	/// </summary>
	public readonly List<string> CombatTypes;

	/// <summary>
	/// 技艺类型集合
	/// </summary>
	public readonly List<string> LifeSkillTypes;

	/// <summary>
	/// 功法类型集合
	/// </summary>
	public readonly List<string> CombatSkillTypes;

	/// <summary>
	/// 见闻集合
	/// </summary>
	public readonly List<string> Informations;

	/// <summary>
	/// 秘闻集合
	/// </summary>
	public readonly List<string> SecretInformationTemplates;

	/// <summary>
	/// 惩罚类型集合
	/// </summary>
	public readonly List<string> PunishmentTypes;

	/// <summary>
	/// 角色称号集合
	/// </summary>
	public readonly List<string> CharacterTitles;

	/// <summary>
	/// 浮点数集合
	/// </summary>
	public readonly List<string> FloatValues;

	/// <summary>
	/// 角色真名集合
	/// </summary>
	public readonly List<string> CharacterRealNames;

	/// <summary>
	/// 月份集合
	/// </summary>
	public readonly List<string> Months;

	/// <summary>
	/// 志向
	/// </summary>
	public readonly List<string> Professions;

	/// <summary>
	/// 志向技能
	/// </summary>
	public readonly List<string> ProfessionSkills;

	/// <summary>
	/// 物品品阶
	/// </summary>
	public readonly List<string> ItemGrades;

	/// <summary>
	/// 文本
	/// </summary>
	public readonly List<string> Texts;

	/// <summary>
	/// 音乐
	/// </summary>
	public readonly List<string> Musics;

	/// <summary>
	/// 州域
	/// </summary>
	public readonly List<string> MapStates;

	/// <summary>
	/// 蛟龙
	/// </summary>
	public readonly List<string> JiaoLoongs;

	/// <summary>
	/// 蛟的属性
	/// </summary>
	public readonly List<string> JiaoProperties;

	/// <summary>
	/// 轮回类型
	/// </summary>
	public readonly List<string> Destinys;

	/// <summary>
	/// 秘闻 Key
	/// </summary>
	public readonly List<string> SecretInformations;

	/// <summary>
	/// 商店名称
	/// </summary>
	public readonly List<string> Merchants;

	/// <summary>
	/// 遗惠名称
	/// </summary>
	public readonly List<string> Legacys;

	/// <summary>
	/// 人物品级
	/// </summary>
	public readonly List<string> CharGrades;

	/// <summary>
	/// 宴席
	/// </summary>
	public readonly List<string> Feasts;

	/// <summary>
	/// 奇遇元素
	/// </summary>
	public readonly List<string> AdventureElements;

	/// <summary>
	/// 七元
	/// </summary>
	public readonly List<string> PersonalityTypes;

	/// <summary>
	/// 已经渲染过的通用记录的实参的集合
	/// </summary>
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

	/// <summary>
	/// 清空集合内的所有数据
	/// </summary>
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

	/// <inheritdoc cref="M:GameData.Domains.LifeRecord.GeneralRecord.RenderedArgumentCollection.TryGet(System.SByte,System.Int32,System.String@)" />
	public string Get(sbyte paramType, int index)
	{
		if (TryGet(paramType, index, out var text))
		{
			return text;
		}
		AdaptableLog.Error($"index {index} is out of range for paramType {paramType}.");
		return string.Empty;
	}

	/// <summary>
	/// 获取渲染过的实参的字串
	/// </summary>
	/// <param name="paramType"></param>
	/// <param name="index"></param>
	/// <param name="text">参数文本</param>
	/// <returns></returns>
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
