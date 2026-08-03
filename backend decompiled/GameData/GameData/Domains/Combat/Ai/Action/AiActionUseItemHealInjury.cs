using GameData.Domains.Combat.Ai.Selector;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.UseItemHealInjury)]
public class AiActionUseItemHealInjury : AiActionUseItemCommonBase
{
	public AiActionUseItemHealInjury()
		: base(EItemSelectorType.HealInjury)
	{
	}
}
