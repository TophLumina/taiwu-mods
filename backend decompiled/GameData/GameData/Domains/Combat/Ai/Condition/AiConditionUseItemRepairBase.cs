using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

public abstract class AiConditionUseItemRepairBase : AiConditionCombatBase
{
	protected abstract IEnumerable<sbyte> EquipmentSlots { get; }

	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		return !combatChar.IsAlly && combatChar.AiSelectRepairTarget(EquipmentSlots).targetKey.IsValid();
	}
}
