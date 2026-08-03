using System;
using System.Collections.Generic;
using Config;

namespace GameData.Domains.TaiwuEvent;

/// <summary>
/// 运行时设置. 包含一些全局的Debug信息
/// </summary>
[Serializable]
public class EventScriptRuntimeSettings
{
	/// <summary>
	/// 是否输出指定类型的脚本, 索引为 <see cref="T:Config.EventScriptType.DefKey" />
	/// </summary>
	public bool[] LogScriptTypes = new bool[EventScriptType.Instance.Count];

	/// <summary>
	/// 只输出被监听的事件脚本的调用
	/// </summary>
	public bool LogMonitoredScriptsOnly;

	/// <summary>
	/// 监听的脚本
	/// </summary>
	public HashSet<EventScriptId> MonitoredScripts = new HashSet<EventScriptId>();

	/// <summary>
	/// 保存的文件名
	/// </summary>
	public const string FileName = "EventScriptRuntimeSettings.json";
}
