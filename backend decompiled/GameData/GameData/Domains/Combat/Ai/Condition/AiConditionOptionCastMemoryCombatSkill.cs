using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionCastMemoryCombatSkill)]
public class AiConditionOptionCastMemoryCombatSkill : AiConditionOptionCastCombatSkillBase
{
	private readonly string _key;

	protected override short SkillId => (short)base.Memory.Ints.GetValueOrDefault(_key, -1);

	public AiConditionOptionCastMemoryCombatSkill(IReadOnlyList<string> strings)
	{
		_key = strings[0];
	}
}
