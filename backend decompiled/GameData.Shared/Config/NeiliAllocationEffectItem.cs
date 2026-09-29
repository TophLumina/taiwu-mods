using System;
using Config.Common;
using GameData.Domains.Character;

namespace Config;

[Serializable]
public class NeiliAllocationEffectItem : ConfigItem<NeiliAllocationEffectItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly HitOrAvoidShorts HitValues;

	public readonly HitOrAvoidShorts AvoidValues;

	public readonly OuterAndInnerShorts Penetrations;

	public readonly OuterAndInnerShorts PenetrationResists;

	public readonly OuterAndInnerShorts RecoveryOfStanceAndBreath;

	public readonly sbyte MoveSpeed;

	public readonly sbyte RecoveryOfFlaw;

	public readonly sbyte CastSpeed;

	public readonly sbyte RecoveryOfBlockedAcupoint;

	public readonly sbyte WeaponSwitchSpeed;

	public readonly sbyte AttackSpeed;

	public readonly sbyte InnerRatio;

	public readonly sbyte RecoveryOfQiDisorder;

	public readonly PoisonShorts PoisonResists;

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

	public override NeiliAllocationEffectItem Duplicate(int templateId)
	{
		return new NeiliAllocationEffectItem((sbyte)templateId, this);
	}
}
