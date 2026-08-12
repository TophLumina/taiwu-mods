using System.Diagnostics;

namespace GameData.Utilities;

public static class DebugLogger
{
	[Conditional("DEBUG")]
	public static void DebugBreak()
	{
		if (Debugger.Launch())
		{
			Debugger.Break();
		}
	}
}
