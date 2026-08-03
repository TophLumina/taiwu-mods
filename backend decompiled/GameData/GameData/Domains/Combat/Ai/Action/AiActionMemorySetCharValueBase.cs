using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Action;

public abstract class AiActionMemorySetCharValueBase : AiActionCombatBase
{
	private readonly string _key;

	private readonly bool _isAlly;

	protected AiActionMemorySetCharValueBase(IReadOnlyList<string> strings, IReadOnlyList<int> ints)
	{
		_key = strings[0];
		_isAlly = ints[0] == 1;
	}

	public override void Execute(AiMemoryNew memory, CombatCharacter combatChar)
	{
		CombatCharacter checkChar = DomainManager.Combat.GetCombatCharacter(combatChar.IsAlly == _isAlly);
		memory.Ints[_key] = GetCharValue(checkChar);
	}

	protected abstract int GetCharValue(CombatCharacter checkChar);
}
