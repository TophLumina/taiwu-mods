using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.MemoryNotEqualString)]
public class AiConditionMemoryNotEqualString : AiConditionCommonBase
{
	private readonly string _key;

	private readonly string _value;

	public AiConditionMemoryNotEqualString(IReadOnlyList<string> strings)
	{
		_key = strings[0];
		_value = strings[1];
	}

	public override bool Check(AiMemoryNew memory, IAiParticipant participant)
	{
		string value;
		return !memory.Strings.TryGetValue(_key, out value) || value != _value;
	}
}
