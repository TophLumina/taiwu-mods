using NLog;
using NLog.Targets;

namespace GameData.GameDataBridge;

[Target("ErrorMessages")]
public class ErrorMessagesTarget : TargetWithLayout
{
	public ErrorMessagesTarget(string name)
	{
		base.Name = name;
		base.OptimizeBufferReuse = true;
	}

	protected override void Write(LogEventInfo logEvent)
	{
		string logMessage = Layout.Render(logEvent);
		GameDataBridge.AppendErrorMessage(logMessage);
	}
}
