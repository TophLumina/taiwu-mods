namespace GameData.Combat.Math;

public class CValueResource
{
	public int Max { get; private set; }

	public int Current { get; private set; }

	public CValuePercent Percent => CValuePercent.Parse(Current, Max);

	public int PercentInt => CValuePercent.ParseInt(Current, Max);

	public static CValueResource Create(int max, int current)
	{
		max = CombatMath.Max(max, 0);
		current = CombatMath.Clamp(current, 0, max);
		return new CValueResource
		{
			Max = max,
			Current = current
		};
	}

	public static CValueResource Create(int max)
	{
		max = CombatMath.Max(max, 0);
		return new CValueResource
		{
			Max = max,
			Current = 0
		};
	}

	public static CValueResource CreateMax(int max)
	{
		max = CombatMath.Max(max, 0);
		return new CValueResource
		{
			Max = max,
			Current = max
		};
	}

	public void Change(int delta)
	{
		Current = CombatMath.Clamp(Current + delta, 0, Max);
	}

	public void Change(CValuePercent delta)
	{
		Change(Max * delta);
	}

	public void ChangeTo(CValuePercent percent)
	{
		Current = CombatMath.Clamp(Current + Max * percent, 0, Max);
	}

	public void Restore()
	{
		Current = Max;
	}

	public void Clear()
	{
		Current = 0;
	}
}
