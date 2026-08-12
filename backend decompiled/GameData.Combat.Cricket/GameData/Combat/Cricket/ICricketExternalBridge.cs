namespace GameData.Combat.Cricket;

public interface ICricketExternalBridge
{
	bool CheckPercentProb(int percentProb);

	int Next(int maxValue);
}
