using Config;

namespace GameData.Domains.CombatSkill;

/// <summary>
/// 功法装备类型
/// </summary>
public static class CombatSkillEquipType
{
	/// <summary>
	/// 无效
	/// </summary>
	public const sbyte Invalid = -1;

	/// <summary>
	/// 内功
	/// </summary>
	public const sbyte Neigong = 0;

	/// <summary>
	/// 摧破
	/// </summary>
	public const sbyte Attack = 1;

	/// <summary>
	/// 轻灵
	/// </summary>
	public const sbyte Agile = 2;

	/// <summary>
	/// 护体
	/// </summary>
	public const sbyte Defense = 3;

	/// <summary>
	/// 奇窍
	/// </summary>
	public const sbyte Assist = 4;

	/// <summary>
	/// 数量
	/// </summary>
	public const int Count = 5;

	/// <summary>
	/// 是否心神命中功法
	/// </summary>
	public static bool IsMindHitSkill(short skillId)
	{
		return Config.CombatSkill.Instance[skillId].PerHitDamageRateDistribution[3] == 100;
	}

	/// <summary>
	/// 是否摧破功法
	/// </summary>
	public static bool IsAttack(short skillId)
	{
		return Config.CombatSkill.Instance[skillId].EquipType == 1;
	}

	/// <summary>
	/// 是否轻灵功法
	/// </summary>
	public static bool IsAgile(short skillId)
	{
		return Config.CombatSkill.Instance[skillId].EquipType == 2;
	}

	/// <summary>
	/// 是否护体功法
	/// </summary>
	public static bool IsDefense(short skillId)
	{
		return Config.CombatSkill.Instance[skillId].EquipType == 3;
	}

	/// <summary>
	/// 是否奇窍功法
	/// </summary>
	public static bool IsAssist(short skillId)
	{
		return Config.CombatSkill.Instance[skillId].EquipType == 4;
	}
}
