using GameData.Domains.Item;

namespace GameData.Utilities;

/// <summary>
/// 战斗中可用道具拓展方法，仅用于对多处使用的重复逻辑进行合并
/// </summary>
public static class CombatItemExtensions
{
	/// <summary>
	/// 获取机略消耗，兼容空值
	/// </summary>
	public static int GetConsumedFeatureMedals(this ItemKey itemKey)
	{
		return itemKey.GetConfigAs<ICombatItemConfig>()?.ConsumedFeatureMedals ?? (-1);
	}
}
