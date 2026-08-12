using GameData.Domains.Combat.Ai.Selector;
using GameData.Domains.Item;

namespace GameData.Domains.Combat.Ai.Condition;

public abstract class AiConditionOptionUseItemCommonBase : AiConditionOptionUseItemBase
{
	private readonly ItemSelectorPredicate _predicate;

	protected AiConditionOptionUseItemCommonBase(EItemSelectorType selectorType)
	{
		ItemSelectorHelper.Predicates.TryGetValue(selectorType, out _predicate);
	}

	protected sealed override bool IsValid(CombatCharacter combatChar, ItemKey itemKey)
	{
		return _predicate?.Invoke(combatChar, itemKey) ?? false;
	}
}
