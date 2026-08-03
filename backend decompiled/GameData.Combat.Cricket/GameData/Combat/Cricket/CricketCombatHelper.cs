using System;

namespace GameData.Combat.Cricket;

public static class CricketCombatHelper
{
	public static string FormatReduce(int value)
	{
		return ((value > 0) ? '-' : '+').ToString() + System.Math.Abs(value);
	}
}
