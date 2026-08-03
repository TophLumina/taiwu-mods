using System.Collections.Generic;
using Config;

namespace GameData.Domains.Character;

public readonly ref struct MedicineEatingInstantEffect
{
	public readonly sbyte Grade;

	public readonly EMedicineEffectType EffectType;

	public readonly EMedicineEffectSubType EffectSubType;

	public readonly short EffectThresholdValue;

	public readonly short EffectValue;

	public readonly sbyte InjuryRecoveryTimes;

	public readonly short SideEffectValue;

	public readonly IReadOnlyList<sbyte> TargetBodyParts;

	public sbyte PoisonType => EffectSubType.PoisonType();

	public sbyte DetoxPoisonType => EffectSubType.DetoxPoisonType();

	public sbyte ApplyPoisonType => EffectSubType.ApplyPoisonType();

	public sbyte DetoxWugType => EMedicineEffectSubTypeExtension.DetoxWugType(EffectType, SideEffectValue);

	public EMedicineEffectSubTypeExtension.Operate OperateType => EffectSubType.OperateType();

	public bool EffectIsPercentage => EffectSubType.IsPercentage();

	public bool EffectIsValue => EffectSubType.IsValue();

	public MedicineEatingInstantEffect(MedicineItem cfg, IReadOnlyList<sbyte> targetBodyParts = null)
	{
		Grade = cfg.Grade;
		EffectType = cfg.EffectType;
		EffectSubType = cfg.EffectSubType;
		EffectThresholdValue = cfg.EffectThresholdValue;
		EffectValue = cfg.EffectValue;
		InjuryRecoveryTimes = cfg.InjuryRecoveryTimes;
		SideEffectValue = cfg.SideEffectValue;
		TargetBodyParts = targetBodyParts;
	}

	public MedicineEatingInstantEffect(MaterialItem cfg, bool primary)
	{
		if (primary)
		{
			Grade = cfg.Grade;
			EffectType = cfg.PrimaryEffectType;
			EffectSubType = cfg.PrimaryEffectSubType;
			EffectThresholdValue = cfg.PrimaryEffectThresholdValue;
			EffectValue = cfg.PrimaryEffectValue;
			InjuryRecoveryTimes = cfg.PrimaryInjuryRecoveryTimes;
		}
		else
		{
			Grade = cfg.Grade;
			EffectType = cfg.SecondaryEffectType;
			EffectSubType = cfg.SecondaryEffectSubType;
			EffectThresholdValue = cfg.SecondaryEffectThresholdValue;
			EffectValue = cfg.SecondaryEffectValue;
			InjuryRecoveryTimes = cfg.SecondaryInjuryRecoveryTimes;
		}
		SideEffectValue = 0;
		TargetBodyParts = null;
	}
}
