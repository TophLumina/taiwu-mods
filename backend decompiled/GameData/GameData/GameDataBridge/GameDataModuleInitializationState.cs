namespace GameData.GameDataBridge;

public static class GameDataModuleInitializationState
{
	public const sbyte Uninitialized = 0;

	public const sbyte ShouldInitialize = 1;

	public const sbyte ShouldSendInitializedMessage = 2;

	public const sbyte SentInitializedMessage = 3;

	public static bool CheckTransition(sbyte prevState, sbyte nextState)
	{
		if (nextState == 1)
		{
			return (prevState == 0 || prevState == 3) ? true : false;
		}
		return nextState == prevState + 1;
	}
}
