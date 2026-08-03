using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionUseItemRepairWeapon)]
public class AiConditionOptionUseItemRepairWeapon : AiConditionUseItemRepairBase
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
