using System;
using System.Diagnostics.CodeAnalysis;
using Config.Common;

namespace Config;

[Serializable]
public class MixPoisonEffectItem : ConfigItem<MixPoisonEffectItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string ShortDesc;

	public readonly short MedicineId;

	public readonly short EffectId;

	public readonly sbyte[] HasPoisonTypes;

	public readonly sbyte[] AffectPoisonTypes;

	public readonly bool InstantEffect;

	public readonly short LifeRecord;

	public MedicineItem Medicine
	{
		[return: MaybeNull]
		get
		{
			return Config.Medicine.Instance.GetItemOrDefault(MedicineId);
		}
	}

	public SpecialEffectItem Effect
	{
		[return: MaybeNull]
		get
		{
			return SpecialEffect.Instance.GetItemOrDefault(EffectId);
		}
	}

	public MixPoisonEffectItem(sbyte templateId, string shortDesc, short medicineId, short effectId, sbyte[] hasPoisonTypes, sbyte[] affectPoisonTypes, bool instantEffect, short lifeRecord)
	{
		TemplateId = templateId;
		ShortDesc = shortDesc;
		MedicineId = medicineId;
		EffectId = effectId;
		HasPoisonTypes = hasPoisonTypes;
		AffectPoisonTypes = affectPoisonTypes;
		InstantEffect = instantEffect;
		LifeRecord = lifeRecord;
	}

	public MixPoisonEffectItem()
	{
		TemplateId = 0;
		ShortDesc = null;
		MedicineId = 0;
		EffectId = 0;
		HasPoisonTypes = null;
		AffectPoisonTypes = null;
		InstantEffect = false;
		LifeRecord = 0;
	}

	public MixPoisonEffectItem(sbyte templateId, MixPoisonEffectItem other)
	{
		TemplateId = templateId;
		ShortDesc = other.ShortDesc;
		MedicineId = other.MedicineId;
		EffectId = other.EffectId;
		HasPoisonTypes = other.HasPoisonTypes;
		AffectPoisonTypes = other.AffectPoisonTypes;
		InstantEffect = other.InstantEffect;
		LifeRecord = other.LifeRecord;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override MixPoisonEffectItem Duplicate(int templateId)
	{
		return new MixPoisonEffectItem((sbyte)templateId, this);
	}
}
