using System;
using Config.Common;
using GameData.Domains.Character;

namespace Config;

[Serializable]
public class SkillBreakPageEffectImplementItem : ConfigItem<SkillBreakPageEffectImplementItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly int AddPower;

	public readonly int AddMaxPower;

	public readonly int AddRequirement;

	public readonly short RecoveryOfBreath;

	public readonly short RecoveryOfStance;

	public readonly short RecoveryOfAcupoint;

	public readonly short RecoveryOfFlaw;

	public readonly short RecoveryOfQiDisorder;

	public readonly short SwitchSpeed;

	public readonly short InnerRatio;

	public readonly short MoveSpeed;

	public readonly short AttackSpeed;

	public readonly short CastSpeed;

	public readonly HitOrAvoidShorts HitValues;

	public readonly OuterAndInnerShorts Penetrations;

	public readonly HitOrAvoidShorts AvoidValues;

	public readonly OuterAndInnerShorts PenetrationResists;

	public readonly int CostBreathAndStance;

	public readonly int CastFrame;

	public readonly int AttackRangeForward;

	public readonly int AttackRangeBackward;

	public readonly int MakeDamage;

	public readonly int HitFactor;

	public readonly int CostMobilityByFrame;

	public readonly int CostMobilityByMove;

	public readonly int AcceptDirectDamageNoFatal;

	public readonly int AcceptDirectDamageOnFatal;

	public readonly int FlawRecoverSpeed;

	public readonly int AcupointRecoverSpeed;

	public readonly int SilenceRate;

	public readonly int SilenceFrame;

	public readonly string[] EffectDesc;

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

	public override SkillBreakPageEffectImplementItem Duplicate(int templateId)
	{
		return new SkillBreakPageEffectImplementItem((sbyte)templateId, this);
	}
}
