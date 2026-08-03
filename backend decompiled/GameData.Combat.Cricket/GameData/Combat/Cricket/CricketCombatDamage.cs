using System.Collections.Generic;

namespace GameData.Combat.Cricket;

public struct CricketCombatDamage
{
	public int Hp;

	public int Sp;

	public int Durability;

	public CricketInjury Injury;

	public bool IsZeroExceptInjury
	{
		get
		{
			if (Hp == 0 && Sp == 0)
			{
				return Durability == 0;
			}
			return false;
		}
	}

	public bool IsNonZeroExceptInjury => !IsZeroExceptInjury;

	public bool IsZero
	{
		get
		{
			if (IsZeroExceptInjury)
			{
				return Injury.IsZero;
			}
			return false;
		}
	}

	public bool IsNonZero => !IsZero;

	public static CricketCombatDamage Create(ECricketCombatDamageType type, int damage = 0)
	{
		CricketCombatDamage result = default(CricketCombatDamage);
		if ((uint)(type - 1) <= 1u)
		{
			result.Hp = damage;
		}
		else if (type == ECricketCombatDamageType.Vigor)
		{
			result.Sp = damage;
		}
		return result;
	}

	public static CricketCombatDamage operator *(CricketCombatDamage damage, int multiplier)
	{
		return new CricketCombatDamage
		{
			Hp = damage.Hp * multiplier,
			Sp = damage.Sp * multiplier,
			Durability = damage.Durability * multiplier,
			Injury = damage.Injury * multiplier
		};
	}

	public override string ToString()
	{
		if (IsZero)
		{
			return "Damage(Zero)";
		}
		List<string> damages = new List<string>();
		if (Hp != 0)
		{
			damages.Add("Hp" + CricketCombatHelper.FormatReduce(Hp));
		}
		if (Sp != 0)
		{
			damages.Add("Sp" + CricketCombatHelper.FormatReduce(Sp));
		}
		if (Durability != 0)
		{
			damages.Add("Durability" + CricketCombatHelper.FormatReduce(Durability));
		}
		if (Injury.IsNonZero)
		{
			damages.Add(Injury.ToString());
		}
		return "Damage(" + string.Join(',', damages) + ")";
	}
}
