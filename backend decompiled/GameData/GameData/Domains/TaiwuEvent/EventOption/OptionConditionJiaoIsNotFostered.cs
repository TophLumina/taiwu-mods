using System;
using Config;

namespace GameData.Domains.TaiwuEvent.EventOption;

public class OptionConditionJiaoIsNotFostered : TaiwuEventOptionConditionBase
{
	private readonly Func<int, bool> _conditionMatcher;

	public OptionConditionJiaoIsNotFostered(short id, Func<int, bool> conditionMatcher)
		: base(id)
	{
		_conditionMatcher = conditionMatcher;
	}

	public override bool CheckCondition(EventArgBox box)
	{
		return _conditionMatcher(box.GetInt(EventTriggerParameter.DefValue.PoolId));
	}

	public override (short, string[]) GetDisplayData(EventArgBox box)
	{
		return (Id, Array.Empty<string>());
	}
}
