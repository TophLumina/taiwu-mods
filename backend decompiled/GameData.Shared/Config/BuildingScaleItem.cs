using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Utilities;

namespace Config;

[Serializable]
public class BuildingScaleItem : ConfigItem<BuildingScaleItem, short>
{
	public readonly short TemplateId;

	public readonly string Desc;

	public readonly string Name;

	public readonly EBuildingScaleClass Class;

	public readonly EBuildingScaleType Type;

	public readonly EBuildingScaleEffect Effect;

	public readonly sbyte CombatSkillType;

	public readonly sbyte LifeSkillType;

	public readonly uint DlcAppId;

	public readonly sbyte ResourceType;

	public readonly int Formula;

	public readonly List<int> LevelEffect;

	public BuildingScaleItem(short templateId, string desc, string name, EBuildingScaleClass enumClass, EBuildingScaleType type, EBuildingScaleEffect effect, sbyte combatSkillType, sbyte lifeSkillType, uint dlcAppId, sbyte resourceType, int formula, List<int> levelEffect)
	{
		TemplateId = templateId;
		Desc = desc;
		Name = name;
		Class = enumClass;
		Type = type;
		Effect = effect;
		CombatSkillType = combatSkillType;
		LifeSkillType = lifeSkillType;
		DlcAppId = dlcAppId;
		ResourceType = resourceType;
		Formula = formula;
		LevelEffect = levelEffect;
	}

	public BuildingScaleItem()
	{
		TemplateId = 0;
		Desc = null;
		Name = null;
		Class = EBuildingScaleClass.Invalid;
		Type = EBuildingScaleType.Int;
		Effect = EBuildingScaleEffect.Invalid;
		CombatSkillType = 0;
		LifeSkillType = 0;
		DlcAppId = 0u;
		ResourceType = 0;
		Formula = 0;
		LevelEffect = null;
	}

	public BuildingScaleItem(short templateId, BuildingScaleItem other)
	{
		TemplateId = templateId;
		Desc = other.Desc;
		Name = other.Name;
		Class = other.Class;
		Type = other.Type;
		Effect = other.Effect;
		CombatSkillType = other.CombatSkillType;
		LifeSkillType = other.LifeSkillType;
		DlcAppId = other.DlcAppId;
		ResourceType = other.ResourceType;
		Formula = other.Formula;
		LevelEffect = other.LevelEffect;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override BuildingScaleItem Duplicate(int templateId)
	{
		return new BuildingScaleItem((short)templateId, this);
	}

	public int GetLevelEffect(int level)
	{
		List<int> levelEffect = LevelEffect;
		if (levelEffect == null || levelEffect.Count <= 0)
		{
			return 0;
		}
		return LevelEffect.GetOrLast(level - 1);
	}
}
