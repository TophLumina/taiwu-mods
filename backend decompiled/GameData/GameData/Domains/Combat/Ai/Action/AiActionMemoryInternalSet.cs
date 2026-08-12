using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.MemoryInternalSet)]
public class AiActionMemoryInternalSet : AiActionMemoryInternalSetBase<int>
{
	public AiActionMemoryInternalSet(IReadOnlyList<string> strings)
		: base(strings)
	{
	}

	protected override IDictionary<string, int> GetMemoryDict(AiMemoryNew memory)
	{
		return memory.Ints;
	}
}
