using System.Collections.Generic;

namespace GameData.Combat.Cricket;

public static class CricketCombatPropertyTypeHelper
{
	public static IEnumerable<ECricketCombatPropertyType> AllProperties
	{
		get
		{
			yield return ECricketCombatPropertyType.Hp;
			yield return ECricketCombatPropertyType.Sp;
			yield return ECricketCombatPropertyType.Vigor;
			yield return ECricketCombatPropertyType.Strength;
			yield return ECricketCombatPropertyType.Bite;
			yield return ECricketCombatPropertyType.Deadliness;
			yield return ECricketCombatPropertyType.Damage;
			yield return ECricketCombatPropertyType.Cripple;
			yield return ECricketCombatPropertyType.Defense;
			yield return ECricketCombatPropertyType.DamageReduce;
			yield return ECricketCombatPropertyType.Counter;
		}
	}
}
