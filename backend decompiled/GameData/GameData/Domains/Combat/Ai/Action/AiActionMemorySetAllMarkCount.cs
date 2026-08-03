using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.MemorySetAllMarkCount)]
public class AiActionMemorySetAllMarkCount : AiActionMemorySetMarkCountBase
{
	public AiActionMemorySetAllMarkCount(IReadOnlyList<string> strings, IReadOnlyList<int> ints)
		: base(strings, ints)
	{
	}

	protected override int GetMarkCount(DefeatMarkCollection marks)
	{
		return marks.GetTotalCount();
	}
}
