using System;

namespace Config;

[Serializable]
public class WeightsSumDistribution
{
	public int Min;

	public int[] Weights;

	public WeightsSumDistribution(int min, params int[] weights)
	{
		Min = min;
		Weights = weights;
	}
}
