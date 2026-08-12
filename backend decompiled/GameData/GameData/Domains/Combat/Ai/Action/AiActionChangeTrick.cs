using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.ChangeTrick)]
public class AiActionChangeTrick : AiActionChangeTrickBase
{
	public AiActionChangeTrick(IReadOnlyList<string> strings)
		: base(strings)
	{
	}
}
