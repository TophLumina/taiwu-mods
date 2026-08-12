using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.MemoryNotEqualBoolean)]
public class AiConditionMemoryNotEqualBoolean : AiConditionCommonBase
{
	private readonly string _key;

	private readonly bool _value;

	public AiConditionMemoryNotEqualBoolean(IReadOnlyList<string> strings, IReadOnlyList<int> ints)
	{
		_key = strings[0];
		_value = ints[0] == 1;
	}

	public override bool Check(AiMemoryNew memory, IAiParticipant participant)
	{
		bool value;
		return !memory.Booleans.TryGetValue(_key, out value) || value != _value;
	}
}
