using System;
using Config.Common;
using GameData.Domains.Character;

namespace Config;

[Serializable]
public class NeiliAllocationEffectItem : ConfigItem<NeiliAllocationEffectItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 命中
	/// - 此字段自动生成, 实际配置字段为从 "力道" 到 "动心" 的 4 个字段.
	/// </summary>
	public readonly HitOrAvoidShorts HitValues;

	/// <summary>
	/// 化解
	/// - 此字段自动生成, 实际配置字段为从 "卸力" 到 "守心" 的 4 个字段.
	/// </summary>
	public readonly HitOrAvoidShorts AvoidValues;

	/// <summary>
	/// 攻击
	/// - 此字段自动生成, 实际配置字段为从 "破体" 到 "破气" 的 2 个字段.
	/// </summary>
	public readonly OuterAndInnerShorts Penetrations;

	/// <summary>
	/// 防御
	/// - 此字段自动生成, 实际配置字段为从 "御体" 到 "御气" 的 2 个字段.
	/// </summary>
	public readonly OuterAndInnerShorts PenetrationResists;

	/// <summary>
	/// 架势提气恢复
	/// - 此字段自动生成, 实际配置字段为 "架势" 和 "提气" 字段.
	/// </summary>
	public readonly OuterAndInnerShorts RecoveryOfStanceAndBreath;

	/// <summary>
	/// 移动速度
	/// - 每分配几点真气就增加一次此属性. 为 0 表示永远不增加此属性.
	/// </summary>
	public readonly sbyte MoveSpeed;

	/// <summary>
	/// 步伐稳健
	/// - 每分配几点真气就增加一次此属性. 为 0 表示永远不增加此属性.
	/// </summary>
	public readonly sbyte RecoveryOfFlaw;

	/// <summary>
	/// 施展速度
	/// - 每分配几点真气就增加一次此属性. 为 0 表示永远不增加此属性.
	/// </summary>
	public readonly sbyte CastSpeed;

	/// <summary>
	/// 引气冲关
	/// - 每分配几点真气就增加一次此属性. 为 0 表示永远不增加此属性.
	/// </summary>
	public readonly sbyte RecoveryOfBlockedAcupoint;

	/// <summary>
	/// 武具发挥
	/// - 每分配几点真气就增加一次此属性. 为 0 表示永远不增加此属性.
	/// </summary>
	public readonly sbyte WeaponSwitchSpeed;

	/// <summary>
	/// 攻击速度
	/// - 每分配几点真气就增加一次此属性. 为 0 表示永远不增加此属性.
	/// </summary>
	public readonly sbyte AttackSpeed;

	/// <summary>
	/// 内功发挥
	/// - 每分配几点真气就增加一次此属性. 为 0 表示永远不增加此属性.
	/// </summary>
	public readonly sbyte InnerRatio;

	/// <summary>
	/// 调息吐纳
	/// - 每分配几点真气就增加一次此属性. 为 0 表示永远不增加此属性.
	/// </summary>
	public readonly sbyte RecoveryOfQiDisorder;

	/// <summary>
	/// 毒素抵抗
	/// - 此字段自动生成, 实际配置字段为从 "烈" 到 "幻" 的 6 个字段.
	/// </summary>
	public readonly PoisonShorts PoisonResists;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="hitValues">命中 - 此字段自动生成, 实际配置字段为从 "力道" 到 "动心" 的 4 个字段.</param>
	/// <param name="avoidValues">化解 - 此字段自动生成, 实际配置字段为从 "卸力" 到 "守心" 的 4 个字段.</param>
	/// <param name="penetrations">攻击 - 此字段自动生成, 实际配置字段为从 "破体" 到 "破气" 的 2 个字段.</param>
	/// <param name="penetrationResists">防御 - 此字段自动生成, 实际配置字段为从 "御体" 到 "御气" 的 2 个字段.</param>
	/// <param name="recoveryOfStanceAndBreath">架势提气恢复 - 此字段自动生成, 实际配置字段为 "架势" 和 "提气" 字段.</param>
	/// <param name="moveSpeed">移动速度 - 每分配几点真气就增加一次此属性. 为 0 表示永远不增加此属性.</param>
	/// <param name="recoveryOfFlaw">步伐稳健 - 每分配几点真气就增加一次此属性. 为 0 表示永远不增加此属性.</param>
	/// <param name="castSpeed">施展速度 - 每分配几点真气就增加一次此属性. 为 0 表示永远不增加此属性.</param>
	/// <param name="recoveryOfBlockedAcupoint">引气冲关 - 每分配几点真气就增加一次此属性. 为 0 表示永远不增加此属性.</param>
	/// <param name="weaponSwitchSpeed">武具发挥 - 每分配几点真气就增加一次此属性. 为 0 表示永远不增加此属性.</param>
	/// <param name="attackSpeed">攻击速度 - 每分配几点真气就增加一次此属性. 为 0 表示永远不增加此属性.</param>
	/// <param name="innerRatio">内功发挥 - 每分配几点真气就增加一次此属性. 为 0 表示永远不增加此属性.</param>
	/// <param name="recoveryOfQiDisorder">调息吐纳 - 每分配几点真气就增加一次此属性. 为 0 表示永远不增加此属性.</param>
	/// <param name="poisonResists">毒素抵抗 - 此字段自动生成, 实际配置字段为从 "烈" 到 "幻" 的 6 个字段.</param>
	public NeiliAllocationEffectItem(sbyte templateId, HitOrAvoidShorts hitValues, HitOrAvoidShorts avoidValues, OuterAndInnerShorts penetrations, OuterAndInnerShorts penetrationResists, OuterAndInnerShorts recoveryOfStanceAndBreath, sbyte moveSpeed, sbyte recoveryOfFlaw, sbyte castSpeed, sbyte recoveryOfBlockedAcupoint, sbyte weaponSwitchSpeed, sbyte attackSpeed, sbyte innerRatio, sbyte recoveryOfQiDisorder, PoisonShorts poisonResists)
	{
		TemplateId = templateId;
		HitValues = hitValues;
		AvoidValues = avoidValues;
		Penetrations = penetrations;
		PenetrationResists = penetrationResists;
		RecoveryOfStanceAndBreath = recoveryOfStanceAndBreath;
		MoveSpeed = moveSpeed;
		RecoveryOfFlaw = recoveryOfFlaw;
		CastSpeed = castSpeed;
		RecoveryOfBlockedAcupoint = recoveryOfBlockedAcupoint;
		WeaponSwitchSpeed = weaponSwitchSpeed;
		AttackSpeed = attackSpeed;
		InnerRatio = innerRatio;
		RecoveryOfQiDisorder = recoveryOfQiDisorder;
		PoisonResists = poisonResists;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public NeiliAllocationEffectItem()
	{
		TemplateId = 0;
		HitValues = new HitOrAvoidShorts(default(short), default(short), default(short), default(short));
		AvoidValues = new HitOrAvoidShorts(default(short), default(short), default(short), default(short));
		Penetrations = new OuterAndInnerShorts(0, 0);
		PenetrationResists = new OuterAndInnerShorts(0, 0);
		RecoveryOfStanceAndBreath = new OuterAndInnerShorts(0, 0);
		MoveSpeed = 0;
		RecoveryOfFlaw = 0;
		CastSpeed = 0;
		RecoveryOfBlockedAcupoint = 0;
		WeaponSwitchSpeed = 0;
		AttackSpeed = 0;
		InnerRatio = 0;
		RecoveryOfQiDisorder = 0;
		PoisonResists = new PoisonShorts(default(int), default(int), default(int), default(int), default(int), default(int));
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public NeiliAllocationEffectItem(sbyte templateId, NeiliAllocationEffectItem other)
	{
		TemplateId = templateId;
		HitValues = other.HitValues;
		AvoidValues = other.AvoidValues;
		Penetrations = other.Penetrations;
		PenetrationResists = other.PenetrationResists;
		RecoveryOfStanceAndBreath = other.RecoveryOfStanceAndBreath;
		MoveSpeed = other.MoveSpeed;
		RecoveryOfFlaw = other.RecoveryOfFlaw;
		CastSpeed = other.CastSpeed;
		RecoveryOfBlockedAcupoint = other.RecoveryOfBlockedAcupoint;
		WeaponSwitchSpeed = other.WeaponSwitchSpeed;
		AttackSpeed = other.AttackSpeed;
		InnerRatio = other.InnerRatio;
		RecoveryOfQiDisorder = other.RecoveryOfQiDisorder;
		PoisonResists = other.PoisonResists;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override NeiliAllocationEffectItem Duplicate(int templateId)
	{
		return new NeiliAllocationEffectItem((sbyte)templateId, this);
	}
}
