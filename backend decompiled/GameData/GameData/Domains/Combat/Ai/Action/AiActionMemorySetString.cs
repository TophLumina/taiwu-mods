using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.MemorySetString)]
public class AiActionMemorySetString : AiActionCommonBase
{
	private readonly string _key;

	private readonly string _value;

	public AiActionMemorySetString(IReadOnlyList<string> strings, IReadOnlyList<int> ints)
	{
		_key = strings[0];
		_value = strings[1];
	}

	public override void Execute(AiMemoryNew memory, IAiParticipant participant)
	{
		memory.Strings[_key] = _value;
	}
}
