using System;
using System.Collections.Generic;

namespace GameData.Domains.TaiwuEvent.EventOption;

public abstract class TaiwuEventOptionConditionBase
{
	public readonly short Id;

	public List<TaiwuEventOptionConditionBase> OrConditionCore;

	public TaiwuEventOptionConditionBase(short id)
	{
		Id = id;
	}

	public virtual bool CheckCondition(EventArgBox box)
	{
		return false;
	}

	public virtual (short, string[]) GetDisplayData(EventArgBox box)
	{
		throw new NotImplementedException();
	}

	public virtual List<int> GetCharIdList(EventArgBox box)
	{
		return null;
	}
}
