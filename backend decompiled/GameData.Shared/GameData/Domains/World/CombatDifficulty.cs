using System;

namespace GameData.Domains.World;

/// <summary>
/// 战斗难度
/// </summary>
[Obsolete("Use GameData.Domains.World.Difficulty instead.")]
public static class CombatDifficulty
{
	/// <summary>
	/// 信步
	/// </summary>
	public const byte Easy = 0;

	/// <summary>
	/// 闯荡
	/// </summary>
	public const byte Normal = 1;

	/// <summary>
	/// 履冰
	/// </summary>
	public const byte Hard = 2;

	/// <summary>
	/// 劫数
	/// </summary>
	public const byte VeryHard = 3;
}
