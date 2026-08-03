using System.Collections.Generic;
using GameData.Utilities;

namespace GameData.Domains.Combat;

/// <summary>
/// 战中疗伤驱毒禁用原因辅助工具集
/// </summary>
public static class CombatHealBanReasonHelper
{
	/// <summary>
	/// 转换
	/// </summary>
	public static IEnumerable<ECombatHealBanReason> ParseReasons(BoolArray32 array)
	{
		if (array[0])
		{
			yield return ECombatHealBanReason.NonTarget;
		}
		if (array[1])
		{
			yield return ECombatHealBanReason.CountLack;
		}
		if (array[2])
		{
			yield return ECombatHealBanReason.HerbLack;
		}
		if (array[3])
		{
			yield return ECombatHealBanReason.AttainmentLack;
		}
	}
}
