using System;
using System.Collections.Generic;
using Config;

namespace GameData.Domains.TaiwuEvent;

[Serializable]
public class EventScriptRuntimeSettings
{
	public bool[] LogScriptTypes = new bool[EventScriptType.Instance.Count];

	public bool LogMonitoredScriptsOnly;

	public HashSet<EventScriptId> MonitoredScripts = new HashSet<EventScriptId>();

	public const string FileName = "EventScriptRuntimeSettings.json";
}
