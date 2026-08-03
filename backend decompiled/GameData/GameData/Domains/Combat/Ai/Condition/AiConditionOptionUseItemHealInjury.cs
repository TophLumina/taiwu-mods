using GameData.Domains.Combat.Ai.Selector;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionUseItemHealInjury)]
public class AiConditionOptionUseItemHealInjury : AiConditionOptionUseItemCommonBase
{
	public AiConditionOptionUseItemHealInjury()
		: base(EItemSelectorType.HealInjury)
	{
	}
}
