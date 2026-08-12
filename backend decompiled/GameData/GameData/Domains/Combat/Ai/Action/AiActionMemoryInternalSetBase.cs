using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Action;

public abstract class AiActionMemoryInternalSetBase<T> : AiActionCommonBase
{
	private readonly string _keyL;

	private readonly string _keyR;

	protected AiActionMemoryInternalSetBase(IReadOnlyList<string> strings)
	{
		_keyL = strings[0];
		_keyR = strings[1];
	}

	public override void Execute(AiMemoryNew memory, IAiParticipant participant)
	{
		IDictionary<string, T> dict = GetMemoryDict(memory);
		if (dict.TryGetValue(_keyR, out var value))
		{
			dict[_keyL] = value;
		}
	}

	protected abstract IDictionary<string, T> GetMemoryDict(AiMemoryNew memory);
}
