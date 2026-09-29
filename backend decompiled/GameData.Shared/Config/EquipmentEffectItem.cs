using System;
using Config.Common;
using GameData.Domains.Character;

namespace Config;

[Serializable]
public class EquipmentEffectItem : ConfigItem<EquipmentEffectItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly sbyte Type;

	public readonly bool Special;

	public readonly bool IsTotalPercent;

	public readonly string Desc;

	public readonly short[] HitFactors;

	public readonly HitOrAvoidShorts AvoidFactors;

	public readonly OuterAndInnerShorts PenetrationResistFactors;

	public readonly OuterAndInnerShorts InjuryFactors;

	public readonly int EquipmentAttackChange;

	public readonly int EquipmentDefenseChange;

	public readonly int WeightChange;

	public readonly int MaxDurabilityChange;

	public readonly int ValueChange;

	public readonly int FavorChange;

	public readonly int RequirementChange;

	public readonly string EffectClassName;

	public EquipmentEffectItem(short templateId, string name, sbyte type, bool special, bool isTotalPercent, string desc, short[] hitFactors, HitOrAvoidShorts avoidFactors, OuterAndInnerShorts penetrationResistFactors, OuterAndInnerShorts injuryFactors, int equipmentAttackChange, int equipmentDefenseChange, int weightChange, int maxDurabilityChange, int valueChange, int favorChange, int requirementChange, string effectClassName)
	{
		TemplateId = templateId;
		Name = name;
		Type = type;
		Special = special;
		IsTotalPercent = isTotalPercent;
		Desc = desc;
		HitFactors = hitFactors;
		AvoidFactors = avoidFactors;
		PenetrationResistFactors = penetrationResistFactors;
		InjuryFactors = injuryFactors;
		EquipmentAttackChange = equipmentAttackChange;
		EquipmentDefenseChange = equipmentDefenseChange;
		WeightChange = weightChange;
		MaxDurabilityChange = maxDurabilityChange;
		ValueChange = valueChange;
		FavorChange = favorChange;
		RequirementChange = requirementChange;
		EffectClassName = effectClassName;
	}

	public EquipmentEffectItem()
	{
		TemplateId = 0;
		Name = null;
		Type = -1;
		Special = false;
		IsTotalPercent = false;
		Desc = null;
		HitFactors = new short[4];
		AvoidFactors = new HitOrAvoidShorts(default(short), default(short), default(short), default(short));
		PenetrationResistFactors = new OuterAndInnerShorts(0, 0);
		InjuryFactors = new OuterAndInnerShorts(0, 0);
		EquipmentAttackChange = 0;
		EquipmentDefenseChange = 0;
		WeightChange = 0;
		MaxDurabilityChange = 0;
		ValueChange = 0;
		FavorChange = 0;
		RequirementChange = 0;
		EffectClassName = null;
	}

	public EquipmentEffectItem(short templateId, EquipmentEffectItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Type = other.Type;
		Special = other.Special;
		IsTotalPercent = other.IsTotalPercent;
		Desc = other.Desc;
		HitFactors = other.HitFactors;
		AvoidFactors = other.AvoidFactors;
		PenetrationResistFactors = other.PenetrationResistFactors;
		InjuryFactors = other.InjuryFactors;
		EquipmentAttackChange = other.EquipmentAttackChange;
		EquipmentDefenseChange = other.EquipmentDefenseChange;
		WeightChange = other.WeightChange;
		MaxDurabilityChange = other.MaxDurabilityChange;
		ValueChange = other.ValueChange;
		FavorChange = other.FavorChange;
		RequirementChange = other.RequirementChange;
		EffectClassName = other.EffectClassName;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override EquipmentEffectItem Duplicate(int templateId)
	{
		return new EquipmentEffectItem((short)templateId, this);
	}
}
