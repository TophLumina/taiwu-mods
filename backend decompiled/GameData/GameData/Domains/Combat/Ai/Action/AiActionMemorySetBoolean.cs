using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.MemorySetBoolean)]
public class AiActionMemorySetBoolean : AiActionCommonBase
{
	private readonly string _key;

	private readonly bool _value;

	public AiActionMemorySetBoolean(IReadOnlyList<string> strings, IReadOnlyList<int> ints)
	{
		_key = strings[0];
		_value = ints[0] == 1;
	}

	public override void Execute(AiMemoryNew memory, IAiParticipant participant)
	{
		memory.Booleans[_key] = _value;
	}
}
