using System.Collections.Generic;
using GameData.Utilities;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.MemoryInternalBelow)]
public class AiConditionMemoryInternalBelow : AiConditionCommonBase
{
	private readonly string _keyL;

	private readonly string _keyR;

	public AiConditionMemoryInternalBelow(IReadOnlyList<string> strings)
	{
		_keyL = strings[0];
		_keyR = strings[1];
	}

	public override bool Check(AiMemoryNew memory, IAiParticipant participant)
	{
		return memory.Ints.GetOrDefault(_keyL) < memory.Ints.GetOrDefault(_keyR);
	}
}
