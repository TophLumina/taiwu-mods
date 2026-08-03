using GameData.Domains.Combat.Ai.Selector;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionUseItemNeili)]
public class AiConditionOptionUseItemNeili : AiConditionOptionUseItemCommonBase
{
	public AiConditionOptionUseItemNeili()
		: base(EItemSelectorType.Neili)
	{
	}
}
