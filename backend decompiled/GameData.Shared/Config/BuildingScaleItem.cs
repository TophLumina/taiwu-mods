using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Utilities;

namespace Config;

[Serializable]
public class BuildingScaleItem : ConfigItem<BuildingScaleItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 条目描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 条目名称
	/// - 最多6个字
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 条目类型
	/// </summary>
	public readonly EBuildingScaleClass Class;

	/// <summary>
	/// 展现类型
	/// </summary>
	public readonly EBuildingScaleType Type;

	/// <summary>
	/// 条目效果
	/// </summary>
	public readonly EBuildingScaleEffect Effect;

	/// <summary>
	/// 对应武学类型
	/// </summary>
	public readonly sbyte CombatSkillType;

	/// <summary>
	/// 对应技艺类型
	/// </summary>
	public readonly sbyte LifeSkillType;

	/// <summary>
	/// 所属DLC
	/// </summary>
	public readonly uint DlcAppId;

	/// <summary>
	/// 资源类型
	/// </summary>
	public readonly sbyte ResourceType;

	/// <summary>
	/// 效果公式
	/// </summary>
	public readonly int Formula;

	/// <summary>
	/// 等级效果
	/// </summary>
	public readonly List<int> LevelEffect;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="desc">条目描述</param>
	/// <param name="name">条目名称 - 最多6个字</param>
	/// <param name="enumClass">条目类型</param>
	/// <param name="type">展现类型</param>
	/// <param name="effect">条目效果</param>
	/// <param name="combatSkillType">对应武学类型</param>
	/// <param name="lifeSkillType">对应技艺类型</param>
	/// <param name="dlcAppId">所属DLC</param>
	/// <param name="resourceType">资源类型</param>
	/// <param name="formula">效果公式</param>
	/// <param name="levelEffect">等级效果</param>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override BuildingScaleItem Duplicate(int templateId)
	{
		return new BuildingScaleItem((short)templateId, this);
	}

	/// <summary>
	/// 计算等级效果
	/// </summary>
	/// <param name="level"></param>
	/// <returns></returns>
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
