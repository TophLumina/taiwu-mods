using System;
using Config.Common;
using GameData.Domains.Character;

namespace Config;

[Serializable]
public class CombatDifficultyItem : ConfigItem<CombatDifficultyItem, byte>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly byte TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 命中
	/// </summary>
	public readonly short HitValues;

	/// <summary>
	/// 攻击
	/// </summary>
	public readonly short Penetrations;

	/// <summary>
	/// 化解
	/// </summary>
	public readonly short AvoidValues;

	/// <summary>
	/// 防御
	/// </summary>
	public readonly short PenetrationResists;

	/// <summary>
	/// 架势提气恢复
	/// - 此字段自动生成, 实际配置字段为 "架势" 和 "提气" 字段.
	/// </summary>
	public readonly OuterAndInnerShorts RecoveryOfStanceAndBreath;

	/// <summary>
	/// 移动速度
	/// </summary>
	public readonly short MoveSpeed;

	/// <summary>
	/// 步伐稳健
	/// </summary>
	public readonly short RecoveryOfFlaw;

	/// <summary>
	/// 施展速度
	/// </summary>
	public readonly short CastSpeed;

	/// <summary>
	/// 引气冲关
	/// </summary>
	public readonly short RecoveryOfBlockedAcupoint;

	/// <summary>
	/// 兵器切换
	/// </summary>
	public readonly short WeaponSwitchSpeed;

	/// <summary>
	/// 攻击速度
	/// </summary>
	public readonly short AttackSpeed;

	/// <summary>
	/// 内功发挥
	/// </summary>
	public readonly short InnerRatio;

	/// <summary>
	/// 调息吐纳
	/// </summary>
	public readonly short RecoveryOfQiDisorder;

	/// <summary>
	/// 额外功法栏位
	/// - 对 Character 和 OrganizationMember 表中的配置的影响
	/// </summary>
	public readonly short ExtraCombatSkillGrids;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">名称</param>
	/// <param name="hitValues">命中</param>
	/// <param name="penetrations">攻击</param>
	/// <param name="avoidValues">化解</param>
	/// <param name="penetrationResists">防御</param>
	/// <param name="recoveryOfStanceAndBreath">架势提气恢复 - 此字段自动生成, 实际配置字段为 "架势" 和 "提气" 字段.</param>
	/// <param name="moveSpeed">移动速度</param>
	/// <param name="recoveryOfFlaw">步伐稳健</param>
	/// <param name="castSpeed">施展速度</param>
	/// <param name="recoveryOfBlockedAcupoint">引气冲关</param>
	/// <param name="weaponSwitchSpeed">兵器切换</param>
	/// <param name="attackSpeed">攻击速度</param>
	/// <param name="innerRatio">内功发挥</param>
	/// <param name="recoveryOfQiDisorder">调息吐纳</param>
	/// <param name="extraCombatSkillGrids">额外功法栏位 - 对 Character 和 OrganizationMember 表中的配置的影响</param>
	public CombatDifficultyItem(byte templateId, string name, short hitValues, short penetrations, short avoidValues, short penetrationResists, OuterAndInnerShorts recoveryOfStanceAndBreath, short moveSpeed, short recoveryOfFlaw, short castSpeed, short recoveryOfBlockedAcupoint, short weaponSwitchSpeed, short attackSpeed, short innerRatio, short recoveryOfQiDisorder, short extraCombatSkillGrids)
	{
		TemplateId = templateId;
		Name = name;
		HitValues = hitValues;
		Penetrations = penetrations;
		AvoidValues = avoidValues;
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
		ExtraCombatSkillGrids = extraCombatSkillGrids;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public CombatDifficultyItem()
	{
		TemplateId = 0;
		Name = null;
		HitValues = 0;
		Penetrations = 0;
		AvoidValues = 0;
		PenetrationResists = 0;
		RecoveryOfStanceAndBreath = default(OuterAndInnerShorts);
		MoveSpeed = 0;
		RecoveryOfFlaw = 0;
		CastSpeed = 0;
		RecoveryOfBlockedAcupoint = 0;
		WeaponSwitchSpeed = 0;
		AttackSpeed = 0;
		InnerRatio = 0;
		RecoveryOfQiDisorder = 0;
		ExtraCombatSkillGrids = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public CombatDifficultyItem(byte templateId, CombatDifficultyItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		HitValues = other.HitValues;
		Penetrations = other.Penetrations;
		AvoidValues = other.AvoidValues;
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
		ExtraCombatSkillGrids = other.ExtraCombatSkillGrids;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override CombatDifficultyItem Duplicate(int templateId)
	{
		return new CombatDifficultyItem((byte)templateId, this);
	}
}
