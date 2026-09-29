using System;

namespace GameData.Domains.World;

[Obsolete("Use GameData.Domains.World.Difficulty instead.")]
public static class CombatDifficulty
{
	public const byte Easy = 0;

	public const byte Normal = 1;

	public const byte Hard = 2;

	public const byte VeryHard = 3;
}
