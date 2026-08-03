using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.MemorySetFlawMarkCount)]
public class AiActionMemorySetFlawMarkCount : AiActionMemorySetMarkCountBase
{
	public AiActionMemorySetFlawMarkCount(IReadOnlyList<string> strings, IReadOnlyList<int> ints)
		: base(strings, ints)
	{
	}

	protected override int GetMarkCount(DefeatMarkCollection marks)
	{
		return marks.GetTotalFlawCount();
	}
}
