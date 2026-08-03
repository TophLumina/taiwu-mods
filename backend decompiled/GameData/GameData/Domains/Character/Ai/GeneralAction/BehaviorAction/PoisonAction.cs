using GameData.Common;
using GameData.Domains.Item;

namespace GameData.Domains.Character.Ai.GeneralAction.BehaviorAction;

public class PoisonAction : IGeneralAction
{
	public ItemKey PoisonItem;

	public sbyte ActionPhase;

	public sbyte ActionEnergyType => 4;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		int amount;
		if (PoisonItem.IsValid())
		{
			return selfChar.GetInventory().Items.TryGetValue(PoisonItem, out amount) && amount > 0;
		}
		return true;
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		ApplyChanges(context, selfChar, targetChar);
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		DomainManager.Character.HandlePoisonAction(context, selfChar, targetChar, PoisonItem, ActionPhase);
	}
}
