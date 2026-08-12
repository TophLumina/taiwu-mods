namespace GameData.Combat.Cricket;

public static class CricketExternalBridge
{
	private static ICricketExternalBridge _externalBridge;

	internal static ICricketExternalBridge Bridge => _externalBridge ?? CricketSimpleBridge.Instance;

	public static void Initialize(ICricketExternalBridge bridge)
	{
		_externalBridge = bridge;
	}
}
