using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using NLog;

namespace GameData.Utilities;

public static class AdaptableLog
{
	private static Action<string> _onInfo;

	private static Action<string> _onWarn;

	private static Action<string> _onError;

	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	public static void Initialize(Action<string> infoAction, Action<string> warnAction, Action<string> errorAction)
	{
		_onInfo = infoAction;
		_onWarn = warnAction;
		_onError = errorAction;
		Info("AdaptableLog initialized.");
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Info(string message)
	{
		_onInfo?.Invoke(message);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Warning(string message, bool appendWarningMessage = false)
	{
		_onWarn?.Invoke(message);
		if (appendWarningMessage)
		{
			LogHandle.AppendMessage("Backend Warning(" + Logger.Name + "): " + message);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Error(string message)
	{
		_onError?.Invoke(message);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Conditional("CONCHSHIP_DEV")]
	public static void InfoDevOnly(string message)
	{
		Info(message);
	}

	public static void TagInfo(string tag, string message)
	{
		Info("[" + tag + "]: " + message);
	}

	public static void TagWarning(string tag, string message, bool appendWarningMessage = false)
	{
		Warning("[" + tag + "]: " + message, appendWarningMessage);
	}

	public static void TagError(string tag, string message)
	{
		Error("[" + tag + "]: " + message);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Conditional("CONCHSHIP_DEV")]
	public static void TagInfoDevOnly(string tag, string message)
	{
		TagInfo(tag, message);
	}
}
