using Config;

namespace GameData.Domains.CombatSkill;

public static class CombatSkillEquipType
{
	public const sbyte Invalid = -1;

	public const sbyte Neigong = 0;

	public const sbyte Attack = 1;

	public const sbyte Agile = 2;

	public const sbyte Defense = 3;

	public const sbyte Assist = 4;

	public const int Count = 5;

	public static bool IsMindHitSkill(short skillId)
	{
		return Config.CombatSkill.Instance[skillId].PerHitDamageRateDistribution[3] == 100;
	}

	public static bool IsAttack(short skillId)
	{
		return Config.CombatSkill.Instance[skillId].EquipType == 1;
	}

	public static bool IsAgile(short skillId)
	{
		return Config.CombatSkill.Instance[skillId].EquipType == 2;
	}

	public static bool IsDefense(short skillId)
	{
		return Config.CombatSkill.Instance[skillId].EquipType == 3;
	}

	public static bool IsAssist(short skillId)
	{
		return Config.CombatSkill.Instance[skillId].EquipType == 4;
	}
}
