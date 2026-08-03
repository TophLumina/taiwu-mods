using System.Collections.Generic;
using GameData.Combat.Math;

namespace GameData.Combat.Cricket;

public struct CricketInjury
{
	public int Hp;

	public int Sp;

	public int Vigor;

	public int Strength;

	public int Bite;

	public bool IsZero
	{
		get
		{
			if (Hp <= 0 && Sp <= 0 && Vigor <= 0 && Strength <= 0)
			{
				return Bite <= 0;
			}
			return false;
		}
	}

	public bool IsNonZero => !IsZero;

	public CValueModifyDelta GetModify(ECricketCombatPropertyType propertyType)
	{
		return propertyType switch
		{
			ECricketCombatPropertyType.Hp => new CValueModifyDelta(EDataModifyType.Add, -Hp), 
			ECricketCombatPropertyType.Sp => new CValueModifyDelta(EDataModifyType.Add, -Sp), 
			ECricketCombatPropertyType.Vigor => new CValueModifyDelta(EDataModifyType.Add, -Vigor), 
			ECricketCombatPropertyType.Strength => new CValueModifyDelta(EDataModifyType.Add, -Strength), 
			ECricketCombatPropertyType.Bite => new CValueModifyDelta(EDataModifyType.Add, -Bite), 
			_ => CValueModifyDelta.Zero, 
		};
	}

	public static CricketInjury operator +(CricketInjury a, CricketInjury b)
	{
		return new CricketInjury
		{
			Hp = a.Hp + b.Hp,
			Sp = a.Sp + b.Sp,
			Vigor = a.Vigor + b.Vigor,
			Strength = a.Strength + b.Strength,
			Bite = a.Bite + b.Bite
		};
	}

	public static CricketInjury operator *(CricketInjury injury, int multiplier)
	{
		return new CricketInjury
		{
			Hp = injury.Hp * multiplier,
			Sp = injury.Sp * multiplier,
			Vigor = injury.Vigor * multiplier,
			Strength = injury.Strength * multiplier,
			Bite = injury.Bite * multiplier
		};
	}

	public override string ToString()
	{
		if (IsZero)
		{
			return "Injury(Zero)";
		}
		List<string> injuries = new List<string>();
		if (Hp > 0)
		{
			injuries.Add($"Hp-{Hp}");
		}
		if (Sp > 0)
		{
			injuries.Add($"Sp-{Sp}");
		}
		if (Vigor > 0)
		{
			injuries.Add($"Vigor-{Vigor}");
		}
		if (Strength > 0)
		{
			injuries.Add($"Strength-{Strength}");
		}
		if (Bite > 0)
		{
			injuries.Add($"Bite-{Bite}");
		}
		return "Injury(" + string.Join(',', injuries) + ")";
	}
}
