using System;
using Config.Common;
using Config.ConfigCells.Character;

namespace Config;

[Serializable]
public class SkillBreakPlateGridBonusTypeItem : ConfigItem<SkillBreakPlateGridBonusTypeItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly bool IsExtraBonus;

	public readonly sbyte[] ExtraBonusFitCombatSkillTypes;

	public readonly sbyte[] ExtraBonusFitLifeSkillTypes;

	public readonly short[] ExtraBonusFitItemSubTypes;

	public readonly PropertyAndValue[] CharacterPropertyBonusList;

	public readonly PropertyAndValue[] CombatSkillPropertyBonusList;

	public readonly ESkillBreakPlateGridBonusTypeAppearType AppearType;

	public readonly sbyte FilterGroup;

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

	public override SkillBreakPlateGridBonusTypeItem Duplicate(int templateId)
	{
		return new SkillBreakPlateGridBonusTypeItem((short)templateId, this);
	}
}
