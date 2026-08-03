using System.Collections.Generic;
using System.Linq;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.AnyNotInfinitySilenceSkill)]
public class AiConditionAnyNotInfinitySilenceSkill : AiConditionCheckCharBase
{
	public AiConditionAnyNotInfinitySilenceSkill(IReadOnlyList<int> ints)
		: base(ints)
	{
	}

	protected override bool Check(CombatCharacter checkChar)
	{
		return checkChar.GetBannedSkillIds(requireNotInfinity: true).Any();
	}
}
