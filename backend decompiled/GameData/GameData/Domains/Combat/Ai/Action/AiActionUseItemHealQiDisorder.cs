using GameData.Domains.Combat.Ai.Selector;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.UseItemHealQiDisorder)]
public class AiActionUseItemHealQiDisorder : AiActionUseItemCommonBase
{
	public AiActionUseItemHealQiDisorder()
		: base(EItemSelectorType.HealQiDisorder)
	{
	}
}
