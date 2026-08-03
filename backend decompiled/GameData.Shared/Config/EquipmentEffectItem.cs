using System;
using Config.Common;
using GameData.Domains.Character;

namespace Config;

[Serializable]
public class EquipmentEffectItem : ConfigItem<EquipmentEffectItem, short>
{
	/// <summary>
	/// ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 类型
	/// - 0.兵器、护具、宝物 1.兵器 2.护具
	/// </summary>
	public readonly sbyte Type;

	/// <summary>
	/// 特殊
	/// - 特殊特效不会随机生成在装备上
	/// </summary>
	public readonly bool Special;

	/// <summary>
	/// 是否 C 类
	/// - 此列为假值时，加成大部分为 B 类
	/// </summary>
	public readonly bool IsTotalPercent;

	/// <summary>
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 命中因子
	/// - 以加减法直接增加武器的基础命中因子 BaseHitFactors
	/// </summary>
	public readonly short[] HitFactors;

	/// <summary>
	/// 化解因子
	/// - 以乘算影响防具的基础化解因子 BaseAvoidFactors
	/// </summary>
	public readonly HitOrAvoidShorts AvoidFactors;

	/// <summary>
	/// 防御因子
	/// - 以乘算影响防具的防御因子 BasePenetrationResistFactors
	/// </summary>
	public readonly OuterAndInnerShorts PenetrationResistFactors;

	/// <summary>
	/// 减伤因子
	/// - 以乘算影响防具的减伤因子 BaseInjuryFactors
	/// </summary>
	public readonly OuterAndInnerShorts InjuryFactors;

	/// <summary>
	/// 破刃/破甲百分比变化
	/// </summary>
	public readonly int EquipmentAttackChange;

	/// <summary>
	/// 坚韧百分比变化
	/// </summary>
	public readonly int EquipmentDefenseChange;

	/// <summary>
	/// 重量百分比变化
	/// </summary>
	public readonly int WeightChange;

	/// <summary>
	/// 耐久百分比变化
	/// - 不可用于生铸词条的效果，如需适配则应补充对应需求
	/// </summary>
	public readonly int MaxDurabilityChange;

	/// <summary>
	/// 价值百分比变化
	/// </summary>
	public readonly int ValueChange;

	/// <summary>
	/// 喜爱百分比变化
	/// </summary>
	public readonly int FavorChange;

	/// <summary>
	/// 发挥需求百分比变化
	/// </summary>
	public readonly int RequirementChange;

	/// <summary>
	/// 特效类名
	/// - 用于仅在战斗中生效的词条
	/// </summary>
	public readonly string EffectClassName;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">ID</param>
	/// <param name="name">名称</param>
	/// <param name="type">类型 - 0.兵器、护具、宝物 1.兵器 2.护具</param>
	/// <param name="special">特殊 - 特殊特效不会随机生成在装备上</param>
	/// <param name="isTotalPercent">是否 C 类 - 此列为假值时，加成大部分为 B 类</param>
	/// <param name="desc">说明</param>
	/// <param name="hitFactors">命中因子 - 以加减法直接增加武器的基础命中因子 BaseHitFactors</param>
	/// <param name="avoidFactors">化解因子 - 以乘算影响防具的基础化解因子 BaseAvoidFactors</param>
	/// <param name="penetrationResistFactors">防御因子 - 以乘算影响防具的防御因子 BasePenetrationResistFactors</param>
	/// <param name="injuryFactors">减伤因子 - 以乘算影响防具的减伤因子 BaseInjuryFactors</param>
	/// <param name="equipmentAttackChange">破刃/破甲百分比变化</param>
	/// <param name="equipmentDefenseChange">坚韧百分比变化</param>
	/// <param name="weightChange">重量百分比变化</param>
	/// <param name="maxDurabilityChange">耐久百分比变化 - 不可用于生铸词条的效果，如需适配则应补充对应需求</param>
	/// <param name="valueChange">价值百分比变化</param>
	/// <param name="favorChange">喜爱百分比变化</param>
	/// <param name="requirementChange">发挥需求百分比变化</param>
	/// <param name="effectClassName">特效类名 - 用于仅在战斗中生效的词条</param>
	public EquipmentEffectItem(short templateId, string name, sbyte type, bool special, bool isTotalPercent, string desc, short[] hitFactors, HitOrAvoidShorts avoidFactors, OuterAndInnerShorts penetrationResistFactors, OuterAndInnerShorts injuryFactors, int equipmentAttackChange, int equipmentDefenseChange, int weightChange, int maxDurabilityChange, int valueChange, int favorChange, int requirementChange, string effectClassName)
	{
		TemplateId = templateId;
		Name = name;
		Type = type;
		Special = special;
		IsTotalPercent = isTotalPercent;
		Desc = desc;
		HitFactors = hitFactors;
		AvoidFactors = avoidFactors;
		PenetrationResistFactors = penetrationResistFactors;
		InjuryFactors = injuryFactors;
		EquipmentAttackChange = equipmentAttackChange;
		EquipmentDefenseChange = equipmentDefenseChange;
		WeightChange = weightChange;
		MaxDurabilityChange = maxDurabilityChange;
		ValueChange = valueChange;
		FavorChange = favorChange;
		RequirementChange = requirementChange;
		EffectClassName = effectClassName;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public EquipmentEffectItem()
	{
		TemplateId = 0;
		Name = null;
		Type = -1;
		Special = false;
		IsTotalPercent = false;
		Desc = null;
		HitFactors = new short[4];
		AvoidFactors = new HitOrAvoidShorts(default(short), default(short), default(short), default(short));
		PenetrationResistFactors = new OuterAndInnerShorts(0, 0);
		InjuryFactors = new OuterAndInnerShorts(0, 0);
		EquipmentAttackChange = 0;
		EquipmentDefenseChange = 0;
		WeightChange = 0;
		MaxDurabilityChange = 0;
		ValueChange = 0;
		FavorChange = 0;
		RequirementChange = 0;
		EffectClassName = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public EquipmentEffectItem(short templateId, EquipmentEffectItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Type = other.Type;
		Special = other.Special;
		IsTotalPercent = other.IsTotalPercent;
		Desc = other.Desc;
		HitFactors = other.HitFactors;
		AvoidFactors = other.AvoidFactors;
		PenetrationResistFactors = other.PenetrationResistFactors;
		InjuryFactors = other.InjuryFactors;
		EquipmentAttackChange = other.EquipmentAttackChange;
		EquipmentDefenseChange = other.EquipmentDefenseChange;
		WeightChange = other.WeightChange;
		MaxDurabilityChange = other.MaxDurabilityChange;
		ValueChange = other.ValueChange;
		FavorChange = other.FavorChange;
		RequirementChange = other.RequirementChange;
		EffectClassName = other.EffectClassName;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override EquipmentEffectItem Duplicate(int templateId)
	{
		return new EquipmentEffectItem((short)templateId, this);
	}
}
