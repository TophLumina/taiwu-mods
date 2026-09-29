namespace GameData.Domains.Taiwu.Display;

public static class OperationLevelImpl
{
	public static bool Visible(this OperationLevel operationLevel)
	{
		return operationLevel > OperationLevel.None;
	}

	public static bool Available(this OperationLevel operationLevel)
	{
		return operationLevel > OperationLevel.None;
	}

	public static void CalcValue(this ref OperationLevel operationLevel, bool visible, bool available = true)
	{
		operationLevel = CalcValue(visible, available);
	}

	public static OperationLevel CalcValue(bool visible, bool available = true)
	{
		if (!visible)
		{
			return OperationLevel.None;
		}
		if (!available)
		{
			return OperationLevel.Visible;
		}
		return OperationLevel.Available;
	}
}
