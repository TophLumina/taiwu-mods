using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.UseItemRepairWeapon)]
public class AiActionUseItemRepairWeapon : AiActionUseItemRepairBase
{
	protected override IEnumerable<sbyte> EquipmentSlots
	{
		get
		{
			yield return 0;
			yield return 1;
			yield return 2;
		}
	}
}
