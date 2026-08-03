using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.MemorySetFatalMarkCount)]
public class AiActionMemorySetFatalMarkCount : AiActionMemorySetMarkCountBase
{
	public AiActionMemorySetFatalMarkCount(IReadOnlyList<string> strings, IReadOnlyList<int> ints)
		: base(strings, ints)
	{
	}

	protected override int GetMarkCount(DefeatMarkCollection marks)
	{
		return marks.FatalDamageMarkCount;
	}
}
