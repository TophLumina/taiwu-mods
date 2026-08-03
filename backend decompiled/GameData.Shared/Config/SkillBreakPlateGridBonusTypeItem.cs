using System;
using Config.Common;
using Config.ConfigCells.Character;

namespace Config;

[Serializable]
public class SkillBreakPlateGridBonusTypeItem : ConfigItem<SkillBreakPlateGridBonusTypeItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 是否独创心法
	/// </summary>
	public readonly bool IsExtraBonus;

	/// <summary>
	/// 独创心法适宜功法类型
	/// - 物品为功法书时判断对应功法是否为该类型
	/// </summary>
	public readonly sbyte[] ExtraBonusFitCombatSkillTypes;

	/// <summary>
	/// 独创心法适宜技艺类型
	/// - 物品为技艺书时判断对应功法是否为该类型
	/// </summary>
	public readonly sbyte[] ExtraBonusFitLifeSkillTypes;

	/// <summary>
	/// 独创心法适宜物品子类
	/// - 判断物品子类是否为该类型，参见 GameData.Domains.Item.ItemSubType
	/// </summary>
	public readonly short[] ExtraBonusFitItemSubTypes;

	/// <summary>
	/// 提供运功属性
	/// - 运功属性对应CharacterPropertyReferenced表，改变的是功法的PropertyAddList
	/// </summary>
	public readonly PropertyAndValue[] CharacterPropertyBonusList;

	/// <summary>
	/// 提供功法属性
	/// - 功法属性，对应CombatSkillProperty表，改变的是功法的其它属性
	/// </summary>
	public readonly PropertyAndValue[] CombatSkillPropertyBonusList;

	/// <summary>
	/// 出现条件
	/// </summary>
	public readonly ESkillBreakPlateGridBonusTypeAppearType AppearType;

	/// <summary>
	/// 分类
	/// - 用于筛选和图形显示的分类，0通常、1内功、2摧破、3轻灵、4护体
	/// </summary>
	public readonly sbyte FilterGroup;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="desc">描述</param>
	/// <param name="isExtraBonus">是否独创心法</param>
	/// <param name="extraBonusFitCombatSkillTypes">独创心法适宜功法类型 - 物品为功法书时判断对应功法是否为该类型</param>
	/// <param name="extraBonusFitLifeSkillTypes">独创心法适宜技艺类型 - 物品为技艺书时判断对应功法是否为该类型</param>
	/// <param name="extraBonusFitItemSubTypes">独创心法适宜物品子类 - 判断物品子类是否为该类型，参见 GameData.Domains.Item.ItemSubType</param>
	/// <param name="characterPropertyBonusList">提供运功属性 - 运功属性对应CharacterPropertyReferenced表，改变的是功法的PropertyAddList</param>
	/// <param name="combatSkillPropertyBonusList">提供功法属性 - 功法属性，对应CombatSkillProperty表，改变的是功法的其它属性</param>
	/// <param name="appearType">出现条件</param>
	/// <param name="filterGroup">分类 - 用于筛选和图形显示的分类，0通常、1内功、2摧破、3轻灵、4护体</param>
	public SkillBreakPlateGridBonusTypeItem(short templateId, string name, string desc, bool isExtraBonus, sbyte[] extraBonusFitCombatSkillTypes, sbyte[] extraBonusFitLifeSkillTypes, short[] extraBonusFitItemSubTypes, PropertyAndValue[] characterPropertyBonusList, PropertyAndValue[] combatSkillPropertyBonusList, ESkillBreakPlateGridBonusTypeAppearType appearType, sbyte filterGroup)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		IsExtraBonus = isExtraBonus;
		ExtraBonusFitCombatSkillTypes = extraBonusFitCombatSkillTypes;
		ExtraBonusFitLifeSkillTypes = extraBonusFitLifeSkillTypes;
		ExtraBonusFitItemSubTypes = extraBonusFitItemSubTypes;
		CharacterPropertyBonusList = characterPropertyBonusList;
		CombatSkillPropertyBonusList = combatSkillPropertyBonusList;
		AppearType = appearType;
		FilterGroup = filterGroup;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SkillBreakPlateGridBonusTypeItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		IsExtraBonus = false;
		ExtraBonusFitCombatSkillTypes = new sbyte[0];
		ExtraBonusFitLifeSkillTypes = new sbyte[0];
		ExtraBonusFitItemSubTypes = new short[0];
		CharacterPropertyBonusList = new PropertyAndValue[0];
		CombatSkillPropertyBonusList = new PropertyAndValue[0];
		AppearType = ESkillBreakPlateGridBonusTypeAppearType.Never;
		FilterGroup = -1;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public SkillBreakPlateGridBonusTypeItem(short templateId, SkillBreakPlateGridBonusTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		IsExtraBonus = other.IsExtraBonus;
		ExtraBonusFitCombatSkillTypes = other.ExtraBonusFitCombatSkillTypes;
		ExtraBonusFitLifeSkillTypes = other.ExtraBonusFitLifeSkillTypes;
		ExtraBonusFitItemSubTypes = other.ExtraBonusFitItemSubTypes;
		CharacterPropertyBonusList = other.CharacterPropertyBonusList;
		CombatSkillPropertyBonusList = other.CombatSkillPropertyBonusList;
		AppearType = other.AppearType;
		FilterGroup = other.FilterGroup;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SkillBreakPlateGridBonusTypeItem Duplicate(int templateId)
	{
		return new SkillBreakPlateGridBonusTypeItem((short)templateId, this);
	}
}
