using GameData.Domains.Character;
using GameData.Domains.Combat.Ai.Selector;
using GameData.Domains.Item;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.UseItemPoison)]
public class AiActionUseItemPoison : AiActionUseItemCommonBase
{
	protected override sbyte UseType => 1;

	public AiActionUseItemPoison()
		: base(EItemSelectorType.ThrowPoison)
	{
	}

	protected override bool IsPrefer(CombatCharacter combatChar, ItemKey itemKey)
	{
		return EatingItems.IsWugKing(itemKey);
	}
}
