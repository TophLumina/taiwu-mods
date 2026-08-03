using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionUseItemRepairArmor)]
public class AiConditionOptionUseItemRepairArmor : AiConditionUseItemRepairBase
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
