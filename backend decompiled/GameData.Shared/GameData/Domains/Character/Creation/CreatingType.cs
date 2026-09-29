namespace GameData.Domains.Character.Creation;

public static class CreatingType
{
	public const byte FixedCharacter = 0;

	public const byte IntelligentCharacter = 1;

	public const byte RandomEnemy = 2;

	public const byte FixedEnemy = 3;

	public static bool IsFixedPresetType(byte creatingType)
	{
		if (creatingType != 0)
		{
			return creatingType == 3;
		}
		return true;
	}

	public static bool IsNonEvolutionaryType(byte creatingType)
	{
		if (creatingType != 0 && creatingType != 2)
		{
			return creatingType == 3;
		}
		return true;
	}
}
