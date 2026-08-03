using GameData.Combat.Math;

namespace GameData.Domains.Item;

/// <summary>
/// 物品相关公式类
/// </summary>
public static class ItemFormula
{
	/// <summary>
	/// 计算耐久衰减效果的公式
	/// </summary>
	/// <param name="currDurability">当前耐久值</param>
	/// <param name="maxDurability">耐久值上限</param>
	/// <returns>衰减效果，直接乘以原始值</returns>
	public static CValuePercent FormulaCalcDurabilityEffect(int currDurability, int maxDurability)
	{
		if (maxDurability <= 0)
		{
			return 100;
		}
		return 25 + currDurability * 75 / maxDurability;
	}
}
