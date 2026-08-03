using System;
using Config.Common;
using GameData.Domains.Character;

namespace Config;

[Serializable]
public class SkillBreakPageEffectImplementItem : ConfigItem<SkillBreakPageEffectImplementItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 增加威力
	/// </summary>
	public readonly int AddPower;

	/// <summary>
	/// 增加威力上限
	/// </summary>
	public readonly int AddMaxPower;

	/// <summary>
	/// 增加发挥需求
	/// </summary>
	public readonly int AddRequirement;

	/// <summary>
	/// 提气恢复
	/// - 次要属性相关，使用 +(所占栏位*本列配置值) 计算运功效果值
	/// </summary>
	public readonly short RecoveryOfBreath;

	/// <summary>
	/// 架势恢复
	/// </summary>
	public readonly short RecoveryOfStance;

	/// <summary>
	/// 引气冲关
	/// </summary>
	public readonly short RecoveryOfAcupoint;

	/// <summary>
	/// 步伐稳健
	/// </summary>
	public readonly short RecoveryOfFlaw;

	/// <summary>
	/// 调息吐纳
	/// </summary>
	public readonly short RecoveryOfQiDisorder;

	/// <summary>
	/// 武具运用
	/// </summary>
	public readonly short SwitchSpeed;

	/// <summary>
	/// 内功发挥
	/// </summary>
	public readonly short InnerRatio;

	/// <summary>
	/// 移动速度
	/// </summary>
	public readonly short MoveSpeed;

	/// <summary>
	/// 攻击速度
	/// </summary>
	public readonly short AttackSpeed;

	/// <summary>
	/// 施展速度
	/// </summary>
	public readonly short CastSpeed;

	/// <summary>
	/// 命中
	/// </summary>
	public readonly HitOrAvoidShorts HitValues;

	/// <summary>
	/// 攻击
	/// </summary>
	public readonly OuterAndInnerShorts Penetrations;

	/// <summary>
	/// 化解
	/// </summary>
	public readonly HitOrAvoidShorts AvoidValues;

	/// <summary>
	/// 防御
	/// </summary>
	public readonly OuterAndInnerShorts PenetrationResists;

	/// <summary>
	/// 气势消耗
	/// - 主动功法字段
	/// </summary>
	public readonly int CostBreathAndStance;

	/// <summary>
	/// 施展时间
	/// </summary>
	public readonly int CastFrame;

	/// <summary>
	/// 攻击范围（前）
	/// - 摧破专用字段
	/// </summary>
	public readonly int AttackRangeForward;

	/// <summary>
	/// 攻击范围（后）
	/// </summary>
	public readonly int AttackRangeBackward;

	/// <summary>
	/// 造成伤害
	/// </summary>
	public readonly int MakeDamage;

	/// <summary>
	/// 命中系数
	/// </summary>
	public readonly int HitFactor;

	/// <summary>
	/// 脚力持续消耗
	/// - 轻灵专用字段
	/// </summary>
	public readonly int CostMobilityByFrame;

	/// <summary>
	/// 脚力移动消耗
	/// </summary>
	public readonly int CostMobilityByMove;

	/// <summary>
	/// 无重创时所受直伤
	/// - 护体专用字段
	/// </summary>
	public readonly int AcceptDirectDamageNoFatal;

	/// <summary>
	/// 有重创时所受直伤
	/// </summary>
	public readonly int AcceptDirectDamageOnFatal;

	/// <summary>
	/// 破绽消失速率
	/// </summary>
	public readonly int FlawRecoverSpeed;

	/// <summary>
	/// 封穴消失速率
	/// </summary>
	public readonly int AcupointRecoverSpeed;

	/// <summary>
	/// 封禁概率
	/// - 奇窍专用字段
	/// </summary>
	public readonly int SilenceRate;

	/// <summary>
	/// 封禁时间
	/// </summary>
	public readonly int SilenceFrame;

	/// <summary>
	/// 特殊效果文本
	/// - 效果存在对应不到Character和CombatProperty的时，可配置这一列，如果有多个，与列的顺序相同。目前有AcceptDirectDamageNoFatal,AcceptDirectDamageOnFatal
	/// </summary>
	public readonly string[] EffectDesc;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="addPower">增加威力</param>
	/// <param name="addMaxPower">增加威力上限</param>
	/// <param name="addRequirement">增加发挥需求</param>
	/// <param name="recoveryOfBreath">提气恢复 - 次要属性相关，使用 +(所占栏位*本列配置值) 计算运功效果值</param>
	/// <param name="recoveryOfStance">架势恢复</param>
	/// <param name="recoveryOfAcupoint">引气冲关</param>
	/// <param name="recoveryOfFlaw">步伐稳健</param>
	/// <param name="recoveryOfQiDisorder">调息吐纳</param>
	/// <param name="switchSpeed">武具运用</param>
	/// <param name="innerRatio">内功发挥</param>
	/// <param name="moveSpeed">移动速度</param>
	/// <param name="attackSpeed">攻击速度</param>
	/// <param name="castSpeed">施展速度</param>
	/// <param name="hitValues">命中</param>
	/// <param name="penetrations">攻击</param>
	/// <param name="avoidValues">化解</param>
	/// <param name="penetrationResists">防御</param>
	/// <param name="costBreathAndStance">气势消耗 - 主动功法字段</param>
	/// <param name="castFrame">施展时间</param>
	/// <param name="attackRangeForward">攻击范围（前） - 摧破专用字段</param>
	/// <param name="attackRangeBackward">攻击范围（后）</param>
	/// <param name="makeDamage">造成伤害</param>
	/// <param name="hitFactor">命中系数</param>
	/// <param name="costMobilityByFrame">脚力持续消耗 - 轻灵专用字段</param>
	/// <param name="costMobilityByMove">脚力移动消耗</param>
	/// <param name="acceptDirectDamageNoFatal">无重创时所受直伤 - 护体专用字段</param>
	/// <param name="acceptDirectDamageOnFatal">有重创时所受直伤</param>
	/// <param name="flawRecoverSpeed">破绽消失速率</param>
	/// <param name="acupointRecoverSpeed">封穴消失速率</param>
	/// <param name="silenceRate">封禁概率 - 奇窍专用字段</param>
	/// <param name="silenceFrame">封禁时间</param>
	/// <param name="effectDesc">特殊效果文本 - 效果存在对应不到Character和CombatProperty的时，可配置这一列，如果有多个，与列的顺序相同。目前有AcceptDirectDamageNoFatal,AcceptDirectDamageOnFatal</param>
	public SkillBreakPageEffectImplementItem(sbyte templateId, int addPower, int addMaxPower, int addRequirement, short recoveryOfBreath, short recoveryOfStance, short recoveryOfAcupoint, short recoveryOfFlaw, short recoveryOfQiDisorder, short switchSpeed, short innerRatio, short moveSpeed, short attackSpeed, short castSpeed, HitOrAvoidShorts hitValues, OuterAndInnerShorts penetrations, HitOrAvoidShorts avoidValues, OuterAndInnerShorts penetrationResists, int costBreathAndStance, int castFrame, int attackRangeForward, int attackRangeBackward, int makeDamage, int hitFactor, int costMobilityByFrame, int costMobilityByMove, int acceptDirectDamageNoFatal, int acceptDirectDamageOnFatal, int flawRecoverSpeed, int acupointRecoverSpeed, int silenceRate, int silenceFrame, string[] effectDesc)
	{
		TemplateId = templateId;
		AddPower = addPower;
		AddMaxPower = addMaxPower;
		AddRequirement = addRequirement;
		RecoveryOfBreath = recoveryOfBreath;
		RecoveryOfStance = recoveryOfStance;
		RecoveryOfAcupoint = recoveryOfAcupoint;
		RecoveryOfFlaw = recoveryOfFlaw;
		RecoveryOfQiDisorder = recoveryOfQiDisorder;
		SwitchSpeed = switchSpeed;
		InnerRatio = innerRatio;
		MoveSpeed = moveSpeed;
		AttackSpeed = attackSpeed;
		CastSpeed = castSpeed;
		HitValues = hitValues;
		Penetrations = penetrations;
		AvoidValues = avoidValues;
		PenetrationResists = penetrationResists;
		CostBreathAndStance = costBreathAndStance;
		CastFrame = castFrame;
		AttackRangeForward = attackRangeForward;
		AttackRangeBackward = attackRangeBackward;
		MakeDamage = makeDamage;
		HitFactor = hitFactor;
		CostMobilityByFrame = costMobilityByFrame;
		CostMobilityByMove = costMobilityByMove;
		AcceptDirectDamageNoFatal = acceptDirectDamageNoFatal;
		AcceptDirectDamageOnFatal = acceptDirectDamageOnFatal;
		FlawRecoverSpeed = flawRecoverSpeed;
		AcupointRecoverSpeed = acupointRecoverSpeed;
		SilenceRate = silenceRate;
		SilenceFrame = silenceFrame;
		EffectDesc = effectDesc;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SkillBreakPageEffectImplementItem()
	{
		TemplateId = 0;
		AddPower = 0;
		AddMaxPower = 0;
		AddRequirement = 0;
		RecoveryOfBreath = 0;
		RecoveryOfStance = 0;
		RecoveryOfAcupoint = 0;
		RecoveryOfFlaw = 0;
		RecoveryOfQiDisorder = 0;
		SwitchSpeed = 0;
		InnerRatio = 0;
		MoveSpeed = 0;
		AttackSpeed = 0;
		CastSpeed = 0;
		HitValues = new HitOrAvoidShorts(default(short), default(short), default(short), default(short));
		Penetrations = new OuterAndInnerShorts(0, 0);
		AvoidValues = new HitOrAvoidShorts(default(short), default(short), default(short), default(short));
		PenetrationResists = new OuterAndInnerShorts(0, 0);
		CostBreathAndStance = 0;
		CastFrame = 0;
		AttackRangeForward = 0;
		AttackRangeBackward = 0;
		MakeDamage = 0;
		HitFactor = 0;
		CostMobilityByFrame = 0;
		CostMobilityByMove = 0;
		AcceptDirectDamageNoFatal = 0;
		AcceptDirectDamageOnFatal = 0;
		FlawRecoverSpeed = 0;
		AcupointRecoverSpeed = 0;
		SilenceRate = 0;
		SilenceFrame = 0;
		EffectDesc = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public SkillBreakPageEffectImplementItem(sbyte templateId, SkillBreakPageEffectImplementItem other)
	{
		TemplateId = templateId;
		AddPower = other.AddPower;
		AddMaxPower = other.AddMaxPower;
		AddRequirement = other.AddRequirement;
		RecoveryOfBreath = other.RecoveryOfBreath;
		RecoveryOfStance = other.RecoveryOfStance;
		RecoveryOfAcupoint = other.RecoveryOfAcupoint;
		RecoveryOfFlaw = other.RecoveryOfFlaw;
		RecoveryOfQiDisorder = other.RecoveryOfQiDisorder;
		SwitchSpeed = other.SwitchSpeed;
		InnerRatio = other.InnerRatio;
		MoveSpeed = other.MoveSpeed;
		AttackSpeed = other.AttackSpeed;
		CastSpeed = other.CastSpeed;
		HitValues = other.HitValues;
		Penetrations = other.Penetrations;
		AvoidValues = other.AvoidValues;
		PenetrationResists = other.PenetrationResists;
		CostBreathAndStance = other.CostBreathAndStance;
		CastFrame = other.CastFrame;
		AttackRangeForward = other.AttackRangeForward;
		AttackRangeBackward = other.AttackRangeBackward;
		MakeDamage = other.MakeDamage;
		HitFactor = other.HitFactor;
		CostMobilityByFrame = other.CostMobilityByFrame;
		CostMobilityByMove = other.CostMobilityByMove;
		AcceptDirectDamageNoFatal = other.AcceptDirectDamageNoFatal;
		AcceptDirectDamageOnFatal = other.AcceptDirectDamageOnFatal;
		FlawRecoverSpeed = other.FlawRecoverSpeed;
		AcupointRecoverSpeed = other.AcupointRecoverSpeed;
		SilenceRate = other.SilenceRate;
		SilenceFrame = other.SilenceFrame;
		EffectDesc = other.EffectDesc;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SkillBreakPageEffectImplementItem Duplicate(int templateId)
	{
		return new SkillBreakPageEffectImplementItem((sbyte)templateId, this);
	}
}
