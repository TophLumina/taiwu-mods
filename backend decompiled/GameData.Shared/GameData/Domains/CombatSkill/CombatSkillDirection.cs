using Redzen.Random;

namespace GameData.Domains.CombatSkill;

public static class CombatSkillDirection
{
	public const sbyte NotInited = -2;

	public const sbyte None = -1;

	public const sbyte Direct = 0;

	public const sbyte Reverse = 1;

	public const int Count = 2;

	public static sbyte GetRandomDirection(IRandomSource random)
	{
		return (sbyte)random.Next(2);
	}
}
