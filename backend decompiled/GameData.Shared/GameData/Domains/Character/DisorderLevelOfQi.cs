using Config;

namespace GameData.Domains.Character;

/// <summary>
/// 内息紊乱阶段
/// </summary>
public static class DisorderLevelOfQi
{
	/// <summary>
	/// 顺畅
	/// </summary>
	public const sbyte Smooth = 0;

	/// <summary>
	/// 滞碍
	/// </summary>
	public const sbyte Sluggish = 1;

	/// <summary>
	/// 逆阻
	/// </summary>
	public const sbyte Blocked = 2;

	/// <summary>
	/// 紊乱
	/// </summary>
	public const sbyte Disordered = 3;

	/// <summary>
	/// 绝断
	/// </summary>
	public const sbyte Cutoff = 4;

	/// <summary>
	/// 内息紊乱阶段的个数
	/// </summary>
	public const int Count = 5;

	/// <summary>
	/// 最小值
	/// </summary>
	public static short MinValue => QiDisorderEffect.DefValue.Smooth.ThresholdMin;

	/// <summary>
	/// 最大值
	/// </summary>
	public static short MaxValue => QiDisorderEffect.DefValue.Cutoff.ThresholdMax;

	/// <summary>
	/// 获取前端显示值
	/// </summary>
	/// <param name="disorderOfQi"></param>
	/// <returns></returns>
	public static short GetShowValue(short disorderOfQi)
	{
		return (short)(disorderOfQi / 10);
	}

	/// <summary>
	/// 计算内息紊乱阶段.
	/// 取值范围 [0, 4].
	/// </summary>
	/// <param name="disorderOfQi"></param>
	/// <returns></returns>
	public static sbyte GetDisorderLevelOfQi(short disorderOfQi)
	{
		sbyte id;
		for (id = 0; id < 4; id++)
		{
			if (QiDisorderEffect.Instance[id].ThresholdMax > disorderOfQi)
			{
				return id;
			}
		}
		return id;
	}

	/// <summary>
	/// 计算内息紊乱阶段.
	/// 直接返回对应阶段的Config
	/// </summary>
	/// <param name="disorderOfQi"></param>
	/// <returns></returns>
	public static QiDisorderEffectItem GetDisorderLevelOfQiConfig(short disorderOfQi)
	{
		QiDisorderEffectItem ret = null;
		for (int id = 0; id < 4; id++)
		{
			if ((ret = QiDisorderEffect.Instance[id]).ThresholdMax > disorderOfQi)
			{
				return ret;
			}
		}
		return QiDisorderEffect.DefValue.Cutoff;
	}
}
