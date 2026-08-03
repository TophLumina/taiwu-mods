using GameData.Domains.Combat.Ai.Selector;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.UseItemWine)]
public class AiActionUseItemWine : AiActionUseItemCommonBase
{
	public AiActionUseItemWine()
		: base(EItemSelectorType.Wine)
	{
	}
}
