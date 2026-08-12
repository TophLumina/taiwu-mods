using GameData.Domains.Combat.Ai.Selector;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionUseItemHealPoison)]
public class AiConditionOptionUseItemHealPoison : AiConditionOptionUseItemCommonBase
{
	public AiConditionOptionUseItemHealPoison()
		: base(EItemSelectorType.HealPoison)
	{
	}
}
