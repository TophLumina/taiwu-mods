using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.MemorySetAcupointMarkCount)]
public class AiActionMemorySetAcupointMarkCount : AiActionMemorySetMarkCountBase
{
	public AiActionMemorySetAcupointMarkCount(IReadOnlyList<string> strings, IReadOnlyList<int> ints)
		: base(strings, ints)
	{
	}

	protected override int GetMarkCount(DefeatMarkCollection marks)
	{
		return marks.GetTotalAcupointCount();
	}
}
