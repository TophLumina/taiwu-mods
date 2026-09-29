using System;

namespace Config.ConfigCells;

[Serializable]
public class AutoTriggerMonthlyEvent
{
	public short MonthlyEventId;

	public string[] Args;

	public AutoTriggerMonthlyEvent(short monthlyEventId)
	{
		MonthlyEventId = monthlyEventId;
	}

	public AutoTriggerMonthlyEvent(short monthlyEventId, params string[] args)
	{
		MonthlyEventId = monthlyEventId;
		Args = args;
	}
}
