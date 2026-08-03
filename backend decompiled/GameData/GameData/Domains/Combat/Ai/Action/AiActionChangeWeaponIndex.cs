using System.Collections.Generic;
using GameData.Common;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.ChangeWeaponIndex)]
public class AiActionChangeWeaponIndex : AiActionCombatBase
{
	private readonly int _weaponIndex;

	public AiActionChangeWeaponIndex(IReadOnlyList<int> ints)
	{
		_weaponIndex = ints[0];
	}

	public override void Execute(AiMemoryNew memory, CombatCharacter combatChar)
	{
		DataContext context = DomainManager.Combat.Context;
		DomainManager.Combat.ChangeWeapon(context, _weaponIndex, combatChar.IsAlly);
	}
}
