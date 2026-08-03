using System;

namespace Config;

/// <summary>
/// 生成新人物的资质权重和的分布
/// </summary>
[Serializable]
public class WeightsSumDistribution
{
	/// <summary>
	/// 最小权重
	/// </summary>
	public int Min;

	/// <summary>
	/// 各权重的抽取权重
	/// </summary>
	public int[] Weights;

	/// <summary>
	/// 构造数据列表
	/// </summary>
	public WeightsSumDistribution(int min, params int[] weights)
	{
		Min = min;
		Weights = weights;
	}
}
