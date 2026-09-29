using System;
using System.Diagnostics.CodeAnalysis;
using Config.Common;

namespace Config;

[Serializable]
public class WeaponUnlockEffectItem : ConfigItem<WeaponUnlockEffectItem, int>
{
	public readonly int TemplateId;

	public readonly bool IgnoreAttackRange;

	public readonly bool ClearAgile;

	public readonly bool ClearDefense;

	public readonly bool ChangeToOld;

	public readonly int PoisonRatio;

	public readonly sbyte[] FlawLevels;

	public readonly sbyte[] AcupointLevels;

	public readonly int StealNeiliAllocationPercent;

	public readonly int SilenceSkillFrame;

	public readonly int AddQiDisorder;

	public readonly string Desc;

	public readonly string Animation;

	public readonly string Particle;

	public readonly string Sound;

	public readonly sbyte[] DisplayPosition;

	public readonly short EffectId;

	public SpecialEffectItem Effect
	{
		[return: MaybeNull]
		get
		{
			return SpecialEffect.Instance.GetItemOrDefault(EffectId);
		}
	}

	public WeaponUnlockEffectItem(int templateId, bool ignoreAttackRange, bool clearAgile, bool clearDefense, bool changeToOld, int poisonRatio, sbyte[] flawLevels, sbyte[] acupointLevels, int stealNeiliAllocationPercent, int silenceSkillFrame, int addQiDisorder, string desc, string animation, string particle, string sound, sbyte[] displayPosition, short effectId)
	{
		TemplateId = templateId;
		IgnoreAttackRange = ignoreAttackRange;
		ClearAgile = clearAgile;
		ClearDefense = clearDefense;
		ChangeToOld = changeToOld;
		PoisonRatio = poisonRatio;
		FlawLevels = flawLevels;
		AcupointLevels = acupointLevels;
		StealNeiliAllocationPercent = stealNeiliAllocationPercent;
		SilenceSkillFrame = silenceSkillFrame;
		AddQiDisorder = addQiDisorder;
		Desc = desc;
		Animation = animation;
		Particle = particle;
		Sound = sound;
		DisplayPosition = displayPosition;
		EffectId = effectId;
	}

	public WeaponUnlockEffectItem()
	{
		TemplateId = 0;
		IgnoreAttackRange = false;
		ClearAgile = false;
		ClearDefense = false;
		ChangeToOld = false;
		PoisonRatio = 1;
		FlawLevels = new sbyte[0];
		AcupointLevels = new sbyte[0];
		StealNeiliAllocationPercent = 0;
		SilenceSkillFrame = 0;
		AddQiDisorder = 0;
		Desc = null;
		Animation = null;
		Particle = null;
		Sound = null;
		DisplayPosition = null;
		EffectId = 0;
	}

	public WeaponUnlockEffectItem(int templateId, WeaponUnlockEffectItem other)
	{
		TemplateId = templateId;
		IgnoreAttackRange = other.IgnoreAttackRange;
		ClearAgile = other.ClearAgile;
		ClearDefense = other.ClearDefense;
		ChangeToOld = other.ChangeToOld;
		PoisonRatio = other.PoisonRatio;
		FlawLevels = other.FlawLevels;
		AcupointLevels = other.AcupointLevels;
		StealNeiliAllocationPercent = other.StealNeiliAllocationPercent;
		SilenceSkillFrame = other.SilenceSkillFrame;
		AddQiDisorder = other.AddQiDisorder;
		Desc = other.Desc;
		Animation = other.Animation;
		Particle = other.Particle;
		Sound = other.Sound;
		DisplayPosition = other.DisplayPosition;
		EffectId = other.EffectId;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override WeaponUnlockEffectItem Duplicate(int templateId)
	{
		return new WeaponUnlockEffectItem(templateId, this);
	}
}
