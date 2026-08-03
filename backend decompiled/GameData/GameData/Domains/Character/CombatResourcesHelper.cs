using System;

namespace GameData.Domains.Character;

public static class CombatResourcesHelper
{
	public static CombatResources GetMax(Character character)
	{
		short medicineAttainment = character.GetLifeSkillAttainment(8);
		short toxicologyAttainment = character.GetLifeSkillAttainment(9);
		return new CombatResources
		{
			HealingCount = (sbyte)Math.Min(1 + medicineAttainment / 60, 99),
			DetoxCount = (sbyte)Math.Min(1 + toxicologyAttainment / 60, 99),
			BreathingCount = 1,
			RecoverCount = 1
		};
	}
}
