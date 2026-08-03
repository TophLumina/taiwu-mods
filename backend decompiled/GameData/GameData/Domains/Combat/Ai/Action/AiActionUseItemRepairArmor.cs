using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.UseItemRepairArmor)]
public class AiActionUseItemRepairArmor : AiActionUseItemRepairBase
{
	protected override IEnumerable<sbyte> EquipmentSlots
	{
		get
		{
			yield return 3;
			yield return 5;
			yield return 6;
			yield return 7;
		}
	}
}
