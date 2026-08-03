using System.Collections.Generic;
using GameData.Domains.Map;

namespace GameData.Domains.LifeRecord.GeneralRecord;

/// <summary>
/// 通用记录的实参的集合 (仅供前端使用).
/// 从记录集合中读取记录时, 实参会存放到此集合中.
/// </summary>
public class ArgumentCollection
{
	/// <summary>
	/// 角色数据集合
	/// </summary>
	public readonly List<int> Characters;

	/// <summary>
	/// 地点数据集合
	/// </summary>
	public readonly List<Location> Locations;

	/// <summary>
	/// 物品数据集合
	/// </summary>
	public readonly List<(sbyte itemType, short itemTemplateId)> Items;

	/// <summary>
	/// 功法数据集合
	/// </summary>
	public readonly List<short> CombatSkills;

	/// <summary>
	/// 资源数据集合
	/// </summary>
	public readonly List<sbyte> Resources;

	/// <summary>
	/// 定居点数据集合
	/// </summary>
	public readonly List<short> Settlements;

	/// <summary>
	/// 团体级别数据集合
	/// </summary>
	public readonly List<(sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender)> OrgGrades;

	/// <summary>
	/// 产业建筑数据集合
	/// </summary>
	public readonly List<short> Buildings;

	/// <summary>
	/// 剑冢数据集合
	/// </summary>
	public readonly List<sbyte> SwordTombs;

	/// <summary>
	/// 紫竹化身数据集合
	/// </summary>
	public readonly List<sbyte> JuniorXiangshuList;

	/// <summary>
	/// 奇遇数据集合
	/// </summary>
	public readonly List<int> Adventures;

	/// <summary>
	/// 角色立场数据集合
	/// </summary>
	public readonly List<sbyte> BehaviorTypes;

	/// <summary>
	/// 好感类型数据集合
	/// </summary>
	public readonly List<sbyte> FavorabilityTypes;

	/// <summary>
	/// 促织数据集合
	/// </summary>
	public readonly List<(short colorId, short partId, int nameId)> Crickets;

	/// <summary>
	/// 物品子类数据集合
	/// </summary>
	public readonly List<short> ItemSubTypes;

	/// <summary>
	/// 鸡数据集合
	/// </summary>
	public readonly List<short> Chickens;

	/// <summary>
	/// 角色属性引用类型数据集合
	/// </summary>
	public readonly List<short> CharacterPropertyReferencedTypes;

	/// <summary>
	/// 身体部位类型数据集合
	/// </summary>
	public readonly List<sbyte> BodyPartTypes;

	/// <summary>
	/// 伤势类型数据集合
	/// </summary>
	public readonly List<sbyte> InjuryTypes;

	/// <summary>
	/// 毒素类型数据集合
	/// </summary>
	public readonly List<sbyte> PoisonTypes;

	/// <summary>
	/// 角色模板数据集合
	/// </summary>
	public readonly List<short> CharacterTemplates;

	/// <summary>
	/// 角色特性数据集合
	/// </summary>
	public readonly List<short> Features;

	/// <summary>
	/// 整型数据集合
	/// </summary>
	public readonly List<int> Integers;

	/// <summary>
	/// 技艺数据集合
	/// </summary>
	public readonly List<short> LifeSkills;

	/// <summary>
	/// 商队类型集合
	/// </summary>
	public readonly List<sbyte> MerchantTypes;

	/// <summary>
	/// 物品实例Key的集合
	/// </summary>
	public readonly List<ulong> ItemKeys;

	/// <summary>
	/// 战斗类型集合
	/// </summary>
	public readonly List<sbyte> CombatTypes;

	/// <summary>
	/// 技艺类型集合
	/// </summary>
	public readonly List<sbyte> LifeSkillTypes;

	/// <summary>
	/// 功法类型集合
	/// </summary>
	public readonly List<sbyte> CombatSkillTypes;

	/// <summary>
	/// 见闻集合
	/// </summary>
	public readonly List<short> Informations;

	/// <summary>
	/// 秘闻模板集合
	/// </summary>
	public readonly List<short> SecretInformationTemplates;

	/// <summary>
	/// 惩罚类型集合
	/// </summary>
	public readonly List<short> PunishmentTypes;

	/// <summary>
	/// 角色称号集合
	/// </summary>
	public readonly List<short> CharacterTitles;

	/// <summary>
	/// 浮点数集合
	/// </summary>
	public readonly List<float> FloatValues;

	/// <summary>
	/// 角色真名集合
	/// </summary>
	public readonly List<int> CharacterRealNames;

	/// <summary>
	/// 月份集合
	/// </summary>
	public readonly List<sbyte> Months;

	/// <summary>
	/// 志向集合
	/// </summary>
	public readonly List<int> Professions;

	/// <summary>
	/// 志向技能集合
	/// </summary>
	public readonly List<int> ProfessionSkills;

	/// <summary>
	/// 品阶
	/// </summary>
	public readonly List<sbyte> ItemGrades;

	/// <summary>
	/// 文本
	/// </summary>
	public readonly List<string> Texts;

	/// <summary>
	/// 音乐
	/// </summary>
	public readonly List<short> Musics;

	/// <summary>
	/// 州域
	/// </summary>
	public readonly List<sbyte> MapStates;

	/// <summary>
	/// 蛟龙
	/// </summary>
	public readonly List<int> JiaoLoongs;

	/// <summary>
	/// 蛟龙属性
	/// </summary>
	public readonly List<short> JiaoProperties;

	/// <summary>
	/// 轮回类型
	/// </summary>
	public readonly List<sbyte> DestinyTypes;

	/// <summary>
	/// 秘闻实例集合
	/// </summary>
	public readonly List<(short templateId, int id)> SecretInformations;

	/// <summary>
	/// 商店
	/// </summary>
	public readonly List<sbyte> Merchants;

	/// <summary>
	/// 遗惠
	/// </summary>
	public readonly List<short> Legacys;

	/// <summary>
	/// 人物品级
	/// </summary>
	public readonly List<sbyte> CharGrades;

	/// <summary>
	/// 宴会
	/// </summary>
	public readonly List<short> Feasts;

	/// <summary>
	/// 奇遇元素
	/// </summary>
	public readonly List<int> AdventureElements;

	/// <summary>
	/// 七元
	/// </summary>
	public readonly List<sbyte> PersonalityTypes;

	/// <summary>
	/// 通用记录的实参的集合
	/// </summary>
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
		DestinyTypes.Clear();
		SecretInformations.Clear();
		Merchants.Clear();
		Legacys.Clear();
		CharGrades.Clear();
		Feasts.Clear();
		AdventureElements.Clear();
		PersonalityTypes.Clear();
	}

	/// <summary>
	/// 添加实参 - 角色
	/// </summary>
	/// <param name="charId"></param>
	/// <returns></returns>
	public int AddCharacter(int charId)
	{
		int count = Characters.Count;
		Characters.Add(charId);
		return count;
	}

	/// <summary>
	/// 添加实参 - 地点
	/// </summary>
	/// <param name="location"></param>
	/// <returns></returns>
	public int AddLocation(Location location)
	{
		int count = Locations.Count;
		Locations.Add(location);
		return count;
	}

	/// <summary>
	/// 添加实参 - 物品
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="itemTemplateId"></param>
	/// <returns></returns>
	public int AddItem(sbyte itemType, short itemTemplateId)
	{
		int count = Items.Count;
		Items.Add((itemType, itemTemplateId));
		return count;
	}

	/// <summary>
	/// 添加实参 - 功法
	/// </summary>
	/// <param name="combatSkillId"></param>
	/// <returns></returns>
	public int AddCombatSkill(short combatSkillId)
	{
		int count = CombatSkills.Count;
		CombatSkills.Add(combatSkillId);
		return count;
	}

	/// <summary>
	/// 添加实参 - 资源
	/// </summary>
	/// <param name="resourceType"></param>
	/// <returns></returns>
	public int AddResource(sbyte resourceType)
	{
		int count = Resources.Count;
		Resources.Add(resourceType);
		return count;
	}

	/// <summary>
	/// 添加实参 - 定居点
	/// </summary>
	/// <param name="settlementId"></param>
	/// <returns></returns>
	public int AddSettlement(short settlementId)
	{
		int count = Settlements.Count;
		Settlements.Add(settlementId);
		return count;
	}

	/// <summary>
	/// 添加实参 - 团体级别
	/// </summary>
	/// <param name="orgTemplateId"></param>
	/// <param name="orgGrade"></param>
	/// <param name="orgPrincipal"></param>
	/// <param name="gender"></param>
	/// <returns></returns>
	public int AddOrgGrade(sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender)
	{
		int count = OrgGrades.Count;
		OrgGrades.Add((orgTemplateId, orgGrade, orgPrincipal, gender));
		return count;
	}

	/// <summary>
	/// 添加实参 - 产业建筑
	/// </summary>
	/// <param name="buildingTemplateId"></param>
	/// <returns></returns>
	public int AddBuilding(short buildingTemplateId)
	{
		int count = Buildings.Count;
		Buildings.Add(buildingTemplateId);
		return count;
	}

	/// <summary>
	/// 添加实参 - 剑冢
	/// </summary>
	/// <param name="xiangshuAvatarId"></param>
	/// <returns></returns>
	public int AddSwordTomb(sbyte xiangshuAvatarId)
	{
		int count = SwordTombs.Count;
		SwordTombs.Add(xiangshuAvatarId);
		return count;
	}

	/// <summary>
	/// 添加实参 - 紫竹化身
	/// </summary>
	/// <param name="xiangshuAvatarId"></param>
	/// <returns></returns>
	public int AddJuniorXiangshu(sbyte xiangshuAvatarId)
	{
		int count = JuniorXiangshuList.Count;
		JuniorXiangshuList.Add(xiangshuAvatarId);
		return count;
	}

	/// <summary>
	/// 添加实参 - 奇遇
	/// </summary>
	/// <param name="adventureCoreId"></param>
	/// <returns></returns>
	public int AddAdventure(int adventureCoreId)
	{
		int count = Adventures.Count;
		Adventures.Add(adventureCoreId);
		return count;
	}

	/// <summary>
	/// 添加实参 - 角色立场
	/// </summary>
	/// <param name="behaviorType"></param>
	/// <returns></returns>
	public int AddBehaviorType(sbyte behaviorType)
	{
		int count = BehaviorTypes.Count;
		BehaviorTypes.Add(behaviorType);
		return count;
	}

	/// <summary>
	/// 添加实参 - 好感类型
	/// </summary>
	/// <param name="favorabilityType"></param>
	/// <returns></returns>
	public int AddFavorabilityType(sbyte favorabilityType)
	{
		int count = FavorabilityTypes.Count;
		FavorabilityTypes.Add(favorabilityType);
		return count;
	}

	/// <summary>
	/// 添加实参 - 促织
	/// </summary>
	/// <param name="colorId"></param>
	/// <param name="partId"></param>
	/// <param name="nameId"></param>
	/// <returns></returns>
	public int AddCricket(short colorId, short partId, int nameId)
	{
		int count = Crickets.Count;
		Crickets.Add((colorId, partId, nameId));
		return count;
	}

	/// <summary>
	/// 添加实参 - 物品子类
	/// </summary>
	/// <param name="itemSubType"></param>
	/// <returns></returns>
	public int AddItemSubType(short itemSubType)
	{
		int count = ItemSubTypes.Count;
		ItemSubTypes.Add(itemSubType);
		return count;
	}

	/// <summary>
	/// 添加实参 - 鸡
	/// </summary>
	/// <param name="chickenId"></param>
	/// <returns></returns>
	public int AddChicken(short chickenId)
	{
		int count = Chickens.Count;
		Chickens.Add(chickenId);
		return count;
	}

	/// <summary>
	/// 添加实参 - 角色属性引用类型
	/// </summary>
	/// <param name="characterPropertyReferencedType"></param>
	/// <returns></returns>
	public int AddCharacterPropertyReferencedType(short characterPropertyReferencedType)
	{
		int count = CharacterPropertyReferencedTypes.Count;
		CharacterPropertyReferencedTypes.Add(characterPropertyReferencedType);
		return count;
	}

	/// <summary>
	/// 添加实参 - 身体部位类型
	/// </summary>
	/// <param name="bodyPartType"></param>
	/// <returns></returns>
	public int AddBodyPartType(sbyte bodyPartType)
	{
		int count = BodyPartTypes.Count;
		BodyPartTypes.Add(bodyPartType);
		return count;
	}

	/// <summary>
	/// 添加实参 - 伤势类型
	/// </summary>
	/// <param name="injuryType"></param>
	/// <returns></returns>
	public int AddInjuryType(sbyte injuryType)
	{
		int count = InjuryTypes.Count;
		InjuryTypes.Add(injuryType);
		return count;
	}

	/// <summary>
	/// 添加实参 - 毒素类型
	/// </summary>
	/// <param name="poisonType"></param>
	/// <returns></returns>
	public int AddPoisonType(sbyte poisonType)
	{
		int count = PoisonTypes.Count;
		PoisonTypes.Add(poisonType);
		return count;
	}

	/// <summary>
	/// 添加实参 - 整型数值
	/// </summary>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public int AddCharacterTemplate(short templateId)
	{
		int count = CharacterTemplates.Count;
		CharacterTemplates.Add(templateId);
		return count;
	}

	/// <summary>
	/// 添加实参 - 角色特性
	/// </summary>
	/// <param name="featureId"></param>
	/// <returns></returns>
	public int AddFeature(short featureId)
	{
		int count = Features.Count;
		Features.Add(featureId);
		return count;
	}

	/// <summary>
	/// 添加实参 - 整型数值
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	public int AddInteger(int value)
	{
		int count = Integers.Count;
		Integers.Add(value);
		return count;
	}

	/// <summary>
	/// 添加实参 - 技艺名
	/// </summary>
	/// <param name="lifeSkillTemplateId"></param>
	/// <returns></returns>
	public int AddLifeSkill(short lifeSkillTemplateId)
	{
		int count = LifeSkills.Count;
		LifeSkills.Add(lifeSkillTemplateId);
		return count;
	}

	/// <summary>
	/// 添加实参 - 商队类型
	/// </summary>
	/// <param name="merchantType"></param>
	/// <returns></returns>
	public int AddMerchantType(sbyte merchantType)
	{
		int count = MerchantTypes.Count;
		MerchantTypes.Add(merchantType);
		return count;
	}

	/// <summary>
	/// 添加实参 - 物品实例Key
	/// </summary>
	/// <param name="itemKey"></param>
	/// <returns></returns>
	public int AddItemKey(ulong itemKey)
	{
		int count = ItemKeys.Count;
		ItemKeys.Add(itemKey);
		return count;
	}

	/// <summary>
	/// 添加实参 - 战斗类型
	/// </summary>
	/// <param name="combatType"></param>
	/// <returns></returns>
	public int AddCombatType(sbyte combatType)
	{
		int count = CombatTypes.Count;
		CombatTypes.Add(combatType);
		return count;
	}

	/// <summary>
	/// 添加实参 - 技艺类型
	/// </summary>
	/// <param name="lifeSkillType"></param>
	/// <returns></returns>
	public int AddLifeSkillType(sbyte lifeSkillType)
	{
		int count = LifeSkillTypes.Count;
		LifeSkillTypes.Add(lifeSkillType);
		return count;
	}

	/// <summary>
	/// 添加实参 - 功法类型
	/// </summary>
	/// <param name="combatSkillType"></param>
	/// <returns></returns>
	public int AddCombatSkillType(sbyte combatSkillType)
	{
		int count = CombatSkillTypes.Count;
		CombatSkillTypes.Add(combatSkillType);
		return count;
	}

	/// <summary>
	/// 添加实参 - 见闻
	/// </summary>
	/// <param name="infoTemplateId"></param>
	/// <returns></returns>
	public int AddInformation(short infoTemplateId)
	{
		int count = Informations.Count;
		Informations.Add(infoTemplateId);
		return count;
	}

	/// <summary>
	/// 添加实参 - 秘闻模板
	/// </summary>
	/// <param name="secretInfoTemplateId"></param>
	/// <returns></returns>
	public int AddSecretInformationTemplate(short secretInfoTemplateId)
	{
		int count = SecretInformationTemplates.Count;
		SecretInformationTemplates.Add(secretInfoTemplateId);
		return count;
	}

	/// <summary>
	/// 添加实参 - 惩罚类型
	/// </summary>
	/// <param name="punishmentType"></param>
	/// <returns></returns>
	public int AddPunishmentType(short punishmentType)
	{
		int count = PunishmentTypes.Count;
		PunishmentTypes.Add(punishmentType);
		return count;
	}

	/// <summary>
	/// 添加实参 - 角色称号
	/// </summary>
	/// <param name="titleTemplateId"></param>
	/// <returns></returns>
	public int AddCharacterTitle(short titleTemplateId)
	{
		int count = CharacterTitles.Count;
		CharacterTitles.Add(titleTemplateId);
		return count;
	}

	/// <summary>
	/// 添加实参 - 浮点数类型
	/// </summary>
	/// <param name="floatValue"></param>
	/// <returns></returns>
	public int AddFloat(float floatValue)
	{
		int count = FloatValues.Count;
		FloatValues.Add(floatValue);
		return count;
	}

	/// <summary>
	/// 添加实参 - 角色真名
	/// </summary>
	/// <param name="charId"></param>
	/// <returns></returns>
	public int AddCharacterRealName(int charId)
	{
		int count = CharacterRealNames.Count;
		CharacterRealNames.Add(charId);
		return count;
	}

	/// <summary>
	/// 添加实参 - 月份
	/// </summary>
	/// <param name="month"></param>
	/// <returns></returns>
	public int AddMonth(sbyte month)
	{
		int count = Months.Count;
		Months.Add(month);
		return count;
	}

	/// <summary>
	/// 添加实参 - 志向
	/// </summary>
	/// <param name="professionTemplateId"></param>
	/// <returns></returns>
	public int AddProfession(int professionTemplateId)
	{
		int count = Professions.Count;
		Professions.Add(professionTemplateId);
		return count;
	}

	/// <summary>
	/// 添加实参 - 志向技能
	/// </summary>
	/// <param name="skillTemplateId"></param>
	/// <returns></returns>
	public int AddProfessionSkill(int skillTemplateId)
	{
		int count = ProfessionSkills.Count;
		ProfessionSkills.Add(skillTemplateId);
		return count;
	}

	/// <summary>
	/// 添加实参 - 物品品阶
	/// </summary>
	/// <param name="grade"></param>
	/// <returns></returns>
	public int AddItemGrade(sbyte grade)
	{
		int count = ItemGrades.Count;
		ItemGrades.Add(grade);
		return count;
	}

	/// <summary>
	/// 添加实参 - 文本
	/// </summary>
	/// <param name="text"></param>
	/// <returns></returns>
	public int AddText(string text)
	{
		int count = Texts.Count;
		Texts.Add(text);
		return count;
	}

	/// <summary>
	/// 添加实参 - 音乐
	/// </summary>
	/// <param name="musicTemplateId"></param>
	/// <returns></returns>
	public int AddMusic(short musicTemplateId)
	{
		int count = Musics.Count;
		Musics.Add(musicTemplateId);
		return count;
	}

	/// <summary>
	/// 添加实参 - 州域
	/// </summary>
	/// <param name="stateTemplateId"></param>
	/// <returns></returns>
	public int AddMapState(sbyte stateTemplateId)
	{
		int count = MapStates.Count;
		MapStates.Add(stateTemplateId);
		return count;
	}

	/// <summary>
	/// 添加实参 - 蛟龙
	/// </summary>
	/// <param name="jiaoLoongId"></param>
	/// <returns></returns>
	public int AddJiaoLoong(int jiaoLoongId)
	{
		int count = JiaoLoongs.Count;
		JiaoLoongs.Add(jiaoLoongId);
		return count;
	}

	/// <summary>
	/// 添加实参 - 蛟的属性
	/// </summary>
	/// <param name="jiaoPropertyId"></param>
	/// <returns></returns>
	public int AddJiaoProperty(short jiaoPropertyId)
	{
		int count = JiaoProperties.Count;
		JiaoProperties.Add(jiaoPropertyId);
		return count;
	}

	/// <summary>
	/// 添加实参 - 轮回类型
	/// </summary>
	/// <param name="destinyType"></param>
	/// <returns></returns>
	public int AddDestinyType(sbyte destinyType)
	{
		int count = DestinyTypes.Count;
		DestinyTypes.Add(destinyType);
		return count;
	}

	/// <summary>
	/// 添加实参 - 秘闻实例
	/// </summary>
	/// <param name="templateId"></param>
	/// <param name="id"></param>
	/// <returns></returns>
	public int AddSecretInformation(short templateId, int id)
	{
		int count = SecretInformations.Count;
		SecretInformations.Add((templateId, id));
		return count;
	}

	/// <summary>
	/// 添加实参 - 商店
	/// </summary>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public int AddMerchant(sbyte templateId)
	{
		int count = Merchants.Count;
		Merchants.Add(templateId);
		return count;
	}

	/// <summary>
	/// 添加实参 - 遗惠
	/// </summary>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public int AddLegacy(short templateId)
	{
		int count = Legacys.Count;
		Legacys.Add(templateId);
		return count;
	}

	/// <summary>
	/// 添加实参 - 人物品级
	/// </summary>
	/// <param name="grade"></param>
	/// <returns></returns>
	public int AddCharGrade(sbyte grade)
	{
		int count = CharGrades.Count;
		CharGrades.Add(grade);
		return count;
	}

	/// <summary>
	/// 添加实参 - 宴席
	/// </summary>
	/// <param name="feast"></param>
	/// <returns></returns>
	public int AddFeast(short feast)
	{
		int count = Feasts.Count;
		Feasts.Add(feast);
		return count;
	}

	/// <summary>
	/// 添加实参 - 奇遇元素
	/// </summary>
	/// <param name="elementCoreId"></param>
	/// <returns></returns>
	public int AddAdventureElement(int elementCoreId)
	{
		int count = AdventureElements.Count;
		AdventureElements.Add(elementCoreId);
		return count;
	}

	/// <summary>
	/// 添加实参 - 七元
	/// </summary>
	/// <param name="personalityType"></param>
	/// <returns></returns>
	public int AddPersonalityType(sbyte personalityType)
	{
		int count = PersonalityTypes.Count;
		PersonalityTypes.Add(personalityType);
		return count;
	}
}
