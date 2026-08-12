using System.Collections.Generic;
using Redzen.Random;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.ChangeTrickNeiliType)]
public class AiActionChangeTrickNeiliType : AiActionChangeTrickBase
{
	public AiActionChangeTrickNeiliType(IReadOnlyList<string> strings)
		: base(strings)
	{
	}

	protected override sbyte GetTargetBodyPart(IRandomSource random, sbyte trickType, CombatCharacter combatChar)
	{
		return combatChar.RandomChangeTrickBodyPartByNeiliType(random, trickType);
	}
}
