using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.MemorySetInjuryMarkCount)]
public class AiActionMemorySetInjuryMarkCount : AiActionMemorySetMarkCountBase
{
	public AiActionMemorySetInjuryMarkCount(IReadOnlyList<string> strings, IReadOnlyList<int> ints)
		: base(strings, ints)
	{
	}

	protected override int GetMarkCount(DefeatMarkCollection marks)
	{
		return marks.GetTotalInjuryCount();
	}
}
