using Config;

namespace GameData.Domains.Character;

public static class DisorderLevelOfQi
{
	public const sbyte Smooth = 0;

	public const sbyte Sluggish = 1;

	public const sbyte Blocked = 2;

	public const sbyte Disordered = 3;

	public const sbyte Cutoff = 4;

	public const int Count = 5;

	public static short MinValue => QiDisorderEffect.DefValue.Smooth.ThresholdMin;

	public static short MaxValue => QiDisorderEffect.DefValue.Cutoff.ThresholdMax;

	public static short GetShowValue(short disorderOfQi)
	{
		return (short)(disorderOfQi / 10);
	}

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
