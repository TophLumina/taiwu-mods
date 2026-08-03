using System;

namespace GameData.Domains.Combat;

public struct CValueDistanceDelta
{
	private int _distanceDelta;

	public bool IsForward => _distanceDelta < 0;

	public bool IsBackward => _distanceDelta > 0;

	public static implicit operator CValueDistanceDelta(int percentValue)
	{
		return new CValueDistanceDelta
		{
			_distanceDelta = percentValue
		};
	}

	public static explicit operator int(CValueDistanceDelta percent)
	{
		return percent._distanceDelta;
	}

	public static short operator +(short distance, CValueDistanceDelta delta)
	{
		return (short)Math.Clamp(distance + delta._distanceDelta, 20, 120);
	}
}
