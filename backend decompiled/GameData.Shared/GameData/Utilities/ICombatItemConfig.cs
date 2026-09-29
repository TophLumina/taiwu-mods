namespace GameData.Utilities;

public interface ICombatItemConfig
{
	int ConsumedFeatureMedals { get; }

	int UseFrame { get; }

	bool AllowUseInPlayAndTest => false;
}
