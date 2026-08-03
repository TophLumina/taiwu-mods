namespace GameData.Combat.Cricket;

internal class CricketSimpleBridge : ICricketExternalBridge
{
	private static ICricketExternalBridge _instance;

	private int _nextCounter;

	public static ICricketExternalBridge Instance => _instance ?? (_instance = new CricketSimpleBridge());

	public bool CheckPercentProb(int percentProb)
	{
		return percentProb > 0;
	}

	public int Next(int maxValue)
	{
		return _nextCounter++ % maxValue;
	}
}
