using GameData.Common;
using GameData.Domains.Combat.Ai.Selector;
using GameData.Domains.Item;

namespace GameData.Domains.Combat.Ai.Action;

public abstract class AiActionUseItemBase : AiActionCombatBase
{
	private readonly ItemSelector _selector;

	protected virtual sbyte UseType => 0;

	protected AiActionUseItemBase()
	{
		_selector = new ItemSelector(IsValid, IsPrefer);
	}

	protected abstract bool IsValid(CombatCharacter combatChar, ItemKey itemKey);

	protected virtual bool IsPrefer(CombatCharacter combatChar, ItemKey itemKey)
	{
		return false;
	}

	public sealed override void Execute(AiMemoryNew memory, CombatCharacter combatChar)
	{
		DataContext context = DomainManager.Combat.Context;
		ItemKey itemKey = _selector.Select(context.Random, combatChar);
		if (itemKey.IsValid())
		{
			DomainManager.Combat.UseItem(context, itemKey, UseType, combatChar.IsAlly);
		}
	}
}
