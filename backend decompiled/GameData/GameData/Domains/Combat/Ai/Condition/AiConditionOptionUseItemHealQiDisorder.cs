using GameData.Domains.Combat.Ai.Selector;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionUseItemHealQiDisorder)]
public class AiConditionOptionUseItemHealQiDisorder : AiConditionOptionUseItemCommonBase
{
	public AiConditionOptionUseItemHealQiDisorder()
		: base(EItemSelectorType.HealQiDisorder)
	{
	}
}
