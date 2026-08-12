using GameData.Combat.Cricket;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Item;

public class CricketBridgeImplement : ICricketExternalBridge
{
	private readonly IRandomSource _random;

	public CricketBridgeImplement()
	{
		_random = RandomDefaults.CreateRandomSource();
	}

	public bool CheckPercentProb(int percentProb)
	{
		return _random.CheckPercentProb(percentProb);
	}

	public int Next(int maxValue)
	{
		return _random.Next(maxValue);
	}
}
