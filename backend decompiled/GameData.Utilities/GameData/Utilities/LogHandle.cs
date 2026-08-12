using System;

namespace GameData.Utilities;

public class LogHandle
{
	public static event Action<string> OnAppendMessage;

	internal static void AppendMessage(string message)
	{
		LogHandle.OnAppendMessage?.Invoke(message);
	}
}
