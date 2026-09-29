using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Domains.Character;

namespace Config;

[Serializable]
public class NeiliTypeItem : ConfigItem<NeiliTypeItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly byte FiveElements;

	public readonly sbyte[] IdeaAllocationProportion;

	public readonly sbyte[] MaxPowerChange;

	public readonly sbyte[] RequirementChange;

	public readonly sbyte InjuryOnUseType;

	public readonly bool ShowConflictingWorldState;

	public readonly HitOrAvoidShorts HitValues;

	public readonly OuterAndInnerShorts Penetrations;

	public readonly HitOrAvoidShorts AvoidValues;

	public readonly OuterAndInnerShorts PenetrationResists;

	public readonly OuterAndInnerShorts RecoveryOfStanceAndBreath;

	public readonly short MoveSpeed;

	public readonly short RecoveryOfFlaw;

	public readonly short CastSpeed;

	public readonly short RecoveryOfBlockedAcupoint;

	public readonly short WeaponSwitchSpeed;

	public readonly short AttackSpeed;

	public readonly short InnerRatio;

	public readonly short RecoveryOfQiDisorder;

	public readonly PoisonShorts PoisonResists;

	public readonly sbyte ColorType;

	public readonly short[] LinePos;

	public readonly short LineAngle;

	public readonly short[] TypeIconPos;

	public readonly List<string> NeiliTypeConditionText;

	public readonly string SimpleDesc;

	public readonly string EffectDesc;

	public readonly short[] LifeGateFeatures;

	public readonly short[] DeathGateFeatures;

	public readonly sbyte[] NeiliProportionOfFiveElements;

	public NeiliTypeItem(sbyte templateId, string name, string desc, byte fiveElements, sbyte[] ideaAllocationProportion, sbyte[] maxPowerChange, sbyte[] requirementChange, sbyte injuryOnUseType, bool showConflictingWorldState, HitOrAvoidShorts hitValues, OuterAndInnerShorts penetrations, HitOrAvoidShorts avoidValues, OuterAndInnerShorts penetrationResists, OuterAndInnerShorts recoveryOfStanceAndBreath, short moveSpeed, short recoveryOfFlaw, short castSpeed, short recoveryOfBlockedAcupoint, short weaponSwitchSpeed, short attackSpeed, short innerRatio, short recoveryOfQiDisorder, PoisonShorts poisonResists, sbyte colorType, short[] linePos, short lineAngle, short[] typeIconPos, List<string> neiliTypeConditionText, string simpleDesc, string effectDesc, short[] lifeGateFeatures, short[] deathGateFeatures, sbyte[] neiliProportionOfFiveElements)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		FiveElements = fiveElements;
		IdeaAllocationProportion = ideaAllocationProportion;
		MaxPowerChange = maxPowerChange;
		RequirementChange = requirementChange;
		InjuryOnUseType = injuryOnUseType;
		ShowConflictingWorldState = showConflictingWorldState;
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
		PoisonResists = poisonResists;
		ColorType = colorType;
		LinePos = linePos;
		LineAngle = lineAngle;
		TypeIconPos = typeIconPos;
		NeiliTypeConditionText = neiliTypeConditionText;
		SimpleDesc = simpleDesc;
		EffectDesc = effectDesc;
		LifeGateFeatures = lifeGateFeatures;
		DeathGateFeatures = deathGateFeatures;
		NeiliProportionOfFiveElements = neiliProportionOfFiveElements;
	}

	public NeiliTypeItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		FiveElements = 0;
		IdeaAllocationProportion = new sbyte[4] { 25, 25, 25, 25 };
		MaxPowerChange = new sbyte[6];
		RequirementChange = new sbyte[6];
		InjuryOnUseType = -1;
		ShowConflictingWorldState = false;
		HitValues = new HitOrAvoidShorts(default(short), default(short), default(short), default(short));
		Penetrations = new OuterAndInnerShorts(0, 0);
		AvoidValues = new HitOrAvoidShorts(default(short), default(short), default(short), default(short));
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
		ColorType = 0;
		LinePos = null;
		LineAngle = 0;
		TypeIconPos = new short[2] { -1, -1 };
		NeiliTypeConditionText = new List<string> { string.Empty };
		SimpleDesc = null;
		EffectDesc = null;
		LifeGateFeatures = new short[0];
		DeathGateFeatures = new short[0];
		NeiliProportionOfFiveElements = new sbyte[5] { 20, 20, 20, 20, 20 };
	}

	public NeiliTypeItem(sbyte templateId, NeiliTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		FiveElements = other.FiveElements;
		IdeaAllocationProportion = other.IdeaAllocationProportion;
		MaxPowerChange = other.MaxPowerChange;
		RequirementChange = other.RequirementChange;
		InjuryOnUseType = other.InjuryOnUseType;
		ShowConflictingWorldState = other.ShowConflictingWorldState;
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
		PoisonResists = other.PoisonResists;
		ColorType = other.ColorType;
		LinePos = other.LinePos;
		LineAngle = other.LineAngle;
		TypeIconPos = other.TypeIconPos;
		NeiliTypeConditionText = other.NeiliTypeConditionText;
		SimpleDesc = other.SimpleDesc;
		EffectDesc = other.EffectDesc;
		LifeGateFeatures = other.LifeGateFeatures;
		DeathGateFeatures = other.DeathGateFeatures;
		NeiliProportionOfFiveElements = other.NeiliProportionOfFiveElements;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override NeiliTypeItem Duplicate(int templateId)
	{
		return new NeiliTypeItem((sbyte)templateId, this);
	}
}
