using System;

namespace GameData.Combat.Cricket;

public struct CricketCore
{
	public sbyte Grade;

	public int Hp;

	public int Sp;

	public int Vigor;

	public int Strength;

	public int Bite;

	public int Deadliness;

	public int Damage;

	public int Cripple;

	public int Defense;

	public int DamageReduce;

	public int Counter;

	public int GetProperty(ECricketCombatPropertyType propertyType)
	{
		return propertyType switch
		{
			ECricketCombatPropertyType.Hp => Hp, 
			ECricketCombatPropertyType.Sp => Sp, 
			ECricketCombatPropertyType.Vigor => Vigor, 
			ECricketCombatPropertyType.Strength => Strength, 
			ECricketCombatPropertyType.Bite => Bite, 
			ECricketCombatPropertyType.Deadliness => Deadliness, 
			ECricketCombatPropertyType.Damage => Damage, 
			ECricketCombatPropertyType.Cripple => Cripple, 
			ECricketCombatPropertyType.Defense => Defense, 
			ECricketCombatPropertyType.DamageReduce => DamageReduce, 
			ECricketCombatPropertyType.Counter => Counter, 
			_ => 0, 
		};
	}

	public void SetProperty(ECricketCombatPropertyType propertyType, int value)
	{
		switch (propertyType)
		{
		case ECricketCombatPropertyType.Hp:
			Hp = value;
			break;
		case ECricketCombatPropertyType.Sp:
			Sp = value;
			break;
		case ECricketCombatPropertyType.Vigor:
			Vigor = value;
			break;
		case ECricketCombatPropertyType.Strength:
			Strength = value;
			break;
		case ECricketCombatPropertyType.Bite:
			Bite = value;
			break;
		case ECricketCombatPropertyType.Deadliness:
			Deadliness = value;
			break;
		case ECricketCombatPropertyType.Damage:
			Damage = value;
			break;
		case ECricketCombatPropertyType.Cripple:
			Cripple = value;
			break;
		case ECricketCombatPropertyType.Defense:
			Defense = value;
			break;
		case ECricketCombatPropertyType.DamageReduce:
			DamageReduce = value;
			break;
		case ECricketCombatPropertyType.Counter:
			Counter = value;
			break;
		}
	}

	public static CricketCore operator +(CricketCore a, CricketCore b)
	{
		return new CricketCore
		{
			Grade = System.Math.Max(a.Grade, b.Grade),
			Hp = a.Hp + b.Hp,
			Sp = a.Sp + b.Sp,
			Vigor = a.Vigor + b.Vigor,
			Strength = a.Strength + b.Strength,
			Bite = a.Bite + b.Bite,
			Deadliness = a.Deadliness + b.Deadliness,
			Damage = a.Damage + b.Damage,
			Cripple = a.Cripple + b.Cripple,
			Defense = a.Defense + b.Defense,
			DamageReduce = a.DamageReduce + b.DamageReduce,
			Counter = a.Counter + b.Counter
		};
	}
}
