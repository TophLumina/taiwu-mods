using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.MemorySetMindMarkCount)]
public class AiActionMemorySetMindMarkCount : AiActionMemorySetMarkCountBase
{
	public AiActionMemorySetMindMarkCount(IReadOnlyList<string> strings, IReadOnlyList<int> ints)
		: base(strings, ints)
	{
	}

	protected override int GetMarkCount(DefeatMarkCollection marks)
	{
		return marks.MindMarkList.Count;
	}
}
