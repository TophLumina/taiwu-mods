namespace GameData.Domains.Item;

public static class WugGrowthType
{
	public const sbyte Invalid = -1;

	public const sbyte GrowingGood1 = 0;

	public const sbyte GrowingGood2 = 1;

	public const sbyte GrowingBad1 = 2;

	public const sbyte GrowingBad2 = 3;

	public const sbyte Grown = 4;

	public const sbyte King = 5;

	public const int Count = 6;

	public static bool IsWugGrowthTypeCombatOnly(sbyte wugGrowthType)
	{
		if (wugGrowthType == 0 || wugGrowthType == 2)
		{
			return true;
		}
		return false;
	}

	public static bool CanChangeToGrown(sbyte wugGrowthType)
	{
		if (wugGrowthType == 1 || wugGrowthType == 3)
		{
			return true;
		}
		return false;
	}

	public static bool IsGood(sbyte wugGrowthType)
	{
		if ((uint)wugGrowthType <= 1u)
		{
			return true;
		}
		return false;
	}

	public static bool IsBad(sbyte wugGrowthType)
	{
		return !IsGood(wugGrowthType);
	}
}
