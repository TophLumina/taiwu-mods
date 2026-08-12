using System.Collections.Generic;
using GameData.Utilities;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.MemorySetPoisonMarkCount)]
public class AiActionMemorySetPoisonMarkCount : AiActionMemorySetMarkCountBase
{
	public AiActionMemorySetPoisonMarkCount(IReadOnlyList<string> strings, IReadOnlyList<int> ints)
		: base(strings, ints)
	{
	}

	protected override int GetMarkCount(DefeatMarkCollection marks)
	{
		return marks.PoisonMarkList.Sum();
	}
}
