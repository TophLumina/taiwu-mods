using System;

namespace GameData.Domains.TaiwuEvent.MonthlyEventActions;

public struct PreparationRule
{
	[Obsolete]
	public sbyte StartMonth;

	public short PreparationDuration;

	public bool CanStartEarly;

	public short Interval;
}
