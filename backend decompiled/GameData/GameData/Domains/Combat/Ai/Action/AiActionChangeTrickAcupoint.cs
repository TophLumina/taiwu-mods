using System.Collections.Generic;
using Redzen.Random;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.ChangeTrickAcupoint)]
public class AiActionChangeTrickAcupoint : AiActionChangeTrickBase
{
	private readonly sbyte _bodyPart;

	protected override EFlawOrAcupointType ChangeTrickType => EFlawOrAcupointType.Acupoint;

	protected override sbyte GetTargetBodyPart(IRandomSource random, sbyte trickType, CombatCharacter combatChar)
	{
		return _bodyPart;
	}

	public AiActionChangeTrickAcupoint(IReadOnlyList<string> strings, IReadOnlyList<int> ints)
		: base(strings)
	{
		_bodyPart = (sbyte)ints[0];
	}
}
