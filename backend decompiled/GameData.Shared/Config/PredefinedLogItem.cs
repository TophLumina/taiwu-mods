using System;
using Config.Common;
using GameData;
using GameData.Utilities;

namespace Config;

/// <summary>
/// 预定义调试输出的扩展方法.
/// </summary>
[Serializable]
public class PredefinedLogItem : ConfigItem<PredefinedLogItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 信息
	/// </summary>
	public readonly string Info;

	/// <summary>
	/// 仅开发推送
	/// - 设置该项后，仅开发模式和测试分支会将异常信息推送到前台.
	/// </summary>
	public readonly bool DebugOnly;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="info">信息</param>
	/// <param name="debugOnly">仅开发推送 - 设置该项后，仅开发模式和测试分支会将异常信息推送到前台.</param>
	public PredefinedLogItem(short templateId, string name, string info, bool debugOnly)
	{
		TemplateId = templateId;
		Name = name;
		Info = info;
		DebugOnly = debugOnly;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public PredefinedLogItem()
	{
		TemplateId = 0;
		Name = null;
		Info = null;
		DebugOnly = false;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public PredefinedLogItem(short templateId, PredefinedLogItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Info = other.Info;
		DebugOnly = other.DebugOnly;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override PredefinedLogItem Duplicate(int templateId)
	{
		return new PredefinedLogItem((short)templateId, this);
	}

	/// <summary>
	/// 打印预设黄字Log信息
	/// </summary>
	public void Log()
	{
		AdaptableLog.Warning("[" + Name + "]: " + Info, !DebugOnly || ExternalDataBridge.Context.DevOnlyPredefinedLog);
	}

	/// <summary>
	/// 打印预设黄字Log信息
	/// </summary>
	public void Log(object arg0)
	{
		AdaptableLog.Warning("[" + Name + "]: " + Info.GetFormat(arg0), !DebugOnly || ExternalDataBridge.Context.DevOnlyPredefinedLog);
	}

	/// <summary>
	/// 打印预设黄字Log信息
	/// </summary>
	public void Log(object arg0, object arg1)
	{
		AdaptableLog.Warning("[" + Name + "]: " + Info.GetFormat(arg0, arg1), !DebugOnly || ExternalDataBridge.Context.DevOnlyPredefinedLog);
	}

	/// <summary>
	/// 打印预设黄字Log信息
	/// </summary>
	public void Log(object arg0, object arg1, object arg2)
	{
		AdaptableLog.Warning("[" + Name + "]: " + Info.GetFormat(arg0, arg1, arg2), !DebugOnly || ExternalDataBridge.Context.DevOnlyPredefinedLog);
	}

	/// <summary>
	/// 打印预设黄字Log信息
	/// </summary>
	public void Log(params object[] parameters)
	{
		AdaptableLog.Warning("[" + Name + "]: " + Info.GetFormat(parameters), !DebugOnly || ExternalDataBridge.Context.DevOnlyPredefinedLog);
	}
}
