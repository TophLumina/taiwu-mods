using GameData.Domains.Combat.Ai.Selector;
using GameData.Domains.Item;

namespace GameData.Domains.Combat.Ai.Condition;

public abstract class AiConditionOptionUseItemBase : AiConditionCombatBase
{
	private readonly ItemSelector _selector;

	protected AiConditionOptionUseItemBase()
	{
		_selector = new ItemSelector(IsValid);
	}

	public sealed override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		return ExtraCheck(combatChar) && _selector.AnyMatch(combatChar);
	}

	protected virtual bool ExtraCheck(CombatCharacter combatChar)
	{
		return true;
	}

	protected abstract bool IsValid(CombatCharacter combatChar, ItemKey itemKey);
}
