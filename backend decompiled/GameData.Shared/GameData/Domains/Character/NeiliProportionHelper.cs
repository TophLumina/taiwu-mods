using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.Character;

/// <summary>
/// 五行比例相关辅助方法
/// </summary>
public static class NeiliProportionHelper
{
	/// <summary>
	/// 获取五行对应的内力类型
	/// </summary>
	/// <param name="proportionOfFiveElements"></param>
	/// <param name="birthMonth"></param>
	/// <returns></returns>
	public static sbyte GetNeiliType(this NeiliProportionOfFiveElements proportionOfFiveElements, sbyte birthMonth)
	{
		SpanList<(sbyte, sbyte)> sortedElements = stackalloc(sbyte, sbyte)[5];
		for (sbyte i = 0; i < 5; i++)
		{
			sbyte proportion = proportionOfFiveElements[i];
			for (sbyte j = 0; j < 5; j++)
			{
				if (j == sortedElements.Count)
				{
					sortedElements.Add((proportion, i));
					break;
				}
				if (sortedElements[j].Item1 < proportion)
				{
					sortedElements.Insert(j, (proportion, i));
					break;
				}
			}
		}
		if (sortedElements[0].Item1 <= 22 && sortedElements[4].Item1 >= 18)
		{
			return 5;
		}
		sbyte maxElementId = sortedElements[0].Item2;
		sbyte maxElementProportion = sortedElements[0].Item1;
		sbyte secElementProportion = sortedElements[1].Item1;
		int sameCount = 0;
		sbyte i2 = 1;
		while (i2 < 5 && sortedElements[i2].Item1 == sortedElements[0].Item1)
		{
			sameCount++;
			i2++;
		}
		if (sameCount > 0)
		{
			sbyte birthElementId = SharedMethods.GetInnateFiveElementsType(birthMonth);
			sbyte counteringId = FiveElementsType.Countering[birthElementId];
			sbyte counteredId = FiveElementsType.Countered[birthElementId];
			sbyte producingId = FiveElementsType.Producing[birthElementId];
			sbyte producedId = FiveElementsType.Produced[birthElementId];
			sbyte birthValue = proportionOfFiveElements[birthElementId];
			sbyte counteringValue = proportionOfFiveElements[counteringId];
			sbyte counteredValue = proportionOfFiveElements[counteredId];
			sbyte producingValue = proportionOfFiveElements[producingId];
			sbyte producedValue = proportionOfFiveElements[producedId];
			if (maxElementProportion == birthValue)
			{
				maxElementId = birthElementId;
			}
			else if (maxElementProportion == counteredValue)
			{
				maxElementId = counteredId;
			}
			else if (maxElementProportion == counteringValue)
			{
				maxElementId = counteringId;
			}
			else if (maxElementProportion == producedValue)
			{
				maxElementId = producedId;
			}
			else if (maxElementProportion == producingValue)
			{
				maxElementId = producingId;
			}
		}
		sbyte counteringId2 = FiveElementsType.Countering[maxElementId];
		sbyte counteredId2 = FiveElementsType.Countered[maxElementId];
		sbyte producingId2 = FiveElementsType.Producing[maxElementId];
		sbyte producedId2 = FiveElementsType.Produced[maxElementId];
		sbyte counteringValue2 = proportionOfFiveElements[counteringId2];
		sbyte counteredValue2 = proportionOfFiveElements[counteredId2];
		sbyte producingValue2 = proportionOfFiveElements[producingId2];
		sbyte producedValue2 = proportionOfFiveElements[producedId2];
		int maxElementValueThresholdLow = maxElementProportion * 40 / 100;
		int maxElementValueThresholdHigh = maxElementProportion * 80 / 100;
		if (secElementProportion < maxElementValueThresholdLow)
		{
			return maxElementId;
		}
		if (counteredValue2 == secElementProportion)
		{
			return (sbyte)(6 + counteredId2 * 6 + ((counteredValue2 >= maxElementValueThresholdHigh) ? 3 : 2));
		}
		if (counteringValue2 == secElementProportion)
		{
			return (sbyte)(6 + maxElementId * 6 + ((counteringValue2 >= maxElementValueThresholdHigh) ? 2 : 3));
		}
		if (producedValue2 == secElementProportion)
		{
			return (sbyte)(6 + maxElementId * 6 + ((producedValue2 >= maxElementValueThresholdHigh) ? 4 : 5));
		}
		if (producingValue2 == secElementProportion)
		{
			return (sbyte)(6 + maxElementId * 6 + ((producingValue2 < maxElementValueThresholdHigh) ? 1 : 0));
		}
		return maxElementId;
	}
}
