using System.Collections.Generic;
using Config;
using GameData.Utilities;

namespace GameData.Domains.CombatSkill;

public static class PlayerCastBossSkills
{
	public static readonly List<short> Ids = new List<short>();

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
