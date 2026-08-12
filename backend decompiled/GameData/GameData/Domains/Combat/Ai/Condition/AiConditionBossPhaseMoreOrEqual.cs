using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.BossPhaseMoreOrEqual)]
public class AiConditionBossPhaseMoreOrEqual : AiConditionCombatBase
{
	private readonly int _phase;

	public AiConditionBossPhaseMoreOrEqual(IReadOnlyList<int> ints)
	{
		_phase = ints[0];
	}

	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		return DomainManager.Combat.GetCombatCharacter(isAlly: false).GetBossPhase() >= _phase;
	}
}
