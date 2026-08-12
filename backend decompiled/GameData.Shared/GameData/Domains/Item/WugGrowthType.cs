namespace GameData.Domains.Item;

/// <summary>
/// 蛊的成长类型
/// </summary>
public static class WugGrowthType
{
	/// <summary>
	/// 无效值
	/// </summary>
	public const sbyte Invalid = -1;

	/// <summary>
	/// 有益若蛊 - 战斗中
	/// </summary>
	public const sbyte GrowingGood1 = 0;

	/// <summary>
	/// 有益若蛊 - 战斗外
	/// </summary>
	public const sbyte GrowingGood2 = 1;

	/// <summary>
	/// 有害若蛊 - 战斗中
	/// </summary>
	public const sbyte GrowingBad1 = 2;

	/// <summary>
	/// 有害若蛊 - 战斗外
	/// </summary>
	public const sbyte GrowingBad2 = 3;

	/// <summary>
	/// 成蛊
	/// </summary>
	public const sbyte Grown = 4;

	/// <summary>
	/// 王蛊
	/// </summary>
	public const sbyte King = 5;

	/// <summary>
	/// 蛊的成长类型的个数
	/// </summary>
	public const int Count = 6;

	/// <summary>
	/// 指定成长类型是否为只在战斗中生效的类型
	/// </summary>
	/// <param name="wugGrowthType"></param>
	/// <returns></returns>
	public static bool IsWugGrowthTypeCombatOnly(sbyte wugGrowthType)
	{
		if (wugGrowthType == 0 || wugGrowthType == 2)
		{
			return true;
		}
		return false;
	}

	/// <summary>
	/// 指定成长类型能否变为成蛊
	/// </summary>
	/// <param name="wugGrowthType"></param>
	/// <returns></returns>
	public static bool CanChangeToGrown(sbyte wugGrowthType)
	{
		if (wugGrowthType == 1 || wugGrowthType == 3)
		{
			return true;
		}
		return false;
	}

	/// <summary>
	/// 指定成长类型是否为增益类型
	/// </summary>
	/// <param name="wugGrowthType"></param>
	/// <returns></returns>
	public static bool IsGood(sbyte wugGrowthType)
	{
		if ((uint)wugGrowthType <= 1u)
		{
			return true;
		}
		return false;
	}

	/// <summary>
	/// 指定成长类型是否为损害类型
	/// </summary>
	/// <param name="wugGrowthType"></param>
	/// <returns></returns>
	public static bool IsBad(sbyte wugGrowthType)
	{
		return !IsGood(wugGrowthType);
	}
}
