using System.Collections.Generic;
using GameData.Domains.Item;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionUseItemMisc)]
public class AiConditionOptionUseItemMisc : AiConditionOptionUseItemBase
{
	private readonly short _templateId;

	public AiConditionOptionUseItemMisc(IReadOnlyList<int> ints)
	{
		_templateId = (short)ints[0];
	}

	protected override bool IsValid(CombatCharacter combatChar, ItemKey itemKey)
	{
		return itemKey.ItemType == 12 && itemKey.TemplateId == _templateId;
	}
}
