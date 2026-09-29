using System;
using Config.Common;
using GameData;
using GameData.Utilities;

namespace Config;

[Serializable]
public class PredefinedLogItem : ConfigItem<PredefinedLogItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string Info;

	public readonly bool DebugOnly;

	public PredefinedLogItem(short templateId, string name, string info, bool debugOnly)
	{
		TemplateId = templateId;
		Name = name;
		Info = info;
		DebugOnly = debugOnly;
	}

	public PredefinedLogItem()
	{
		TemplateId = 0;
		Name = null;
		Info = null;
		DebugOnly = false;
	}

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

	public override PredefinedLogItem Duplicate(int templateId)
	{
		return new PredefinedLogItem((short)templateId, this);
	}

	public void Log()
	{
		AdaptableLog.Warning("[" + Name + "]: " + Info, !DebugOnly || ExternalDataBridge.Context.DevOnlyPredefinedLog);
	}

	public void Log(object arg0)
	{
		AdaptableLog.Warning("[" + Name + "]: " + Info.GetFormat(arg0), !DebugOnly || ExternalDataBridge.Context.DevOnlyPredefinedLog);
	}

	public void Log(object arg0, object arg1)
	{
		AdaptableLog.Warning("[" + Name + "]: " + Info.GetFormat(arg0, arg1), !DebugOnly || ExternalDataBridge.Context.DevOnlyPredefinedLog);
	}

	public void Log(object arg0, object arg1, object arg2)
	{
		AdaptableLog.Warning("[" + Name + "]: " + Info.GetFormat(arg0, arg1, arg2), !DebugOnly || ExternalDataBridge.Context.DevOnlyPredefinedLog);
	}

	public void Log(params object[] parameters)
	{
		AdaptableLog.Warning("[" + Name + "]: " + Info.GetFormat(parameters), !DebugOnly || ExternalDataBridge.Context.DevOnlyPredefinedLog);
	}
}
