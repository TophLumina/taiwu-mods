using System;
using System.Runtime.CompilerServices;
using NLog;

namespace GameData.Utilities;

public static class Tester
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Assert(bool condition, string message = "")
	{
		if (!condition)
		{
			throw new Exception("Assertion failure. " + message);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void AppendWarning(this Logger logger, string message)
	{
		logger.Warn(message);
		LogHandle.AppendMessage("Backend Warning(" + logger.Name + "): " + message);
	}
}
