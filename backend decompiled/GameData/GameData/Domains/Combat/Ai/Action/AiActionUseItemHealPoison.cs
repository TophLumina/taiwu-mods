using GameData.Domains.Combat.Ai.Selector;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.UseItemHealPoison)]
public class AiActionUseItemHealPoison : AiActionUseItemCommonBase
{
	public AiActionUseItemHealPoison()
		: base(EItemSelectorType.HealPoison)
	{
	}
}
