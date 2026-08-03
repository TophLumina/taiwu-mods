using GameData.Common;

namespace GameData.Domains.SpecialEffect;

public interface IFrameCounterHandler
{
	int CharacterId { get; }

	bool IsOn(int counterType)
	{
		return true;
	}

	void OnProcess(DataContext context, int counterType);
}
