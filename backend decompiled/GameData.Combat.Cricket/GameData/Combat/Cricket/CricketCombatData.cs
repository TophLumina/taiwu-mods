using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using GameData.Combat.Math;

namespace GameData.Combat.Cricket;

public class CricketCombatData
{
	private static long _nextIdInternalValue;

	public readonly long RuntimeId;

	public readonly bool IsTrash;

	public CricketCore Core;

	public CricketInjury Injury;

	public int Hp;

	public int Sp;

	public int Durability;

	public int MaxDurability;

	public int DurabilityInjury;

	public readonly ECricketCombatSkillType Skill;

	private readonly List<CricketCombatSkillPropertyModify> _skillPropertyModifies = new List<CricketCombatSkillPropertyModify>();

	private static long NextRuntimeId => Interlocked.Increment(ref _nextIdInternalValue);

	public int Grade => Core.Grade;

	public int MaxHp => Core.Hp * GetModify(ECricketCombatPropertyType.Hp);

	public int MaxSp => Core.Sp * GetModify(ECricketCombatPropertyType.Sp);

	public int Vigor => Core.Vigor * GetModify(ECricketCombatPropertyType.Vigor);

	public int Strength => Core.Strength * GetModify(ECricketCombatPropertyType.Strength);

	public int Bite => Core.Bite * GetModify(ECricketCombatPropertyType.Bite);

	public int Deadliness => Core.Deadliness * GetModify(ECricketCombatPropertyType.Deadliness);

	public int Damage => Core.Damage * GetModify(ECricketCombatPropertyType.Damage);

	public int Cripple => Core.Cripple * GetModify(ECricketCombatPropertyType.Cripple);

	public int Defense => Core.Defense * GetModify(ECricketCombatPropertyType.Defense);

	public int DamageReduce => Core.DamageReduce * GetModify(ECricketCombatPropertyType.DamageReduce);

	public int Counter => Core.Counter * GetModify(ECricketCombatPropertyType.Counter);

	public bool IsFail
	{
		get
		{
			if (Hp > 0 && Sp > 0)
			{
				return Durability <= 0;
			}
			return true;
		}
	}

	public bool IsHalfFail
	{
		get
		{
			if (!IsHalfFailHp && !IsHalfFailSp)
			{
				return IsHalfFailDurability;
			}
			return true;
		}
	}

	public bool IsHalfFailHp => CValuePercent.ParseInt(Hp, MaxHp) <= 50;

	public bool IsHalfFailSp => CValuePercent.ParseInt(Sp, MaxSp) <= 50;

	public bool IsHalfFailDurability => CValuePercent.ParseInt(Durability, MaxDurability) <= 50;

	public bool IsDie => Durability <= 0;

	public CricketCore ModifiedCore
	{
		get
		{
			CricketCore core = Core;
			foreach (ECricketCombatPropertyType type in CricketCombatPropertyTypeHelper.AllProperties)
			{
				core.SetProperty(type, core.GetProperty(type) * GetModify(type));
			}
			return core;
		}
	}

	public CricketCombatData(bool isTrash, CricketCore core, ECricketCombatSkillType skill, int durability, int maxDurability)
	{
		RuntimeId = NextRuntimeId;
		IsTrash = isTrash;
		Core = core;
		Skill = skill;
		Hp = MaxHp;
		Sp = MaxSp;
		Durability = durability;
		MaxDurability = durability;
		DurabilityInjury = maxDurability - Durability;
	}

	public CricketCombatData(CricketCombatData other)
	{
		RuntimeId = other.RuntimeId;
		IsTrash = other.IsTrash;
		Core = other.Core;
		Injury = other.Injury;
		Skill = other.Skill;
		Hp = other.Hp;
		Sp = other.Sp;
		Durability = other.Durability;
		MaxDurability = other.MaxDurability;
		DurabilityInjury = other.DurabilityInjury;
	}

	public int GetBaseDamage(ECricketCombatDamageType damageType)
	{
		return damageType switch
		{
			ECricketCombatDamageType.Vigor => Vigor, 
			ECricketCombatDamageType.Strength => Strength, 
			ECricketCombatDamageType.Bite => Bite, 
			ECricketCombatDamageType.Skill => 0, 
			_ => throw new ArgumentOutOfRangeException("damageType", damageType, null), 
		};
	}

	public void ApplyDamage(CricketCombatDamage damage)
	{
		Injury += damage.Injury;
		ChangeHp(-damage.Hp);
		ChangeSp(-damage.Sp);
		ChangeDurability(-damage.Durability);
	}

	public bool SimulateDamage(CricketCombatDamage damage)
	{
		if (damage.Injury.Hp > MaxHp || damage.Injury.Sp > MaxSp)
		{
			return true;
		}
		if (damage.Hp <= Hp && damage.Sp <= Sp)
		{
			return damage.Durability > Durability;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ChangeHp(int delta)
	{
		Hp = System.Math.Clamp(Hp + delta, 0, MaxHp);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ChangeSp(int delta)
	{
		Sp = System.Math.Clamp(Sp + delta, 0, MaxSp);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ChangeDurability(int delta)
	{
		Durability = (short)System.Math.Clamp(Durability + delta, 0, MaxDurability);
	}

	public void AddSkillPropertyModify(CricketCombatSkillPropertyModify skillModify)
	{
		_skillPropertyModifies.Add(skillModify);
	}

	public void ClearRoundPropertyModify()
	{
		for (int i = _skillPropertyModifies.Count - 1; i >= 0; i--)
		{
			if (_skillPropertyModifies[i].LifeCycle == ECricketCombatPropertyModifyLifeCycle.Round)
			{
				_skillPropertyModifies.RemoveAt(i);
			}
		}
	}

	private CValueModify GetModify(ECricketCombatPropertyType propertyType)
	{
		CValueModify modify = CValueModify.Zero;
		modify += Injury.GetModify(propertyType);
		foreach (CricketCombatSkillPropertyModify skillModify in _skillPropertyModifies)
		{
			if (skillModify.PropertyType == propertyType)
			{
				modify += skillModify.ModifyDelta;
			}
		}
		return modify;
	}

	public override string ToString()
	{
		return "Cricket(" + RuntimeId + ")";
	}
}
