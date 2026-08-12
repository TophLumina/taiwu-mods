using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.MemoryInternalSetBoolean)]
public class AiActionMemoryInternalSetBoolean : AiActionMemoryInternalSetBase<bool>
{
	public AiActionMemoryInternalSetBoolean(IReadOnlyList<string> strings)
		: base(strings)
	{
	}

	protected override IDictionary<string, bool> GetMemoryDict(AiMemoryNew memory)
	{
		return memory.Booleans;
	}
}
