using System;
using System.Collections.Generic;
using System.Linq;
using Config;

namespace GameData.Domains.Combat.Ai.Condition;

public abstract class AiConditionCheckCharStatePowerSumMoreOrEqualBase : AiConditionCheckCharBase
{
	protected readonly string CombatStateName;

	protected readonly int TargetPower;

	protected abstract sbyte StateType { get; }

	protected bool IsNameMatch(short stateId)
	{
		return CombatState.Instance[stateId].Name == CombatStateName;
	}

	protected AiConditionCheckCharStatePowerSumMoreOrEqualBase(IReadOnlyList<string> strings, IReadOnlyList<int> ints)
		: base(ints)
	{
		CombatStateName = strings[0];
		TargetPower = ints[1];
	}

	protected override bool Check(CombatCharacter checkChar)
	{
		CombatStateCollection stateCollection = checkChar.GetCombatStateCollection(StateType);
		if (stateCollection?.StateDict == null)
		{
			return false;
		}
		return stateCollection.StateDict.Where((KeyValuePair<short, (short power, bool reverse, int srcCharId)> x) => IsNameMatch(x.Key)).Select<KeyValuePair<short, (short, bool, int)>, int>((Func<KeyValuePair<short, (short, bool, int)>, int>)((KeyValuePair<short, (short power, bool reverse, int srcCharId)> x) => x.Value.power)).Sum() >= TargetPower;
	}
}
