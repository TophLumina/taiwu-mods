namespace GameData.Domains.Character;

public static class SkillGroup
{
	public const sbyte LifeSkill = 0;

	public const sbyte CombatSkill = 1;

	public const int Count = 2;

	public static sbyte FromItemSubType(short itemSubType)
	{
		return (sbyte)(itemSubType - 1000);
	}
}
