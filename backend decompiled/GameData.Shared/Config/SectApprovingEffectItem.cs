using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SectApprovingEffectItem : ConfigItem<SectApprovingEffectItem, sbyte>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 图标
	/// </summary>
	public readonly string Icon;

	/// <summary>
	/// 技艺取代
	/// - 配置值为技艺类型. 在研读, 修习, 突破时, 若需求的技艺或武学类型的资质或造诣值低于配置的类型的对应值, 那么就用配置的类型的对应值替换需求值. 如果有多个备选替换值, 则选择最高的替换.
	/// </summary>
	public readonly List<sbyte> RequirementSubstitutions;

	/// <summary>
	/// 正逆练加成
	/// - 篇章正逆练类型对研读效率的加成. 不影响总纲.索引: 正练, 逆练.
	/// </summary>
	public readonly short[] CombatSkillDirectionBonuses;

	/// <summary>
	/// 立场加成
	/// - 修习者立场对研读效率的加成. 不影响总纲.索引: 刚正, 仁善, 中庸, 叛逆, 唯我.
	/// </summary>
	public readonly short[] BehaviorTypeBonuses;

	/// <summary>
	/// 男
	/// - 每页普通书页的研读效率加成. 不影响总纲.
	/// </summary>
	public readonly short[] PageBonusesOfMale;

	/// <summary>
	/// 女
	/// - 每页普通书页的研读效率加成. 不影响总纲.
	/// </summary>
	public readonly short[] PageBonusesOfFemale;

	/// <summary>
	/// 男
	/// - 以实战方式研读的成功率加成. 不影响总纲.
	/// </summary>
	public readonly short ActualCombatBonusOfMale;

	/// <summary>
	/// 女
	/// - 以实战方式研读的成功率加成. 不影响总纲.
	/// </summary>
	public readonly short ActualCombatBonusOfFemale;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">名称</param>
	/// <param name="desc">描述</param>
	/// <param name="icon">图标</param>
	/// <param name="requirementSubstitutions">技艺取代 - 配置值为技艺类型. 在研读, 修习, 突破时, 若需求的技艺或武学类型的资质或造诣值低于配置的类型的对应值, 那么就用配置的类型的对应值替换需求值. 如果有多个备选替换值, 则选择最高的替换.</param>
	/// <param name="combatSkillDirectionBonuses">正逆练加成 - 篇章正逆练类型对研读效率的加成. 不影响总纲.索引: 正练, 逆练.</param>
	/// <param name="behaviorTypeBonuses">立场加成 - 修习者立场对研读效率的加成. 不影响总纲.索引: 刚正, 仁善, 中庸, 叛逆, 唯我.</param>
	/// <param name="pageBonusesOfMale">男 - 每页普通书页的研读效率加成. 不影响总纲.</param>
	/// <param name="pageBonusesOfFemale">女 - 每页普通书页的研读效率加成. 不影响总纲.</param>
	/// <param name="actualCombatBonusOfMale">男 - 以实战方式研读的成功率加成. 不影响总纲.</param>
	/// <param name="actualCombatBonusOfFemale">女 - 以实战方式研读的成功率加成. 不影响总纲.</param>
	public SectApprovingEffectItem(sbyte templateId, string name, string desc, string icon, List<sbyte> requirementSubstitutions, short[] combatSkillDirectionBonuses, short[] behaviorTypeBonuses, short[] pageBonusesOfMale, short[] pageBonusesOfFemale, short actualCombatBonusOfMale, short actualCombatBonusOfFemale)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Icon = icon;
		RequirementSubstitutions = requirementSubstitutions;
		CombatSkillDirectionBonuses = combatSkillDirectionBonuses;
		BehaviorTypeBonuses = behaviorTypeBonuses;
		PageBonusesOfMale = pageBonusesOfMale;
		PageBonusesOfFemale = pageBonusesOfFemale;
		ActualCombatBonusOfMale = actualCombatBonusOfMale;
		ActualCombatBonusOfFemale = actualCombatBonusOfFemale;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SectApprovingEffectItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Icon = null;
		RequirementSubstitutions = new List<sbyte>();
		CombatSkillDirectionBonuses = new short[2] { 100, 100 };
		BehaviorTypeBonuses = new short[5] { 100, 100, 100, 100, 100 };
		PageBonusesOfMale = new short[5] { 100, 100, 100, 100, 100 };
		PageBonusesOfFemale = new short[5] { 100, 100, 100, 100, 100 };
		ActualCombatBonusOfMale = 100;
		ActualCombatBonusOfFemale = 100;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public SectApprovingEffectItem(sbyte templateId, SectApprovingEffectItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Icon = other.Icon;
		RequirementSubstitutions = other.RequirementSubstitutions;
		CombatSkillDirectionBonuses = other.CombatSkillDirectionBonuses;
		BehaviorTypeBonuses = other.BehaviorTypeBonuses;
		PageBonusesOfMale = other.PageBonusesOfMale;
		PageBonusesOfFemale = other.PageBonusesOfFemale;
		ActualCombatBonusOfMale = other.ActualCombatBonusOfMale;
		ActualCombatBonusOfFemale = other.ActualCombatBonusOfFemale;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SectApprovingEffectItem Duplicate(int templateId)
	{
		return new SectApprovingEffectItem((sbyte)templateId, this);
	}
}
