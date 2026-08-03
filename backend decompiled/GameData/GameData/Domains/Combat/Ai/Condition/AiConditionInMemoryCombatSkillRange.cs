using System.Collections.Generic;
using GameData.Domains.Character;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.InMemoryCombatSkillRange)]
public class AiConditionInMemoryCombatSkillRange : AiConditionCombatBase
{
	private readonly string _key;

	private readonly bool _isAlly;

	private readonly int _offset;

	public AiConditionInMemoryCombatSkillRange(IReadOnlyList<string> strings, IReadOnlyList<int> ints)
	{
		_key = strings[0];
		_isAlly = ints[0] == 1;
		_offset = ints[1];
	}

	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		if (!memory.Ints.TryGetValue(_key, out var skillId) || skillId < 0)
		{
			return false;
		}
		CombatCharacter checkChar = DomainManager.Combat.GetCombatCharacter(combatChar.IsAlly == _isAlly);
		short distance = DomainManager.Combat.GetMoveRangeOffsetCurrentDistance(_offset);
		var (min, max) = (OuterAndInnerShorts)(ref checkChar.CalcAttackRangeImmediate((short)skillId));
		return min <= distance && distance <= max;
	}
}
