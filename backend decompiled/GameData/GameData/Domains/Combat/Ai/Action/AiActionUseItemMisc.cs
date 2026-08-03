using System.Collections.Generic;
using GameData.Domains.Item;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.UseItemMisc)]
public class AiActionUseItemMisc : AiActionUseItemBase
{
	private readonly short _templateId;

	public AiActionUseItemMisc(IReadOnlyList<int> ints)
	{
		_templateId = (short)ints[0];
	}

	protected override bool IsValid(CombatCharacter combatChar, ItemKey itemKey)
	{
		return itemKey.ItemType == 12 && itemKey.TemplateId == _templateId;
	}
}
