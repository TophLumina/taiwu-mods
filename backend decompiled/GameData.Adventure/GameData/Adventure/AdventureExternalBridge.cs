namespace GameData.Adventure;

public static class AdventureExternalBridge
{
	private static IAdventureExternalBridge _bridge;

	public static void Initialize(IAdventureExternalBridge bridge)
	{
		_bridge = bridge;
	}

	public static string Tr(this AdventureLocalStringRef @ref)
	{
		return _bridge?.Tr(@ref) ?? @ref?.Key ?? string.Empty;
	}

	public static string TrFormat(AdventureLocalStringRef @ref, params object[] args)
	{
		return string.Format(@ref.Tr(), args);
	}

	public static T LogException<T>(string message, T returnValue)
	{
		_bridge?.LogException("Access error at " + message);
		return returnValue;
	}
}
