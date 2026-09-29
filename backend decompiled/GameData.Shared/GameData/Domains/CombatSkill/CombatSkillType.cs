using Config;

namespace GameData.Domains.CombatSkill;

public static class CombatSkillType
{
	public const sbyte None = -1;

	public const sbyte Neigong = 0;

	public const sbyte Posing = 1;

	public const sbyte Stunt = 2;

	public const sbyte FistAndPalm = 3;

	public const sbyte Finger = 4;

	public const sbyte Leg = 5;

	public const sbyte Throw = 6;

	public const sbyte Sword = 7;

	public const sbyte Blade = 8;

	public const sbyte Polearm = 9;

	public const sbyte Special = 10;

	public const sbyte Whip = 11;

	public const sbyte ControllableShot = 12;

	public const sbyte CombatMusic = 13;

	public const int Count = 14;

	public static bool IsLeg(short skillId)
	{
		return Config.CombatSkill.Instance[skillId].Type == 5;
	}
}
