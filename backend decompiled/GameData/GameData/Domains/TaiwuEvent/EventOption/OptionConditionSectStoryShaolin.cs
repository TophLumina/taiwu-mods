using System;

namespace GameData.Domains.TaiwuEvent.EventOption;

public class OptionConditionSectStoryShaolin : TaiwuEventOptionConditionBase
{
	private Func<bool> _conditionMatcher;

	public OptionConditionSectStoryShaolin(short id, Func<bool> conditionMatcher)
		: base(id)
	{
		_conditionMatcher = conditionMatcher;
	}

	public override bool CheckCondition(EventArgBox box)
	{
		return _conditionMatcher();
	}

	public override (short, string[]) GetDisplayData(EventArgBox box)
	{
		return (Id, Array.Empty<string>());
	}
}
