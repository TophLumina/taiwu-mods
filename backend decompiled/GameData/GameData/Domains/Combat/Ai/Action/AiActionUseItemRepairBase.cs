using System.Collections.Generic;
using GameData.Common;

namespace GameData.Domains.Combat.Ai.Action;

public abstract class AiActionUseItemRepairBase : AiActionCombatBase
{
	protected abstract IEnumerable<sbyte> EquipmentSlots { get; }

	public override void Execute(AiMemoryNew memory, CombatCharacter combatChar)
	{
		DataContext context = DomainManager.Combat.Context;
		var (targetKey, toolKey) = combatChar.AiSelectRepairTarget(EquipmentSlots);
		if (targetKey.IsValid())
		{
			DomainManager.Combat.RepairItem(context, toolKey, targetKey, combatChar.IsAlly);
		}
	}
}
