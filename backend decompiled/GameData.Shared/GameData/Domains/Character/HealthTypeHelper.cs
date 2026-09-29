using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Combat.Math;

namespace GameData.Domains.Character;

public static class HealthTypeHelper
{
	private static readonly CValuePercent DyingPercent = 0;

	private static readonly CValuePercent CriticallyIllPercent = 25;

	private static readonly CValuePercent WeakPercent = 50;

	private static readonly CValuePercent SickPercent = 75;

	public static EHealthType CalcType(IEnumerable<short> featureIds, short health, short maxHealth)
	{
		if (featureIds.Any(IgnoreMark))
		{
			return EHealthType.Unknown;
		}
		if (health < maxHealth * DyingPercent || maxHealth < 0)
		{
			return EHealthType.Dying;
		}
		if (health <= maxHealth * CriticallyIllPercent || maxHealth <= 6)
		{
			return EHealthType.CriticallyIll;
		}
		if (health <= maxHealth * WeakPercent || maxHealth <= 12)
		{
			return EHealthType.Weak;
		}
		if (health <= maxHealth * SickPercent || maxHealth <= 24)
		{
			return EHealthType.Sick;
		}
		return EHealthType.Healthy;
	}

	public static EHealthType CalcType(short health, short maxHealth)
	{
		if (health < maxHealth * DyingPercent || maxHealth < 0)
		{
			return EHealthType.Dying;
		}
		if (health <= maxHealth * CriticallyIllPercent || maxHealth <= 6)
		{
			return EHealthType.CriticallyIll;
		}
		if (health <= maxHealth * WeakPercent || maxHealth <= 12)
		{
			return EHealthType.Weak;
		}
		if (health <= maxHealth * SickPercent || maxHealth <= 24)
		{
			return EHealthType.Sick;
		}
		return EHealthType.Healthy;
	}

	private static bool IgnoreMark(short featureId)
	{
		return CharacterFeature.Instance[featureId].HealthImmunity;
	}

	public static int ToCommonIndex(this EHealthType healthType)
	{
		return healthType switch
		{
			EHealthType.Healthy => 0, 
			EHealthType.Sick => 1, 
			EHealthType.Weak => 2, 
			EHealthType.CriticallyIll => 3, 
			EHealthType.Dying => 4, 
			_ => -1, 
		};
	}
}
