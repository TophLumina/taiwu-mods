using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.MemoryInternalSetString)]
public class AiActionMemoryInternalSetString : AiActionMemoryInternalSetBase<string>
{
	public AiActionMemoryInternalSetString(IReadOnlyList<string> strings)
		: base(strings)
	{
	}

	protected override IDictionary<string, string> GetMemoryDict(AiMemoryNew memory)
	{
		return memory.Strings;
	}
}
