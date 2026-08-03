using System.Collections.Generic;

namespace GameData.Domains.Item;

public static class CricketCombatPlanExtensions
{
	public static bool ReplaceCricket(this List<CricketCombatPlan> plans, int srcCricketId, ItemKey dstCricket)
	{
		if (plans == null || plans.Count <= 0)
		{
			return false;
		}
		bool anyChanged = false;
		foreach (CricketCombatPlan plan in plans)
		{
			anyChanged = plan.ReplaceCricket(srcCricketId, dstCricket) || anyChanged;
		}
		return anyChanged;
	}

	public static bool ReplaceCricket(this CricketCombatPlan plan, int srcCricketId, ItemKey dstCricket)
	{
		List<ItemKey> list = plan?.Crickets;
		if (list == null || list.Count <= 0)
		{
			return false;
		}
		bool anyChanged = false;
		for (int i = 0; i < plan.Crickets.Count; i++)
		{
			if (plan.Crickets[i].Id == srcCricketId)
			{
				plan.Crickets[i] = dstCricket;
				anyChanged = true;
			}
		}
		return anyChanged;
	}
}
