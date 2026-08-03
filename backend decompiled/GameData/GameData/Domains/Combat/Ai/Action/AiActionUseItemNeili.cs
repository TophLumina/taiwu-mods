using GameData.Domains.Combat.Ai.Selector;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.UseItemNeili)]
public class AiActionUseItemNeili : AiActionUseItemCommonBase
{
	public AiActionUseItemNeili()
		: base(EItemSelectorType.Neili)
	{
	}
}
