using System;

namespace GameData.Combat.Math.Exceptions;

public class CombatMathException : Exception
{
	public CombatMathException(string message)
		: base(message)
	{
	}
}
