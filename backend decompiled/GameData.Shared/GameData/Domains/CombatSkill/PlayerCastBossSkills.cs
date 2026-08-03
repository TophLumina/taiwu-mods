using System.Collections.Generic;
using Config;
using GameData.Utilities;

namespace GameData.Domains.CombatSkill;

/// <summary>
/// 玩家可施展的 boss 功法
/// </summary>
public static class PlayerCastBossSkills
{
	/// <summary>
	/// 玩家可施展的 boss 功法 ID 列表
	/// </summary>
	public static readonly List<short> Ids = new List<short>();

	/// <summary>
	/// 初始化缓存
	/// </summary>
	public static void Initialize()
	{
		Ids.Clear();
		foreach (BossItem config in (IEnumerable<BossItem>)Boss.Instance)
		{
			List<short> playerCastSkills = config.PlayerCastSkills;
			if (playerCastSkills != null && playerCastSkills.Count > 0)
			{
				Ids.AddUniqueRange(config.PlayerCastSkills);
			}
		}
	}
}
