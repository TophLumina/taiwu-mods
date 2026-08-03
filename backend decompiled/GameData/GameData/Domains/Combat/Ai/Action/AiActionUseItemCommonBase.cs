using GameData.Domains.Combat.Ai.Selector;
using GameData.Domains.Item;

namespace GameData.Domains.Combat.Ai.Action;

public abstract class AiActionUseItemCommonBase : AiActionUseItemBase
{
	private readonly ItemSelectorPredicate _predicate;

	protected AiActionUseItemCommonBase(EItemSelectorType selectorType)
	{
		ItemSelectorHelper.Predicates.TryGetValue(selectorType, out _predicate);
	}

	protected sealed override bool IsValid(CombatCharacter combatChar, ItemKey itemKey)
	{
		return _predicate?.Invoke(combatChar, itemKey) ?? false;
	}
}
