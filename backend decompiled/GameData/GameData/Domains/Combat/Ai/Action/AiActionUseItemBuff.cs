using GameData.Domains.Combat.Ai.Selector;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.UseItemBuff)]
public class AiActionUseItemBuff : AiActionUseItemCommonBase
{
	public AiActionUseItemBuff()
		: base(EItemSelectorType.Buff)
	{
	}
}
