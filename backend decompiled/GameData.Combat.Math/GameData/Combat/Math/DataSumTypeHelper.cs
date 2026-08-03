namespace GameData.Combat.Math;

public static class DataSumTypeHelper
{
	public static int Sum(this EDataSumType sumType, int addValue)
	{
		if (addValue == 0)
		{
			return 0;
		}
		switch (sumType)
		{
		case EDataSumType.All:
			return addValue;
		case EDataSumType.OnlyAdd:
			if (addValue > 0)
			{
				return addValue;
			}
			break;
		case EDataSumType.OnlyReduce:
			if (addValue < 0)
			{
				return addValue;
			}
			break;
		case EDataSumType.None:
			return 0;
		}
		return 0;
	}

	public static int Sum(this EDataSumType sumType, int value, int addValue)
	{
		return value + sumType.Sum(addValue);
	}

	public static EDataSumType CalcSumType(bool canAdd, bool canReduce)
	{
		if (canAdd == canReduce)
		{
			if (!canAdd)
			{
				return EDataSumType.None;
			}
			return EDataSumType.All;
		}
		if (!canAdd)
		{
			return EDataSumType.OnlyReduce;
		}
		return EDataSumType.OnlyAdd;
	}

	public static bool ContainsAdd(this EDataSumType sumType)
	{
		if ((uint)sumType <= 1u)
		{
			return true;
		}
		return false;
	}

	public static bool ContainsReduce(this EDataSumType sumType)
	{
		if (sumType == EDataSumType.All || sumType == EDataSumType.OnlyReduce)
		{
			return true;
		}
		return false;
	}
}
