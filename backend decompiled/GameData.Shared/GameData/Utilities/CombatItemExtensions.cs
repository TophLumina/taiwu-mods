using GameData.Domains.Item;

namespace GameData.Utilities;

public static class CombatItemExtensions
{
	public static int GetConsumedFeatureMedals(this ItemKey itemKey)
	{
		return itemKey.GetConfigAs<ICombatItemConfig>()?.ConsumedFeatureMedals ?? (-1);
	}
}
