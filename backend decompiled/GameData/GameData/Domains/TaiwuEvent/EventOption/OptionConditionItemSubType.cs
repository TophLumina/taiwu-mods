using System;

namespace GameData.Domains.TaiwuEvent.EventOption;

public class OptionConditionItemSubType : TaiwuEventOptionConditionBase
{
	public readonly int Arg;

	public readonly Func<int, bool> ConditionChecker;

	public OptionConditionItemSubType(short id, int arg, Func<int, bool> checkFunc)
		: base(id)
	{
		Arg = arg;
		ConditionChecker = checkFunc;
	}

	public override bool CheckCondition(EventArgBox box)
	{
		return ConditionChecker(Arg);
	}

	public override (short, string[]) GetDisplayData(EventArgBox box)
	{
		return (Id, new string[1] { $"<Language Key=LK_ItemSubType_{Arg}/>" });
	}
}
