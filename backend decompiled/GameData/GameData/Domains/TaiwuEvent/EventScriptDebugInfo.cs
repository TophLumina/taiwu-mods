using System;
using System.Collections.Generic;

namespace GameData.Domains.TaiwuEvent;

public class EventScriptDebugInfo
{
	public bool PauseOnStart;

	public Dictionary<int, Func<bool>> BreakPoints;
}
