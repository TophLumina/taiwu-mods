using GameData.Domains.Combat.Ai.Selector;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionUseItemBuff)]
public class AiConditionOptionUseItemBuff : AiConditionOptionUseItemCommonBase
{
	public AiConditionOptionUseItemBuff()
		: base(EItemSelectorType.Buff)
	{
	}
}
