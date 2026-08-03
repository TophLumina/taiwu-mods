using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.ChangeTrickFlaw)]
public class AiActionChangeTrickFlaw : AiActionChangeTrickBase
{
	protected override EFlawOrAcupointType ChangeTrickType => EFlawOrAcupointType.Flaw;

	public AiActionChangeTrickFlaw(IReadOnlyList<string> strings)
		: base(strings)
	{
	}
}
