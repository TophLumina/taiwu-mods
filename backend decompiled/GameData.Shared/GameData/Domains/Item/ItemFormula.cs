using GameData.Combat.Math;

namespace GameData.Domains.Item;

public static class ItemFormula
{
	public static CValuePercent FormulaCalcDurabilityEffect(int currDurability, int maxDurability)
	{
		if (maxDurability <= 0)
		{
			return 100;
		}
		return 25 + currDurability * 75 / maxDurability;
	}
}
