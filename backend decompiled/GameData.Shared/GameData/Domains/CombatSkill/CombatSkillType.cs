using Config;

namespace GameData.Domains.CombatSkill;

/// <summary>
/// 武学类型
/// </summary>
public static class CombatSkillType
{
	/// <summary>
	/// 无
	/// </summary>
	public const sbyte None = -1;

	/// <summary>
	/// 内功
	/// </summary>
	public const sbyte Neigong = 0;

	/// <summary>
	/// 身法
	/// </summary>
	public const sbyte Posing = 1;

	/// <summary>
	/// 绝技
	/// </summary>
	public const sbyte Stunt = 2;

	/// <summary>
	/// 拳掌
	/// </summary>
	public const sbyte FistAndPalm = 3;

	/// <summary>
	/// 指法
	/// </summary>
	public const sbyte Finger = 4;

	/// <summary>
	/// 腿法
	/// </summary>
	public const sbyte Leg = 5;

	/// <summary>
	/// 暗器
	/// </summary>
	public const sbyte Throw = 6;

	/// <summary>
	/// 剑法
	/// </summary>
	public const sbyte Sword = 7;

	/// <summary>
	/// 刀法
	/// </summary>
	public const sbyte Blade = 8;

	/// <summary>
	/// 长兵
	/// </summary>
	public const sbyte Polearm = 9;

	/// <summary>
	/// 奇门
	/// </summary>
	public const sbyte Special = 10;

	/// <summary>
	/// 软兵
	/// </summary>
	public const sbyte Whip = 11;

	/// <summary>
	/// 御射
	/// </summary>
	public const sbyte ControllableShot = 12;

	/// <summary>
	/// 乐器
	/// </summary>
	public const sbyte CombatMusic = 13;

	/// <summary>
	/// 总个数
	/// </summary>
	public const int Count = 14;

	/// <summary>
	/// 是否腿法
	/// </summary>
	public static bool IsLeg(short skillId)
	{
		return Config.CombatSkill.Instance[skillId].Type == 5;
	}
}
