using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.MemoryEqualCasting)]
public class AiConditionMemoryEqualCasting : AiConditionCombatBase
{
	private readonly string _key;

	private readonly bool _isAlly;

	public AiConditionMemoryEqualCasting(IReadOnlyList<string> strings, IReadOnlyList<int> ints)
	{
		_key = strings[0];
		_isAlly = ints[0] == 1;
	}

	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		if (!memory.Ints.TryGetValue(_key, out var memoryCasting))
		{
			return false;
		}
		CombatCharacter checkChar = DomainManager.Combat.GetCombatCharacter(combatChar.IsAlly == _isAlly);
		return memoryCasting == checkChar.GetPreparingSkillId();
	}
}
