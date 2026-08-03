using System;
using Config.Common;

namespace Config;

[Serializable]
public class SkillBreakBonusEffectImplementItem : ConfigItem<SkillBreakBonusEffectImplementItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 增加造诣类型
	/// - 以对应造诣增加功法中的所有技艺造诣需求的造诣，增加的造诣 = 对应技艺造诣*(道具品级+2)*1/100，最小为 1，多个玄机增加的造诣叠加
	/// </summary>
	public readonly sbyte AddRequirementType;

	/// <summary>
	/// 降低提气消耗造诣类型
	/// - 降低功法的提气消耗，按百分比降低，降低的量 = 对应技艺造诣*(道具品级+2)/1000，最小为1，最大为5
	/// </summary>
	public readonly sbyte ReduceCostBreathType;

	/// <summary>
	/// 降低架势消耗造诣类型
	/// - 降低功法的架势消耗，按百分比降低，降低的量 = 对应技艺造诣*(道具品级+2)/1000，最小为1，最大为5
	/// </summary>
	public readonly sbyte ReduceCostStanceType;

	/// <summary>
	/// 降低施展耗时造诣类型
	/// - 降低功法的施展耗时，按百分比降低，降低的量 = 对应技艺造诣*(道具品级+2)/500，最小为1，最大为10
	/// </summary>
	public readonly sbyte ReduceCastFrameType;

	/// <summary>
	/// 增加威力上限类型
	/// - 增加功法的发挥上限，增加的量 = 对应技艺造诣*(玄机品级+2)/500，最小为1，最大为10
	/// </summary>
	public readonly sbyte AddMaxPowerType;

	/// <summary>
	/// 增加伤势强健
	/// - 根据丹药的外伤或内伤治疗区别，提高功法的外伤或内伤强健（如果功法本身没有对应强健，就无效），按百分比提高，提高的百分比 =  5+(丹药品级+2)*2
	/// </summary>
	public readonly bool AddInjuryStep;

	/// <summary>
	/// 增加重创强健
	/// - 提高功法的重创强健（如果功法本身没有重创强健，就无效），按百分比提高，提高的百分比 = 5+(丹药品级+2)*2
	/// </summary>
	public readonly bool AddFatalStep;

	/// <summary>
	/// 增加失神强健
	/// - 提高功法的心神强健（如果功法本身没有心神强健，就无效），按百分比提高，提高的百分比 = 5+(丹药品级+2)*2
	/// </summary>
	public readonly bool AddMindStep;

	/// <summary>
	/// 运功增加毒抗
	/// - 根据丹药增加的毒抗，使功法获得增加对应毒抗的运功效果 = 丹药品级+2（A类）此列配置值为公式结果的额外百分比修正，配100时保持原值
	/// </summary>
	public readonly int PoisonResistFactor;

	/// <summary>
	/// 运功增加攻击
	/// - 根据丹药增加的命中化解攻防属性，使功法获得增加对应命中化解攻防属性的运功效果 = (丹药品级+2)*3（A类）此列配置值为公式中【*3】的部分
	/// </summary>
	public readonly int PenetrateFactor;

	/// <summary>
	/// 运功增加防御
	/// - 根据丹药增加的命中化解攻防属性，使功法获得增加对应命中化解攻防属性的运功效果 = (丹药品级+2)*3（A类）此列配置值为公式中【*3】的部分
	/// </summary>
	public readonly int PenetrateResistFactor;

	/// <summary>
	/// 运功增加命中
	/// - 根据丹药增加的命中化解攻防属性，使功法获得增加对应命中化解攻防属性的运功效果 = (丹药品级+2)*2（A类）此列配置值为公式中【*2】的部分
	/// </summary>
	public readonly int HitFactor;

	/// <summary>
	/// 运功增加化解
	/// - 根据丹药增加的命中化解攻防属性，使功法获得增加对应命中化解攻防属性的运功效果 = (丹药品级+2)*2（A类）此列配置值为公式中【*2】的部分
	/// </summary>
	public readonly int AvoidFactor;

	/// <summary>
	/// 运功增加次要属性
	/// - 根据丹药增加的属性，使功法获得增加对应属性的运功效果 = 丹药品级+2（A类）此列配置值为公式结果的额外百分比修正，配100时保持原值
	/// </summary>
	public readonly int SubAttributeFactor;

	/// <summary>
	/// 运功增加主要属性
	/// - 增加的量 = 食物恢复的属性/10（向下取整）
	/// </summary>
	public readonly bool AddMainAttribute;

	/// <summary>
	/// 运功增加力道、卸力
	/// - (引子品级+3)*2
	/// </summary>
	public readonly bool AddHitAvoidStrength;

	/// <summary>
	/// 运功增加精妙、拆招
	/// </summary>
	public readonly bool AddHitAvoidTechnique;

	/// <summary>
	/// 运功增加迅疾、闪避
	/// </summary>
	public readonly bool AddHitAvoidSpeed;

	/// <summary>
	/// 运功增加动心、守心
	/// </summary>
	public readonly bool AddHitAvoidMind;

	public readonly bool RelationAddHitMind;

	/// <summary>
	/// 好感增加运功守心
	/// </summary>
	public readonly bool RelationAddAvoidMind;

	/// <summary>
	/// 功法使用需求
	/// - 限定历练类型使用，七档历练级别分别降低功法的使用需求4、5、6、7、8、9、10
	/// </summary>
	public readonly bool ReduceRequirements;

	/// <summary>
	/// 功法威力加值
	/// - 增加的量 = 1 + (造诣 * 好感参数 / 10000)，好感参数可于 GlobalConfig 调整
	/// </summary>
	public readonly bool AddPower;

	/// <summary>
	/// 内外功可调节范围
	/// - 增加功法的内外功可调节范围 = (丹药品级+2)*2（A类）此列配置值为公式中【*3】的部分
	/// </summary>
	public readonly bool InnerRatioChangeRange;

	/// <summary>
	/// 各类功法格数
	/// - 由辅助配置列组合，不可直接配置此列
	/// </summary>
	public readonly sbyte[] SpecificGrids;

	/// <summary>
	/// 增加威力上限栏位类型
	/// - 所有栏位中的功法的威力上限+=引子品级-2，最小为1
	/// </summary>
	public readonly sbyte AddMaxPowerEquipType;

	/// <summary>
	/// 内力总量
	/// - 增加功法能获取的内力总量（如果功法不是内功，则无效），增加的量 = (水果品级+2)*【此列配置值】
	/// </summary>
	public readonly int TotalObtainableNeili;

	/// <summary>
	/// 攻击范围（前）
	/// - 增加的范围值等于引子品级
	/// </summary>
	public readonly bool AttackRangeForward;

	/// <summary>
	/// 攻击范围（后）
	/// </summary>
	public readonly bool AttackRangeBackward;

	/// <summary>
	/// 造成伤害
	/// - 百分比提高，引子品级+3
	/// </summary>
	public readonly bool MakeDamage;

	/// <summary>
	/// 命中系数
	/// - 百分比提高，引子品级+3
	/// </summary>
	public readonly bool AttackSkillHitFactor;

	/// <summary>
	/// 功法含毒
	/// - 根据毒药施加的毒素不同，提高功法造成的对应的中毒量（如果功法本身不含毒，就无效），按百分比提高，提高的百分比 = (丹药品级+2)*2
	/// </summary>
	public readonly bool PoisonFactor;

	/// <summary>
	/// 脚力持续消耗
	/// - 百分比降低，引子品级+3
	/// </summary>
	public readonly bool CostMobilityByFrame;

	/// <summary>
	/// 脚力移动消耗
	/// - 百分比降低，引子品级+3
	/// </summary>
	public readonly bool CostMobilityByMove;

	/// <summary>
	/// 施展消耗脚力
	/// - 百分比降低，【引子品级+3】×【此列配置值】
	/// </summary>
	public readonly int CostMobilityByCastFactor;

	/// <summary>
	/// 命中系数
	/// - 百分比提高，引子品级+3
	/// </summary>
	public readonly bool AgileSkillHitFactor;

	/// <summary>
	/// 反击威力
	/// - 百分比提高，(引子品级+3)*2
	/// </summary>
	public readonly bool FightBackPower;

	/// <summary>
	/// 反震威力
	/// - 百分比提高，(引子品级+3)*2
	/// </summary>
	public readonly bool BouncePower;

	/// <summary>
	/// 防御系数
	/// - 百分比提高，引子品级+3
	/// </summary>
	public readonly bool DefensePenetrateResistFactor;

	/// <summary>
	/// 化解系数
	/// - 百分比提高，引子品级+3
	/// </summary>
	public readonly bool DefenseAvoidFactor;

	public SkillBreakBonusEffectImplementItem(sbyte templateId, sbyte addRequirementType, sbyte reduceCostBreathType, sbyte reduceCostStanceType, sbyte reduceCastFrameType, sbyte addMaxPowerType, bool addInjuryStep, bool addFatalStep, bool addMindStep, int poisonResistFactor, int penetrateFactor, int penetrateResistFactor, int hitFactor, int avoidFactor, int subAttributeFactor, bool addMainAttribute, bool addHitAvoidStrength, bool addHitAvoidTechnique, bool addHitAvoidSpeed, bool addHitAvoidMind, bool relationAddHitMind, bool relationAddAvoidMind, bool reduceRequirements, bool addPower, bool innerRatioChangeRange, sbyte[] specificGrids, sbyte addMaxPowerEquipType, int totalObtainableNeili, bool attackRangeForward, bool attackRangeBackward, bool makeDamage, bool attackSkillHitFactor, bool poisonFactor, bool costMobilityByFrame, bool costMobilityByMove, int costMobilityByCastFactor, bool agileSkillHitFactor, bool fightBackPower, bool bouncePower, bool defensePenetrateResistFactor, bool defenseAvoidFactor)
	{
		TemplateId = templateId;
		AddRequirementType = addRequirementType;
		ReduceCostBreathType = reduceCostBreathType;
		ReduceCostStanceType = reduceCostStanceType;
		ReduceCastFrameType = reduceCastFrameType;
		AddMaxPowerType = addMaxPowerType;
		AddInjuryStep = addInjuryStep;
		AddFatalStep = addFatalStep;
		AddMindStep = addMindStep;
		PoisonResistFactor = poisonResistFactor;
		PenetrateFactor = penetrateFactor;
		PenetrateResistFactor = penetrateResistFactor;
		HitFactor = hitFactor;
		AvoidFactor = avoidFactor;
		SubAttributeFactor = subAttributeFactor;
		AddMainAttribute = addMainAttribute;
		AddHitAvoidStrength = addHitAvoidStrength;
		AddHitAvoidTechnique = addHitAvoidTechnique;
		AddHitAvoidSpeed = addHitAvoidSpeed;
		AddHitAvoidMind = addHitAvoidMind;
		RelationAddHitMind = relationAddHitMind;
		RelationAddAvoidMind = relationAddAvoidMind;
		ReduceRequirements = reduceRequirements;
		AddPower = addPower;
		InnerRatioChangeRange = innerRatioChangeRange;
		SpecificGrids = specificGrids;
		AddMaxPowerEquipType = addMaxPowerEquipType;
		TotalObtainableNeili = totalObtainableNeili;
		AttackRangeForward = attackRangeForward;
		AttackRangeBackward = attackRangeBackward;
		MakeDamage = makeDamage;
		AttackSkillHitFactor = attackSkillHitFactor;
		PoisonFactor = poisonFactor;
		CostMobilityByFrame = costMobilityByFrame;
		CostMobilityByMove = costMobilityByMove;
		CostMobilityByCastFactor = costMobilityByCastFactor;
		AgileSkillHitFactor = agileSkillHitFactor;
		FightBackPower = fightBackPower;
		BouncePower = bouncePower;
		DefensePenetrateResistFactor = defensePenetrateResistFactor;
		DefenseAvoidFactor = defenseAvoidFactor;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SkillBreakBonusEffectImplementItem()
	{
		TemplateId = 0;
		AddRequirementType = 0;
		ReduceCostBreathType = 0;
		ReduceCostStanceType = 0;
		ReduceCastFrameType = 0;
		AddMaxPowerType = 0;
		AddInjuryStep = false;
		AddFatalStep = false;
		AddMindStep = false;
		PoisonResistFactor = 0;
		PenetrateFactor = 0;
		PenetrateResistFactor = 0;
		HitFactor = 0;
		AvoidFactor = 0;
		SubAttributeFactor = 0;
		AddMainAttribute = false;
		AddHitAvoidStrength = false;
		AddHitAvoidTechnique = false;
		AddHitAvoidSpeed = false;
		AddHitAvoidMind = false;
		RelationAddHitMind = false;
		RelationAddAvoidMind = false;
		ReduceRequirements = false;
		AddPower = false;
		InnerRatioChangeRange = false;
		SpecificGrids = new sbyte[4];
		AddMaxPowerEquipType = -1;
		TotalObtainableNeili = 0;
		AttackRangeForward = false;
		AttackRangeBackward = false;
		MakeDamage = false;
		AttackSkillHitFactor = false;
		PoisonFactor = false;
		CostMobilityByFrame = false;
		CostMobilityByMove = false;
		CostMobilityByCastFactor = 0;
		AgileSkillHitFactor = false;
		FightBackPower = false;
		BouncePower = false;
		DefensePenetrateResistFactor = false;
		DefenseAvoidFactor = false;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public SkillBreakBonusEffectImplementItem(sbyte templateId, SkillBreakBonusEffectImplementItem other)
	{
		TemplateId = templateId;
		AddRequirementType = other.AddRequirementType;
		ReduceCostBreathType = other.ReduceCostBreathType;
		ReduceCostStanceType = other.ReduceCostStanceType;
		ReduceCastFrameType = other.ReduceCastFrameType;
		AddMaxPowerType = other.AddMaxPowerType;
		AddInjuryStep = other.AddInjuryStep;
		AddFatalStep = other.AddFatalStep;
		AddMindStep = other.AddMindStep;
		PoisonResistFactor = other.PoisonResistFactor;
		PenetrateFactor = other.PenetrateFactor;
		PenetrateResistFactor = other.PenetrateResistFactor;
		HitFactor = other.HitFactor;
		AvoidFactor = other.AvoidFactor;
		SubAttributeFactor = other.SubAttributeFactor;
		AddMainAttribute = other.AddMainAttribute;
		AddHitAvoidStrength = other.AddHitAvoidStrength;
		AddHitAvoidTechnique = other.AddHitAvoidTechnique;
		AddHitAvoidSpeed = other.AddHitAvoidSpeed;
		AddHitAvoidMind = other.AddHitAvoidMind;
		RelationAddHitMind = other.RelationAddHitMind;
		RelationAddAvoidMind = other.RelationAddAvoidMind;
		ReduceRequirements = other.ReduceRequirements;
		AddPower = other.AddPower;
		InnerRatioChangeRange = other.InnerRatioChangeRange;
		SpecificGrids = other.SpecificGrids;
		AddMaxPowerEquipType = other.AddMaxPowerEquipType;
		TotalObtainableNeili = other.TotalObtainableNeili;
		AttackRangeForward = other.AttackRangeForward;
		AttackRangeBackward = other.AttackRangeBackward;
		MakeDamage = other.MakeDamage;
		AttackSkillHitFactor = other.AttackSkillHitFactor;
		PoisonFactor = other.PoisonFactor;
		CostMobilityByFrame = other.CostMobilityByFrame;
		CostMobilityByMove = other.CostMobilityByMove;
		CostMobilityByCastFactor = other.CostMobilityByCastFactor;
		AgileSkillHitFactor = other.AgileSkillHitFactor;
		FightBackPower = other.FightBackPower;
		BouncePower = other.BouncePower;
		DefensePenetrateResistFactor = other.DefensePenetrateResistFactor;
		DefenseAvoidFactor = other.DefenseAvoidFactor;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SkillBreakBonusEffectImplementItem Duplicate(int templateId)
	{
		return new SkillBreakBonusEffectImplementItem((sbyte)templateId, this);
	}
}
